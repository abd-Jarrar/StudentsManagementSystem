using Asal.StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asal.StudentManagementSystem
{
    public class StudentsDatabase
    {
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
    }
}
