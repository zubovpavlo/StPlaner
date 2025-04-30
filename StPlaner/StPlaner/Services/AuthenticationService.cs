using System;
using System.Collections.Generic;
using System.Linq;
using StPlaner.Data;
using StPlaner.Models;

namespace StPlaner.Services
{
    public class AuthenticationService
    {
        private Student _currentUser;

        public bool Authenticate(string username, string password)
        {
            var students = LoadStudents();
            var student = students.FirstOrDefault(s => s.Username == username && s.Password == password);
            if (student != null)
            {
                _currentUser = student;
                return true;
            }
            return false;
        }

        public Student GetCurrentUser()
        {
            return _currentUser;
        }

        public void Logout()
        {
            _currentUser = null;
        }

        public int GetNextStudentID()
        {
            var students = LoadStudents();
            return students.Any() ? students.Max(s => s.ID) + 1 : 1;
        }

        public void RegisterStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            var students = LoadStudents();
            students.Add(student);
            SaveStudents(students);
        }

        public bool IsUsernameTaken(string username)
        {
            var students = LoadStudents();
            return students.Any(s => s.Username == username);
        }

        public void DeleteStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            var students = LoadStudents();
            var studentToRemove = students.FirstOrDefault(s => s.ID == student.ID);
            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
                SaveStudents(students);
            }
        }

        private List<Student> LoadStudents()
        {
            return JsonDataManager.LoadStudents();
        }

        private void SaveStudents(List<Student> students)
        {
            JsonDataManager.SaveStudents(students);
        }
    }
}
