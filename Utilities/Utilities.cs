using System;
using System.Collections.Generic;
using System.Text;

namespace Asal.StudentManagementSystem.Utilities
{
    public static class Utilities
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

        public static double AskForGrade()
        {
            double grade;

            do
            {
                Console.Write("Enter your grade (0-100): ");
            } while (!double.TryParse(Console.ReadLine(), out grade) || !grade.IsBetween(MinAge, MaxAge));

            return grade;
        }
    }
}
