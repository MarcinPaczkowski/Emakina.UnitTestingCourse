namespace UnitTestingCourse.Examples.Example1.DI
{
    public class ClassWithDIAndInterface: ITestClass
    {
        private readonly ITestService _testService;
        // inject specific instance, that implements ITestService
        public ClassWithDIAndInterface(ITestService testService)
        {
            _testService = testService;
        }
        public void TestMethod()
        {
            _testService.DoSth();
        }
    }
}