using System;

namespace UnitTestingCourse.Examples.Example2
{
    public class CustomLogger
    {
        public virtual int LogToDatabase(string message)
        {
            // log message to db
            // return id of added record
            return new Random(1).Next();
        }

        public virtual void LogToConsole(string message)
        {
            Console.WriteLine($"Message: {message}");
        }
    }
}