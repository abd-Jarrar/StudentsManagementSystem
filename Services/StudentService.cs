using Asal.StudentManagementSystem.Interfaces;
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

        }
    }
}
