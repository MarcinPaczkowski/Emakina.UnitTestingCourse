namespace UnitTestingCourse.Examples.Example1.Static
{
    public class CallTestHelper
    {
        private readonly TestHelper _testHelper;

        public CallTestHelper(TestHelper testHelper)
        {
            _testHelper = testHelper;
        }

        public void CallDI()
        {
            var result = _testHelper.Help("test");
        }

        public void CallStatic()
        {
            var result = TestStaticHelper.Help("test");
        }
    }
}