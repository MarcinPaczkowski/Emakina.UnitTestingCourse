using System;

namespace UnitTestingCourse.Examples.Example5.Exceptions
{
    public class SplittedDataValidatorException : Exception
    {
        public SplittedDataValidatorException() : base("Incorrect amount of data in a row!")
        {
            
        }
    }
}