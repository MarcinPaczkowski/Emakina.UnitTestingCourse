using System;

namespace Unit.TestingCourseTests.Example3.Helpers
{
    public class DateTimeGenerator
    {
        public DateTime FirstDay(int year, int month)
        {
            return new DateTime(year, month, 1);
        }

        public DateTime LastDay(int year, int month)
        {
            var daysInMonth = DateTime.DaysInMonth(year, month);
            var lastDay = new DateTime(year, month, daysInMonth);
            return lastDay;
        }

        public DateTime DateInFirstHalfOfMonth(int year, int month)
        {
            var lastDay = LastDay(year, month);
            var dateInFirstHalfOfMonth = new DateTime(year, month, lastDay.Day / 2 - 1);
            return dateInFirstHalfOfMonth;
        }

        public DateTime DateInSecondHalfOfMonth(int year, int month)
        {
            var lastDay = LastDay(year, month);
            var dateInSecondHalfOfMonth = new DateTime(year, month, lastDay.Day / 2 + 1);
            return dateInSecondHalfOfMonth;
        }
    }
}