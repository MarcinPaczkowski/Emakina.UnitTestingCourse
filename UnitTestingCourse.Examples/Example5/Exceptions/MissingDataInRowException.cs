using System;

namespace UnitTestingCourse.Examples.Example5.Exceptions
{
    public class MissingDataInRowException : Exception
    {
        public MissingDataInRowException() : base("Field cannot be empty!")
        {
            
        }
    }
}