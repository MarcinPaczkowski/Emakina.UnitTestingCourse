using System;
using Moq;
using NUnit.Framework;
using UnitTestingCourse.Examples.Example2;

namespace Unit.TestingCourseTests.Example2
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Init()
        {
            _calculator = new Calculator();
        }

        // MethodUnderTest naming convention - TestedMethod_Case/Condition_ExpectedValue

        [Test]
        public void Multiplication_ValuesAreEqualsTo2And3_Return6()
        {
            // arrange
            const decimal a = 2;
            const decimal b = 3;
            const decimal expectedValue = 6;

            // act
            var result = _calculator.Multiplication(a, b);

            // assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Subtraction_WhenFirstArgIsLessThenSecond_ReturnNegativeValue()
        {
            // arrange
            const decimal a = 2;
            const decimal b = 3;

            // act
            var result = _calculator.Subtraction(a, b);

            // assert
            Assert.That(result, Is.Negative);
        }

        [Test]
        public void Add_WhenParametersArePositive_ReturnPositiveValue()
        {
            // arrange
            const decimal a = 1.5m;
            const decimal b = 1;

            // act
            var result = _calculator.Add(a, b);

            // assert
            Assert.That(result, Is.Positive);
        }

        [Test]
        public void Division_WhenSecondParameterIsEqualToZero_ThrowDivideByZeroException()
        {
            // arrange
            var a = It.IsAny<decimal>();
            const decimal b = 0;
            
            // assert
            Assert.Throws<DivideByZeroException>(() =>
            {
                // act
                _calculator.Division(a, b);
            });
        }

        [TestCase(10, 2, 5)]
        [TestCase(2, 10, 0.2)]
        public void Division_WhenSecondParameterIsNotEqualToZero_ReturnCalculatedValue(decimal a, decimal b, decimal expectedValue)
        {
            // arrange

            // act
            var result = _calculator.Division(a, b);

            // assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }
    }
}