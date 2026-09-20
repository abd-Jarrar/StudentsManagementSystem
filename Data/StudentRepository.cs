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

        new Student{Id=Guid.NewGuid(),Name="abd jarrar",Age=7,Grade=2},
        new Student{Id=Guid.NewGuid(),Name="rami hijjawi",Age=8,Grade=3},
        new Student{Id=Guid.NewGuid(),Name="samer ahmad",Age=9,Grade=4},
        new Student{Id=Guid.NewGuid(),Name="kareem salem",Age=10,Grade=5},
        new Student{Id=Guid.NewGuid(),Name="ruba salem",Age=11,Grade=6},
        new Student{Id=Guid.NewGuid(),Name="emad nabulsi",Age=12,Grade=7},
        new Student{Id=Guid.NewGuid(),Name="rania titi",Age=13,Grade=8},
        new Student{Id=Guid.NewGuid(),Name="sami jarrar",Age=14,Grade=9},

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

        public bool AddNewStudent(string StudentName,int StudentAge,int StudentGrade)
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

        public bool UpdateStudentInformation(Student student,string NewName,int NewAge,int NewGrade)
        {
            if (student is null || string.IsNullOrWhiteSpace(NewName)
                || !NewAge.IsBetween(MinAge, MaxAge)
                || !NewGrade.IsBetween(MinGrade, MaxGrade)
                || !StudentExists(student.Id))
                return false;
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
