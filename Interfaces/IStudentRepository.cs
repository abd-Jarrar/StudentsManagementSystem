using Asal.StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asal.StudentManagementSystem.Interfaces
{
    public interface IStudentRepository
    {
        Student? GetStudentById(Guid StudentId);
        List<Student> GetAllStudents();

        bool AddNewStudent(string StudentName, int StudentAge, int StudentGrade);

        double GetAverageGrade();

        List<Student> FilterStudents(Predicate<Student> predicate);

        bool UpdateStudentInformation(Student student, string NewName, int NewAge, int NewGrade);

        bool DeleteStudent(Guid StudentId);

        List<Student> SortStudentsByAgeDesc();
        
    }
}
