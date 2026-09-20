using Asal.StudentManagementSystem.Data;
using Asal.StudentManagementSystem.Interfaces;
using Asal.StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Asal.StudentManagementSystem.Services
{
    public class XmlStudentExporter : IExporterService<Student>
    {
        
        public void Export(List<Student> Data, string filePath)
        {
            var serializer = new XmlSerializer(typeof(List<Student>));

            using var writer = new StreamWriter(filePath);

            serializer.Serialize(writer, Data.ToList());
        }
    }
}
