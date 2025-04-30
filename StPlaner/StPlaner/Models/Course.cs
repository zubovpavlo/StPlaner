using System;
using System.Collections.Generic;
using System.Linq;

namespace StPlaner.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ECTS { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public List<StudySchedule> StudySchedules { get; set; } = new List<StudySchedule>();

        public double Progress => CalculateProgress();

        public Course() { }

        public Course(int id, string name, int ects, DateTime startDate, DateTime endDate, string status)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));
            if (ects <= 0)
                throw new ArgumentOutOfRangeException(nameof(ects), "ECTS must be greater than zero.");
            if (startDate >= endDate)
                throw new ArgumentException("StartDate must be earlier than EndDate.");
            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("Status cannot be null or whitespace.", nameof(status));

            ID = id;
            Name = name;
            ECTS = ects;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
        }

        private double CalculateProgress()
        {
            if (StudySchedules == null || StudySchedules.Count == 0)
                return 0;

            double completedHours = StudySchedules.Where(s => s.Completed).Sum(s => s.StudyHours);
            double totalHours = StudySchedules.Sum(s => s.StudyHours);

            return totalHours > 0 ? (completedHours / totalHours) * 100 : 0;
        }
    }
}
