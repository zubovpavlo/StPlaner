using System;

namespace StPlaner.Models
{
    public class StudySchedule
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public double StudyHours { get; set; }
        public bool Completed { get; set; }

        public StudySchedule() { }

        public StudySchedule(int id, DateTime date, int courseId, string courseName, double studyHours, bool completed)
        {
            if (string.IsNullOrWhiteSpace(courseName))
                throw new ArgumentException("CourseName cannot be null or whitespace.", nameof(courseName));
            if (studyHours < 0)
                throw new ArgumentOutOfRangeException(nameof(studyHours), "StudyHours must be a non-negative value.");

            ID = id;
            Date = date;
            CourseID = courseId;
            CourseName = courseName;
            StudyHours = studyHours;
            Completed = completed;
        }
    }
}
