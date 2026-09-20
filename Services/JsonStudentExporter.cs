using Asal.StudentManagementSystem.Data;
using Asal.StudentManagementSystem.Interfaces;
using Asal.StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Asal.StudentManagementSystem.Services
{
    public  class JsonStudentExporter : IExporterService<Student>
    {

        public void Export(List<Student> Data, string filePath)
        {
            var json = JsonSerializer.Serialize(Data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }
    }
}
