namespace UnitTestingCourse.Examples.Example1.DI
{
    public class ClassWithDI : ITestClass
    {
        private readonly TestService _testService;
        // inject specific instance of class
        public ClassWithDI(TestService testService)
        {
            _testService = testService;
        }
        public virtual void TestMethod()
        {
            _testService.DoSth();
        }
    }
}