using System;
using System.Collections.Generic;
using System.Linq;
using StPlaner.Models;
using StPlaner.Utils;

namespace StPlaner.Services
{
    public class ScheduleService
    {
        public void GenerateStudySchedule(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            int totalStudyHours = course.ECTS * 25;
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

            List<StudySchedule> schedules = new List<StudySchedule>();

            for (int i = 0; i < studyDays.Count; i++)
            {
                var schedule = new StudySchedule
                {
                    ID = course.ID * 1000 + i,
                    Date = studyDays[i],
                    CourseID = course.ID,
                    CourseName = course.Name,
                    StudyHours = dailyStudyHours,
                    Completed = false
                };
                schedules.Add(schedule);
            }

            course.StudySchedules = schedules;
        }

        public void UpdateStudySchedule(Course course, List<StudySchedule> existingSchedules)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            if (existingSchedules == null)
            {
                throw new ArgumentNullException(nameof(existingSchedules));
            }

            existingSchedules.RemoveAll(s => s.CourseID == course.ID);
            GenerateStudySchedule(course);
            existingSchedules.AddRange(course.StudySchedules);
        }
    }
}
