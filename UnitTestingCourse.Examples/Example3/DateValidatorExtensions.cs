using System;

namespace UnitTestingCourse.Examples.Example3
{
    public static class DateValidatorExtensions
    {
        public static bool IsFirstDayOfMonth(this DateTime dateTime)
        {
            return dateTime.Day == 1;
        }

        public static bool IsLastDayOfMonth(this DateTime dateTime)
        {
            var lastDayOfCurrentMonth = GetLastDayOfCurrentMonth(dateTime);
            return dateTime.Day == lastDayOfCurrentMonth.Day;
        }

        public static bool IsInFirstHalfOfMonth(this DateTime dateTime)
        {
            var lastDayOfCurrentMonth = GetLastDayOfCurrentMonth(dateTime);
            var lastDayOfFirstHalf = new DateTime(lastDayOfCurrentMonth.Year, lastDayOfCurrentMonth.Month, lastDayOfCurrentMonth.Day / 2);
            return dateTime.Day > 1 && dateTime.Day <= lastDayOfFirstHalf.Day;
        }
        public static bool IsInSecondHalfOfMonth(this DateTime dateTime)
        {
            var lastDayOfCurrentMonth = GetLastDayOfCurrentMonth(dateTime);
            var firstDayOfSecondHalf = new DateTime(lastDayOfCurrentMonth.Year, lastDayOfCurrentMonth.Month, lastDayOfCurrentMonth.Day / 2 + 1);
            return dateTime.Day >= firstDayOfSecondHalf.Day && dateTime.Day < lastDayOfCurrentMonth.Day;
        }

        private static DateTime GetLastDayOfCurrentMonth(DateTime dateTime)
        {
            var daysInMonth = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
            return new DateTime(dateTime.Year, dateTime.Month, daysInMonth);
        }
    }
}