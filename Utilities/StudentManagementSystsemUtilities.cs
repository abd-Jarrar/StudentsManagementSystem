using Asal.StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asal.StudentManagementSystem.Utilities
{
    public static class StudentManagementSystsemUtilities
    {
        const int MaxGrade = 100;
        const int MinGrade = 0;
        const int MaxAge = 17;
        const int MinAge = 3;
        public static bool IsBetween(this int value,int min,int max)
        {
            if (value > max || value < min)
                return false;
            else
                return true;
        }

        public static bool IsBetween(this double value, int min, int max)
        {
            if (value > max || value < min)
                return false;
            else
                return true;
        }
        public static int AskForAge()
        {
            int age;

            do
            {
                Console.Write("Enter your age (3-17): ");
            } while (!int.TryParse(Console.ReadLine(), out age) || !age.IsBetween(MinAge, MaxAge));

            return age;
        }

        public static int AskForNumberBetween(int min, int max)
        {
            while (true)
            {
                Console.Write($"Enter a number between {min} and {max}: ");

                if (int.TryParse(Console.ReadLine(), out int number) &&
                    number >= min && number <= max)
                {
                    return number;
                }

                Console.WriteLine($"Please enter a valid number between {min} and {max}.");
            }
        }

        public static double AskForGrade()
        {
            double grade;

            do
            {
                Console.Write("Enter your grade (0-100): ");
            } while (!double.TryParse(Console.ReadLine(), out grade) || !grade.IsBetween(MinAge, MaxAge));

            return grade;
        }

        public static Guid AskForGuid()
        {
            Guid guid;

            do
            {
                Console.Write("Enter Student Id: ");
            } while (!Guid.TryParse(Console.ReadLine(), out guid));

            return guid;
        }

        public static string AskForName()
        {
            Console.Write("Enter your name: ");
            return Console.ReadLine()!;
        }

        public static void PrintStudents(List<Student> students)
        {
            Console.WriteLine($"{"ID",-45} {"Name",-20} {"Age",-5} {"Grade",-10}");
            Console.WriteLine(new string('-', 85));

            foreach (var student in students)
            {
                Console.WriteLine(
                    $"{student.Id,-45} {student.Name,-20} {student.Age,-5} {student.Grade,-10:F2}");
            }
        }

        public static void PrintStudent(Student student)
        {
            Console.WriteLine($"{"ID",-45} {"Name",-20} {"Age",-5} {"Grade",-10}");
            Console.WriteLine(new string('-', 85));

            Console.WriteLine(
                $"{student.Id,-45} {student.Name,-20} {student.Age,-5} {student.Grade,-10:F2}");
        }
    }
}
