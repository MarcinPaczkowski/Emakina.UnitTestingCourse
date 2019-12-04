using System;
using System.Reflection;

namespace UnitTestingCourse.Examples.Example5.Exceptions
{
    public class PersonValidationException : Exception
    {
        public PersonValidationException(string fieldName, string fieldValue, MemberInfo type) : 
            base($"Field {fieldName}: {fieldValue} has incorrect type!. It should be type of {type.Name}")
        {
            
        }
    }
}