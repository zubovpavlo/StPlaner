using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using StPlaner.Models;
using StPlaner.Data;
using System.IO;
using StPlaner.Utils;

namespace StPlaner.Forms
{
    public partial class CourseForm : Form
    {
        public Course Course { get; private set; }
        private readonly Student _student;
        private readonly Course _existingCourse;
        private readonly List<Course> _courses; // Додано

        public CourseForm(Student student, List<Course> courses, Course course = null)
        {
            InitializeComponent();
            _student = student;
            _courses = courses;
            _existingCourse = course;

            // Встановлюємо значення за замовчанням для ComboBox
            if (cbStatus.Items.Count > 0)
            {
                cbStatus.SelectedIndex = 0;
            }

            if (course != null)
            {
                InitializeFormWithExistingCourse(course);
                Course = course;
            }
            else
            {
                Course = CreateNewCourse();
            }

            if (_existingCourse != null)
            {
                cbStatus.SelectedItem = _existingCourse.Status;
            }
        }

        private void InitializeFormWithExistingCourse(Course course)
        {
            txtCourseName.Text = course.Name;
            numECTS.Value = course.ECTS;
            dtpStartDate.Value = course.StartDate;
            dtpEndDate.Value = course.EndDate;
            lblProgress.Text = $"Progress: {course.Progress:F2}%";
        }

        private Course CreateNewCourse()
        {
            var defaultStatus = cbStatus.SelectedItem?.ToString() ?? "Povinné (A)";
            return new Course
            {
                ID = GenerateUniqueCourseID(),
                Name = string.Empty,
                ECTS = 0,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Status = defaultStatus // Використовуємо безпечне значення за замовчанням
            };
        }

        private int GenerateUniqueCourseID()
        {
            return _courses.Any() ? _courses.Max(c => c.ID) + 1 : 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (_existingCourse != null)
                {
                    UpdateExistingCourseFromForm();
                }
                else
                {
                    UpdateCourseFromForm();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill in all fields correctly.");
            }
        }

        private bool ValidateForm()
        {
            return !string.IsNullOrEmpty(txtCourseName.Text) && numECTS.Value > 0;
        }

        private void UpdateCourseFromForm()
        {
            Course.Name = txtCourseName.Text;
            Course.ECTS = (int)numECTS.Value;
            Course.StartDate = dtpStartDate.Value;
            Course.EndDate = dtpEndDate.Value;
            Course.Status = cbStatus.SelectedItem.ToString();
            lblProgress.Text = $"Progress: {Course.Progress:F2}%";
        }

        private void UpdateExistingCourseFromForm()
        {
            var originalECTS = _existingCourse.ECTS;
            var originalStartDate = _existingCourse.StartDate;
            var originalEndDate = _existingCourse.EndDate;

            _existingCourse.Name = txtCourseName.Text;
            _existingCourse.ECTS = (int)numECTS.Value;
            _existingCourse.StartDate = dtpStartDate.Value;
            _existingCourse.EndDate = dtpEndDate.Value;
            _existingCourse.Status = cbStatus.SelectedItem.ToString();

            // Перерахунок StudyHours тільки якщо змінилися ECTS або дати
            if (_existingCourse.ECTS != originalECTS ||
                _existingCourse.StartDate != originalStartDate ||
                _existingCourse.EndDate != originalEndDate)
            {
                RecalculateStudySchedules(_existingCourse);
            }

            lblProgress.Text = $"Progress: {_existingCourse.Progress:F2}%";
        }

        private void RecalculateStudySchedules(Course course)
        {
            int totalStudyHours = course.ECTS * 25; // або інший коефіцієнт, залежно від вимог
            var holidays = DateTimeUtils.GetCzechHolidays(course.StartDate.Year)
                            .Concat(DateTimeUtils.GetCzechHolidays(course.EndDate.Year))
                            .ToList();

            DateTime currentDate = course.StartDate;
            List<DateTime> studyDays = new List<DateTime>();

            while (currentDate <= course.EndDate)
            {
                if (currentDate.DayOfWeek != DayOfWeek.Saturday &&
                    currentDate.DayOfWeek != DayOfWeek.Sunday &&
                    !holidays.Contains(currentDate))
                {
                    studyDays.Add(currentDate);
                }
                currentDate = currentDate.AddDays(1);
            }

            double dailyStudyHours = (double)totalStudyHours / studyDays.Count;

            foreach (var schedule in course.StudySchedules)
            {
                if (studyDays.Contains(schedule.Date))
                {
                    schedule.StudyHours = Math.Round(dailyStudyHours, 2); // Округлення до 2 знаків після коми
                }
            }

            SaveStudySchedulesToJson();
        }

        private void SaveStudySchedulesToJson()
        {
            var studySchedules = _courses.SelectMany(c => c.StudySchedules).ToList();
            var json = System.Text.Json.JsonSerializer.Serialize(studySchedules);
            File.WriteAllText("studySchedules.json", json);
        }

        private void numECTS_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
