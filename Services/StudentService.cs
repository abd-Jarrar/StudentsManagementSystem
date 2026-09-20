using Asal.StudentManagementSystem.Interfaces;
using Asal.StudentManagementSystem.Models;
using Asal.StudentManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asal.StudentManagementSystem.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }
        public void AddStudent()
        {
            string Name = StudentManagementSystsemUtilities.AskForName();
            int Age = StudentManagementSystsemUtilities.AskForAge();
            double Grade = StudentManagementSystsemUtilities.AskForGrade();
            if (_repository.AddNewStudent(Name, Age, Grade))
                Console.WriteLine($"Student {Name} was a succesfully Added");
            else
            {
                Console.WriteLine($"Failed to add {Name}");
            }
        }
        public void ViewAllStudents()
        {
            List<Student> students = _repository.GetAllStudents();

            StudentManagementSystsemUtilities.PrintStudents(students);
        }

        public void GetStudentById()
        {
            var studentId = StudentManagementSystsemUtilities.AskForGuid();
            Student? student= _repository.GetStudentById(studentId);
            if (student is null)
                Console.WriteLine("student was not found!!!");
            else
            {
                StudentManagementSystsemUtilities.PrintStudent(student);
            }
        }

        public void DeleteStudentById()
        {
            var studentId = StudentManagementSystsemUtilities.AskForGuid();
            bool exists= _repository.StudentExists(studentId);
            if (!exists)
                Console.WriteLine("student was not found!!!");
            _repository.DeleteStudent(studentId);
                Console.WriteLine("student was succesfully Deleted");

        }

        public void FilterStudentsByGrade()
        {
            Console.WriteLine("enter the required grade: ");
            double grade = StudentManagementSystsemUtilities.AskForGrade();
            Console.WriteLine("[1] higher than this grade");
            Console.WriteLine("[2] lower than this grade");
            Console.WriteLine("[3] equal this grade");
            int choice = StudentManagementSystsemUtilities.AskForNumberBetween(1, 3);
            List<Student> students;
            if (choice == 1)
            {
                 students = _repository.FilterStudents(st => st.Grade > grade);
            }
            else if (choice == 2)
            {
                students = _repository.FilterStudents(st => st.Grade < grade);

            }
            else  
            {
                students = _repository.FilterStudents(st => st.Grade == grade);
            }
            StudentManagementSystsemUtilities.PrintStudents(students);
        }

        public void DisplayAverageGrade()
        {
            Console.WriteLine($"Average grade is: {_repository.GetAverageGrade()}");
        }

        public void DisplayStudentsSortedByGrade()
        {
            List<Student> students = _repository.SortStudentsByAgeDesc();
            StudentManagementSystsemUtilities.PrintStudents(students);
        }

        public void UpdateStudent()
        {
            Guid studentId = StudentManagementSystsemUtilities.AskForGuid();
            bool exists = _repository.StudentExists(studentId);
            if (!exists)
                Console.WriteLine("student was not found!!!");
            else
            {
                var student = _repository.GetStudentById(studentId);
                string NewName=student.Name;
                double NewGrade=student.Grade;
                int NewAge=student.Age;
                Console.Write("Do you want to update the name? (y/n): ");
                string? updateName = Console.ReadLine();

                if (updateName?.ToLower() == "y")
                {
                    Console.Write("Enter the new name: ");
                    NewName = StudentManagementSystsemUtilities.AskForName();
                }

                Console.Write("Do you want to update the age? (y/n): ");
                string? updateAge = Console.ReadLine();

                if (updateAge?.ToLower() == "y")
                {
                    Console.Write("Enter the new age: ");
                    NewAge = StudentManagementSystsemUtilities.AskForAge();
                }

                Console.Write("Do you want to update the grade? (y/n): ");
                string? updateGrade = Console.ReadLine();

                if (updateGrade?.ToLower() == "y")
                {
                    Console.Write("Enter the new grade: ");
                    NewGrade= StudentManagementSystsemUtilities.AskForGrade();
                }
                _repository.UpdateStudentInformation(studentId, NewName, NewAge, NewGrade);
                Console.WriteLine("Student update process completed.");

            }
        }
    }
}
