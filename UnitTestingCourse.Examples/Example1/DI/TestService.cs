using System;

namespace UnitTestingCourse.Examples.Example1.DI
{
    public class TestService : ITestService
    {
        public virtual void DoSth()
        {
            Console.WriteLine("Do sth");
        }
    }
}