using System;
using System.Collections.Generic;
using System.Text;

namespace Asal.StudentManagementSystem.Models
{
    public  class Student
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public int Age { get; set; }

        public double Grade { get; set; }
    }
}
