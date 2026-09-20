using Asal.StudentManagementSystem.Interfaces;
using Asal.StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Asal.StudentManagementSystem.Services
{
    public class CsvStudentExporter : IExporterService<Student>
    {

        public void Export(List<Student> Data, string filePath)
        {
            var lines =new List<string>();
            lines.Add("Id,Name,Age,Grade");
            foreach (var student in Data)
            {
                lines.Add($"{student.Id},{student.Name},{student.Age},{student.Grade}");
            }
            File.WriteAllLines(filePath, lines);
        }
    }



}
