using Asal.StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asal.StudentManagementSystem.Interfaces
{
    public interface IExporterService<T>
    {
        public void Export(List<T> Data, string filePath);
    }
}
