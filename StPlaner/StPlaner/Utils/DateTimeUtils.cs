using System;
using System.Collections.Generic;

namespace StPlaner.Utils
{
    public static class DateTimeUtils
    {
        /// <summary>
        /// Calculates the number of days between two dates, inclusive.
        /// </summary>
        /// <param name="start">The start date.</param>
        /// <param name="end">The end date.</param>
        /// <returns>The number of days between the start and end dates.</returns>
        public static int CalculateDaysBetween(DateTime start, DateTime end)
        {
            return (end - start).Days + 1;
        }

        /// <summary>
        /// Formats a double value representing study hours into a readable string.
        /// </summary>
        /// <param name="studyHours">The number of study hours.</param>
        /// <returns>A formatted string representing the study hours in hours and minutes.</returns>
        public static string FormatStudyHours(double studyHours)
        {
            int totalMinutes = (int)(studyHours * 60);
            int hours = totalMinutes / 60;
            int minutes = totalMinutes % 60;

            var formattedTime = new List<string>();

            if (hours > 0)
            {
                formattedTime.Add($"{hours} hour{(hours != 1 ? "s" : "")}");
            }
            if (minutes > 0)
            {
                formattedTime.Add($"{minutes} minute{(minutes != 1 ? "s" : "")}");
            }

            return string.Join(" ", formattedTime);
        }

        /// <summary>
        /// Gets the list of public holidays in the Czech Republic for a given year.
        /// </summary>
        /// <param name="year">The year for which to get the holidays.</param>
        /// <returns>A list of DateTime objects representing the holidays.</returns>
        public static List<DateTime> GetCzechHolidays(int year)
        {
            return new List<DateTime>
            {
                new DateTime(year, 1, 1),   // New Year's Day
                new DateTime(year, 4, 5),   // Easter Monday (variable date)
                new DateTime(year, 5, 1),   // Labour Day
                new DateTime(year, 5, 8),   // Liberation Day
                new DateTime(year, 7, 5),   // Saints Cyril and Methodius Day
                new DateTime(year, 7, 6),   // Jan Hus Day
                new DateTime(year, 9, 28),  // St. Wenceslas Day
                new DateTime(year, 10, 28), // Independent Czechoslovak State Day
                new DateTime(year, 11, 17), // Struggle for Freedom and Democracy Day
                new DateTime(year, 12, 24), // Christmas Eve
                new DateTime(year, 12, 25), // Christmas Day
                new DateTime(year, 12, 26)  // St. Stephen's Day
            };
        }
    }
}
