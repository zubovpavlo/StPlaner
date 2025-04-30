using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using StPlaner.Models;

namespace StPlaner.Data
{
    public static class JsonDataManager
    {
        private static readonly string StudentsFilePath = "students.json";
        private static readonly string CoursesFilePath = "courses.json";
        private static readonly string StudySchedulesFilePath = "studySchedules.json";

        public static List<Student> LoadStudents()
        {
            return LoadData<List<Student>>(StudentsFilePath) ?? new List<Student>();
        }

        public static void SaveStudents(List<Student> students)
        {
            SaveData(StudentsFilePath, students);
        }

        public static List<Course> LoadCourses()
        {
            return LoadData<List<Course>>(CoursesFilePath) ?? new List<Course>();
        }

        public static void SaveCourses(List<Course> courses)
        {
            SaveData(CoursesFilePath, courses);
        }

        public static List<StudySchedule> LoadStudySchedules()
        {
            return LoadData<List<StudySchedule>>(StudySchedulesFilePath) ?? new List<StudySchedule>();
        }

        public static void SaveStudySchedules(List<StudySchedule> studySchedules)
        {
            SaveData(StudySchedulesFilePath, studySchedules);
        }

        private static T LoadData<T>(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<T>(json);
            }
            return default;
        }

        private static void SaveData<T>(string filePath, T data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
