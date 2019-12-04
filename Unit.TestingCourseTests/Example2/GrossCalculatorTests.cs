using Moq;
using NUnit.Framework;
using UnitTestingCourse.Examples.Example2;

namespace Unit.TestingCourseTests.Example2
{
    [TestFixture]
    public class GrossCalculatorTests
    {
        private Mock<CustomLogger> _loggerMock;
        private Calculator _calculator;

        [SetUp]
        public void Init()
        {
            _loggerMock = new Mock<CustomLogger>();
            _calculator = new Calculator();
        }

        [Test]
        public void Calculate_WhenTaxIsNegative_ThrowValueLessThenZeroException()
        {
            // arrange
            var netValue = It.IsAny<decimal>();
            const int tax = -1;
            var grossCalculator = new GrossCalculator(_calculator, _loggerMock.Object);            

            // assert
            Assert.Throws<ValueLessThenZeroException>(() =>
            {
                // act
                grossCalculator.Calculate(netValue, tax);
            });
        }

        [Test]
        public void Calculate_WhenTaxIsEqualToZero_ReturnNetValue()
        {
            // arrange
            const decimal netValue = 1;
            const int tax = 0;
            var grossCalculator = new GrossCalculator(_calculator, _loggerMock.Object);

            // act
            var result = grossCalculator.Calculate(netValue, tax);

            // assert
            Assert.That(result, Is.EqualTo(netValue));
        }

        [Test]
        public void Calculate_WhenTaxIsBiggerThanZeroAndMessageIsLoggedToDb_LogToConsoleIsCalledWithCorrectId()
        {
            // arrange
            const int messageId = 2;
            const int netValue = 1;
            const int tax = 1;

            _loggerMock
                .Setup(m => m.LogToDatabase(It.IsAny<string>()))
                .Returns(messageId);
            var grossCalculator = new GrossCalculator(_calculator, _loggerMock.Object);

            // act
            grossCalculator.Calculate(netValue, tax);

            // assert
            _loggerMock.Verify(m => m.LogToConsole(messageId.ToString()), Times.Once);
        }

        [TestCase(100, 17, 117)]
        [TestCase(100, 19, 119)]
        [TestCase(100, 32, 132)]
        public void Calculate_WhenTaxIsBiggerThanZero_ReturnCalculatedValue(decimal netValue, int tax, decimal expectedValue)
        {
            // arrange
            var grossCalculator = new GrossCalculator(_calculator, _loggerMock.Object);

            // act
            var result = grossCalculator.Calculate(netValue, tax);

            // assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }
    }
}