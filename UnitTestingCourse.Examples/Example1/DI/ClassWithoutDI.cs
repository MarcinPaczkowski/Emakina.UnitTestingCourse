namespace UnitTestingCourse.Examples.Example1.DI
{
    public class ClassWithoutDI: ITestClass
    {
        public void TestMethod()
        {
            var testService = new TestService();
            testService.DoSth();
        }
    }
}