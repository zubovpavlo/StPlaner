using System;

namespace StPlaner.Models
{
    public class ScheduleRow
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public string CourseName { get; set; }
        public string Status { get; set; } // Додана нова властивість
        public string StudyHours { get; set; }
        public bool Completed { get; set; }

        public ScheduleRow() { }

        public ScheduleRow(int id, DateTime date, string courseName, string status, string studyHours, bool completed)
        {
            if (string.IsNullOrWhiteSpace(courseName))
            {
                throw new ArgumentException("CourseName cannot be null or whitespace.", nameof(courseName));
            }

            if (string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentException("Status cannot be null or whitespace.", nameof(status));
            }

            if (string.IsNullOrWhiteSpace(studyHours))
            {
                throw new ArgumentException("StudyHours cannot be null or whitespace.", nameof(studyHours));
            }

            ID = id;
            Date = date.ToString("dddd dd.MM.yyyy");
            CourseName = courseName;
            Status = status;
            StudyHours = studyHours;
            Completed = completed;
        }
    }
}