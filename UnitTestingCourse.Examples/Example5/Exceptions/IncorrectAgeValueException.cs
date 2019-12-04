using System;

namespace UnitTestingCourse.Examples.Example5.Exceptions
{
    public class IncorrectAgeValueException : Exception
    {
        public IncorrectAgeValueException() : base("Age can't be less than 0!")
        {
            
        }
    }
}