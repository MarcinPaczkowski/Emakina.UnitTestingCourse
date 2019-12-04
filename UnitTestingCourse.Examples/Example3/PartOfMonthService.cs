using System;

namespace UnitTestingCourse.Examples.Example3
{
    public class PartOfMonthService : IPartOfMonthService
    {
        public PartOfMonth GetPartOfMonth(DateTime dateTime)
        {
            if (dateTime.IsFirstDayOfMonth())
                return PartOfMonth.FirstDay;
            if (dateTime.IsLastDayOfMonth())
                return PartOfMonth.LastDay;
            if (dateTime.IsInFirstHalfOfMonth())
                return PartOfMonth.FirstHalf;
            if (dateTime.IsInSecondHalfOfMonth())
                return PartOfMonth.SecondHalf;

            return PartOfMonth.NotDefined;
        }
    }
}