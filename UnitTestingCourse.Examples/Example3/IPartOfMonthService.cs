using System;

namespace UnitTestingCourse.Examples.Example3
{
    public interface IPartOfMonthService
    {
        PartOfMonth GetPartOfMonth(DateTime dateTime);
    }
}