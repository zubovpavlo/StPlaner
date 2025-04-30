using System;
using System.Collections.Generic;

namespace StPlaner.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<int> Courses { get; set; } = new List<int>();

        public Student()
        {
        }

        public Student(int id, string name, string username, string password)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be null or whitespace.", nameof(username));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be null or whitespace.", nameof(password));
            }

            ID = id;
            Name = name;
            Username = username;
            Password = password;
        }
    }
}
