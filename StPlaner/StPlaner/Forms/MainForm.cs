using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using StPlaner.Data;
using StPlaner.Models;
using StPlaner.Services;
using StPlaner.Utils;

namespace StPlaner.Forms
{
    public partial class MainForm : Form
    {
        private readonly Student _student;
        private readonly ScheduleService _scheduleService;
        private List<Course> _courses;
        private List<StudySchedule> _studySchedules;

        public MainForm(Student student)
        {
            InitializeComponent();
            _student = student;
            _scheduleService = new ScheduleService();
            _courses = JsonDataManager.LoadCourses();
            _studySchedules = JsonDataManager.LoadStudySchedules();

            // Синхронізація курсів з їх розкладами навчання
            foreach (var course in _courses)
            {
                course.StudySchedules = _studySchedules.Where(s => s.CourseID == course.ID).ToList();
            }

            LoadCourses();
            LoadPersonalSchedule();

            dgvPersonalSchedule.CellFormatting += dgvPersonalSchedule_CellFormatting;
        }

        private void LoadCourses()
        {
            var studentCourses = _student.Courses
                .Select(courseId => _courses.FirstOrDefault(c => c.ID == courseId))
                .Where(c => c != null)
                .ToList();

            var coursesDisplay = studentCourses.Select(c => new
            {
                c.ID,
                c.Name,
                c.ECTS,
                StartDate = c.StartDate.ToString("dd.MM.yyyy"),
                EndDate = c.EndDate.ToString("dd.MM.yyyy"),
                Progress = $"{c.Progress:F2}%",
                c.Status
            }).ToList();

            dgvCourses.DataSource = null;
            dgvCourses.Columns.Clear();
            dgvCourses.DataSource = coursesDisplay;

            if (dgvCourses.Columns.Contains("ID"))
            {
                dgvCourses.Columns["ID"].Visible = false;
            }

            AddCourseButtons();

            foreach (DataGridViewColumn column in dgvCourses.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void LoadPersonalSchedule()
        {
            var personalSchedule = new List<ScheduleRow>();
            DateTime? lastDate = null;

            var schedules = _student.Courses
                .SelectMany(courseId => _studySchedules.Where(s => s.CourseID == courseId))
                .OrderBy(s => s.Date);

            foreach (var s in schedules)
            {
                var course = _courses.FirstOrDefault(c => c.ID == s.CourseID);
                var row = new ScheduleRow
                {
                    ID = s.ID,
                    Date = lastDate != s.Date ? s.Date.ToString("dddd dd.MM.yyyy") : "",
                    CourseName = s.CourseName,
                    Status = course != null ? course.Status : "Unknown",
                    StudyHours = DateTimeUtils.FormatStudyHours(s.StudyHours),
                    Completed = s.Completed
                };

                personalSchedule.Add(row);
                lastDate = s.Date;
            }

            dgvPersonalSchedule.DataSource = personalSchedule;

            if (dgvPersonalSchedule.Columns.Contains("ID"))
            {
                dgvPersonalSchedule.Columns["ID"].Visible = false;
            }

            AddCompletedColumn();

            foreach (DataGridViewColumn column in dgvPersonalSchedule.Columns)
            {
                column.ReadOnly = column.Name != "Completed";
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            dgvPersonalSchedule.CellValueChanged += DgvPersonalSchedule_CellValueChanged;
            dgvPersonalSchedule.CurrentCellDirtyStateChanged += DgvPersonalSchedule_CurrentCellDirtyStateChanged;
            dgvPersonalSchedule.DataError += DgvPersonalSchedule_DataError;
        }

        private void AddCourseButtons()
        {
            var editButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = { BackColor = Color.White, ForeColor = Color.Black }
            };
            dgvCourses.Columns.Add(editButtonColumn);

            var deleteButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = { BackColor = Color.White, ForeColor = Color.Black }
            };
            dgvCourses.Columns.Add(deleteButtonColumn);
        }

        private void AddCompletedColumn()
        {
            if (!dgvPersonalSchedule.Columns.Contains("Completed"))
            {
                var completedColumn = new DataGridViewCheckBoxColumn
                {
                    Name = "Completed",
                    HeaderText = "Completed",
                    DataPropertyName = "Completed"
                };
                dgvPersonalSchedule.Columns.Add(completedColumn);
            }
            else
            {
                dgvPersonalSchedule.Columns["Completed"].DataPropertyName = "Completed";
            }

            if (!dgvPersonalSchedule.Columns.Contains("Status"))
            {
                var statusColumn = new DataGridViewTextBoxColumn
                {
                    Name = "Status",
                    HeaderText = "Status",
                    DataPropertyName = "Status"
                };
                dgvPersonalSchedule.Columns.Add(statusColumn);
            }
            else
            {
                dgvPersonalSchedule.Columns["Status"].DataPropertyName = "Status";
            }
        }
        private void DgvPersonalSchedule_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPersonalSchedule.Columns["Completed"].Index && e.RowIndex >= 0)
            {
                var scheduleId = (int)dgvPersonalSchedule.Rows[e.RowIndex].Cells["ID"].Value;
                var schedule = _studySchedules.FirstOrDefault(s => s.ID == scheduleId);
                if (schedule != null)
                {
                    schedule.Completed = (bool)dgvPersonalSchedule.Rows[e.RowIndex].Cells["Completed"].Value;
                    JsonDataManager.SaveStudySchedules(_studySchedules);

                    // Оновлення прогресу курсу
                    var course = _courses.FirstOrDefault(c => c.ID == schedule.CourseID);
                    if (course != null)
                    {
                        course.StudySchedules = _studySchedules.Where(s => s.CourseID == course.ID).ToList();
                        JsonDataManager.SaveCourses(_courses);
                    }

                    // Оновлення таблиці курсів для відображення змін
                    LoadCourses();
                }
            }

            dgvPersonalSchedule.Invalidate();
        }

        private void DgvPersonalSchedule_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvPersonalSchedule.IsCurrentCellDirty)
            {
                dgvPersonalSchedule.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvPersonalSchedule_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show($"Data Error: {e.Exception.Message}");
        }

        private void EditCourse(int rowIndex)
        {
            var courseId = (int)dgvCourses.Rows[rowIndex].Cells["ID"].Value;
            var course = _courses.FirstOrDefault(c => c.ID == courseId);
            if (course != null)
            {
                using (var courseForm = new CourseForm(_student, _courses, course))
                {
                    courseForm.FormClosed += (s, args) =>
                    {
                        if (courseForm.DialogResult == DialogResult.OK)
                        {
                            // Збереження існуючих розкладів навчання
                            var existingStudySchedules = course.StudySchedules.ToList();

                            // Оновлення даних курсу
                            course.Name = courseForm.Course.Name;
                            course.ECTS = courseForm.Course.ECTS;
                            course.StartDate = courseForm.Course.StartDate;
                            course.EndDate = courseForm.Course.EndDate;

                            // Оновлення назви курсу в розкладі навчання
                            foreach (var schedule in existingStudySchedules)
                            {
                                schedule.CourseName = course.Name;
                            }

                            // Перерахунок StudyHours якщо кількість кредитів або дати змінилися
                            if (course.ECTS != courseForm.Course.ECTS ||
                                course.StartDate != courseForm.Course.StartDate ||
                                course.EndDate != courseForm.Course.EndDate)
                            {
                                RecalculateStudySchedules(course);
                            }

                            SaveAllData();
                            LoadCourses();
                            LoadPersonalSchedule();
                        }
                    };
                    courseForm.ShowDialog();
                }
            }
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
                    schedule.CourseName = course.Name; // Оновлення назви курсу
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

        private void DeleteCourse(int rowIndex)
        {
            var result = MessageBox.Show("Are you sure you want to delete this course?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var courseId = (int)dgvCourses.Rows[rowIndex].Cells["ID"].Value;
                var course = _courses.FirstOrDefault(c => c.ID == courseId);
                if (course != null)
                {
                    _student.Courses.Remove(course.ID);
                    _courses.Remove(course);
                    _studySchedules.RemoveAll(s => s.CourseID == course.ID);
                    SaveAllData();
                    LoadCourses();
                    LoadPersonalSchedule();
                }
            }
        }

        private void SaveAllData()
        {
            var allStudents = LoadStudentsFromJson();
            var studentInList = allStudents.FirstOrDefault(s => s.ID == _student.ID);
            if (studentInList != null)
            {
                studentInList.Courses = _student.Courses;
            }
            else
            {
                allStudents.Add(_student);
            }

            SaveStudentsToJson(allStudents);
            SaveCoursesToJson();
            SaveStudySchedulesToJson();
        }

        private void SaveCoursesToJson()
        {
            var json = System.Text.Json.JsonSerializer.Serialize(_courses);
            File.WriteAllText("courses.json", json);
        }

        private void SaveStudentsToJson(List<Student> students)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(students);
            File.WriteAllText("students.json", json);
        }

        private List<Student> LoadStudentsFromJson()
        {
            if (!File.Exists("students.json"))
            {
                return new List<Student>();
            }

            var json = File.ReadAllText("students.json");
            return System.Text.Json.JsonSerializer.Deserialize<List<Student>>(json);
        }




        private void txtCourseFilter_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtCourseFilter.Text.ToLower();

            var filteredCourses = _student.Courses
                .Select(courseId => _courses.FirstOrDefault(c => c.ID == courseId))
                .Where(c => c != null && c.Name.ToLower().Contains(filterText))
                .Select(c => new
                {
                    c.ID,
                    c.Name,
                    c.ECTS,
                    StartDate = c.StartDate.ToString("dd.MM.yyyy"),
                    EndDate = c.EndDate.ToString("dd.MM.yyyy"),
                    Progress = $"{c.Progress:F2}%",
                    c.Status
                })
                .ToList();

            dgvCourses.DataSource = null;
            dgvCourses.Columns.Clear();
            dgvCourses.DataSource = filteredCourses;

            if (dgvCourses.Columns.Contains("ID"))
            {
                dgvCourses.Columns["ID"].Visible = false;
            }

            // Завжди додавати колонку Status
            if (!dgvCourses.Columns.Contains("Status"))
            {
                var statusColumn = new DataGridViewTextBoxColumn
                {
                    Name = "Status",
                    HeaderText = "Status",
                    DataPropertyName = "Status"
                };
                dgvCourses.Columns.Add(statusColumn);
            }

            AddCourseButtons();

            var filteredSchedule = _student.Courses
                .SelectMany(courseId => _studySchedules.Where(s => s.CourseID == courseId && s.CourseName.ToLower().Contains(filterText)))
                .OrderBy(s => s.Date)
                .Select(s => new ScheduleRow
                {
                    ID = s.ID,
                    Date = s.Date.ToString("dddd dd.MM.yyyy"),
                    CourseName = s.CourseName,
                    Status = _courses.FirstOrDefault(c => c.ID == s.CourseID)?.Status ?? "Unknown",
                    StudyHours = DateTimeUtils.FormatStudyHours(s.StudyHours),
                    Completed = s.Completed
                })
                .ToList();

            dgvPersonalSchedule.DataSource = filteredSchedule;

            // Завжди додавати колонку Status у розклад
            if (!dgvPersonalSchedule.Columns.Contains("Status"))
            {
                var statusColumn = new DataGridViewTextBoxColumn
                {
                    Name = "Status",
                    HeaderText = "Status",
                    DataPropertyName = "Status"
                };
                dgvPersonalSchedule.Columns.Add(statusColumn);
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            SaveAllData();
            this.Hide();
            using (var loginForm = new LoginForm())
            {
                loginForm.ShowDialog();
            }
            this.Close();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            using (var deleteAccountForm = new DeleteAccountForm(_student))
            {
                deleteAccountForm.ShowDialog();

                if (deleteAccountForm.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show("Account deleted successfully.");
                    this.Hide();
                    using (var loginForm = new LoginForm())
                    {
                        loginForm.ShowDialog();
                    }
                    this.Close();
                }
            }
        }

        private void dgvCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCourses.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                EditCourse(e.RowIndex);
            }
            else if (e.ColumnIndex == dgvCourses.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DeleteCourse(e.RowIndex);
            }
        }

        private void dgvCourses_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dgvCourses.Columns[e.ColumnIndex].Name == "Edit" || dgvCourses.Columns[e.ColumnIndex].Name == "Delete")
                {
                    e.PaintBackground(e.CellBounds, true);

                    TextRenderer.DrawText(e.Graphics, e.Value.ToString(), e.CellStyle.Font, e.CellBounds, e.CellStyle.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    e.Handled = true;
                }
            }
        }

        private void dgvCourses_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                dgvCourses.Cursor = dgvCourses.Columns[e.ColumnIndex].Name == "Edit" || dgvCourses.Columns[e.ColumnIndex].Name == "Delete" ? Cursors.Hand : Cursors.Default;
            }
        }

        private void dgvCourses_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgvCourses.Cursor = Cursors.Default;
        }

        private void dgvPersonalSchedule_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvPersonalSchedule.Columns["Date"].Index && e.RowIndex > 0)
            {
                if (dgvPersonalSchedule.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals(dgvPersonalSchedule.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value))
                {
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            using (var courseForm = new CourseForm(_student, _courses))
            {
                courseForm.FormClosed += (s, args) =>
                {
                    if (courseForm.DialogResult == DialogResult.OK)
                    {
                        _scheduleService.GenerateStudySchedule(courseForm.Course);
                        _student.Courses.Add(courseForm.Course.ID);
                        _courses.Add(courseForm.Course);
                        _studySchedules.AddRange(courseForm.Course.StudySchedules);
                        SaveAllData();
                        LoadCourses();
                        LoadPersonalSchedule();
                    }
                };
                courseForm.ShowDialog();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveAllData();
            MessageBox.Show("Data saved successfully.");
        }
    }
}
