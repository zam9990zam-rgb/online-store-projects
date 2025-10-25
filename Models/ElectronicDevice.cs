using System;

namespace IPG_OOP_Project.Core
{
    public static class DataValidator
    {
        public static bool IsValidString(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        public static bool IsPositive(double number)
        {
            return number > 0;
        }

        public static bool IsFutureDate(DateTime date)
        {
            return date > DateTime.Now;
        }
    }
}
