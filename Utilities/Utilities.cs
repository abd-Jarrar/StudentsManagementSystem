using System;
using System.Collections.Generic;
using System.Text;

namespace Asal.StudentManagementSystem.Utilities
{
    public static class Utilities
    {
        public static bool IsBetween(this int value,int min,int max)
        {
            if (value > max || value < min)
                return false;
            else
                return true;
        }
    }
}
