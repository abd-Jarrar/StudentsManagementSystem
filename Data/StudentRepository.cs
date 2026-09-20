using Asal.StudentManagementSystem.Interfaces;
using Asal.StudentManagementSystem.Models;
using Asal.StudentManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asal.StudentManagementSystem.Data
{
    public class StudentRepository :IStudentRepository

    {
        const int MaxGrade = 100;
        const int MinGrade = 0;
        const int MaxAge = 17;
        const int MinAge = 3;
        private readonly List<Student> _students = new List<Student>() {

        new Student { Id = Guid.Parse("045578b3-b088-4882-ab9e-53c4d97d94ff"), Name = "abd jarrar", Age = 7, Grade = 100 },
        new Student { Id = Guid.Parse("f78ef982-1c8c-4052-bf91-cbbe497b3c1a"), Name = "rami hijjawi", Age = 8, Grade = 92.4 },
        new Student { Id = Guid.Parse("e6610f30-04c3-43a5-8080-53fc1d39cc30"), Name = "samer ahmad", Age = 9, Grade = 50.2 },
        new Student { Id = Guid.Parse("5fe1178d-c575-44c1-b99e-9cec480997bf"), Name = "kareem salem", Age = 10, Grade = 91.7 },
        new Student { Id = Guid.Parse("9e842f37-82bb-462c-8f43-020041904c62"), Name = "ruba salem", Age = 11, Grade = 67.4 },
        new Student { Id = Guid.Parse("bf78f05b-fd0c-40ef-b852-5c5de459ca88"), Name = "emad nabulsi", Age = 12, Grade = 80.3 },
        new Student { Id = Guid.Parse("cba60928-cdd1-4caf-b1f7-f04d60365325"), Name = "rania titi", Age = 13, Grade = 88 },
        new Student { Id = Guid.Parse("dfe177a1-287a-4862-8680-f2eae6db4335"), Name = "sami jarrar", Age = 14, Grade = 90 },


        };

        public List<Student> GetAllStudents() => _students;

        public Student? GetStudentById(Guid Id)
        {
            Student st = new Student();
            foreach (var student in _students)
            {

                if (student.Id == Id)
                    return student;
            }
            return null;
        }

        public int GetStudentCount() => _students.Count();

        public bool AddNewStudent(string StudentName,int StudentAge,double StudentGrade)
        {
            if (string.IsNullOrWhiteSpace(StudentName) ||!StudentAge.IsBetween(MinAge,MaxAge)||!StudentGrade.IsBetween(MinGrade, MaxGrade))
            {
                return false;
            }
            _students.Add(new Student { Id = Guid.NewGuid(), Name = StudentName, Age = StudentAge, Grade = StudentGrade });
            return true;
        }

        public double GetAverageGrade()
        {
            double TotalGrades = 0;
            int NumberOfStudents = GetStudentCount();
            foreach(var student in _students)
            {
                TotalGrades += student.Grade;
            }
            return (TotalGrades/NumberOfStudents);
        }

        public List<Student> FilterStudents(Predicate<Student> predicate) {
            List<Student> students = new List<Student>();
            foreach(var student in _students)
            {
                if(predicate(student))
                    students.Add(student);

            }
            return students;
        }

        public bool UpdateStudentInformation(Guid StudentId,string NewName,int NewAge, double NewGrade)
        {
            if (string.IsNullOrWhiteSpace(NewName)
                || !NewAge.IsBetween(MinAge, MaxAge)
                || !NewGrade.IsBetween(MinGrade, MaxGrade)
                || !StudentExists(StudentId))
                return false;
            var student = GetStudentById(StudentId);
            student.Name = NewName;
            student.Age= NewAge;
            student.Grade= NewGrade;
            return true;
        }

        public bool StudentExists(Guid StudentId)
        {
            foreach(var student in _students)
            {
                if (student.Id == StudentId)
                    return true;
            }
            return false;
        }

        public bool DeleteStudent(Guid StudentId)
        {
            var student = GetStudentById(StudentId);
            if (student is null)
                return false;
            _students.Remove(student);
            return true;
        }

        public List<Student> SortStudentsByAgeDesc()
        {
            List<Student> students = _students.OrderByDescending(st => st.Age).ToList();
            return students;
        }
    }
}
