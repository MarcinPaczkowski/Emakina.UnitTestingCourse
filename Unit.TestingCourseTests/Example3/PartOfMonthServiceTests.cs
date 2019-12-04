using System;
using Moq;
using NUnit.Framework;
using Unit.TestingCourseTests.Example3.Helpers;
using UnitTestingCourse.Examples.Example3;

namespace Unit.TestingCourseTests.Example3
{
    [TestFixture]
    public class PartOfMonthServiceTests
    {
        private PartOfMonthService _partOfMonthService;
        private DateTimeGenerator _dateTimeGenerator;

        [SetUp]
        public void Init()
        {
            _partOfMonthService = new PartOfMonthService();
            _dateTimeGenerator = new DateTimeGenerator();
        }

        // arrange

        // act

        // asset
        [Test]
        public void Get_WhenMethodIsImplemented_DoNotThrowNotImplementedException()
        {
            // arrange

            // asset
            Assert.DoesNotThrow(() =>
            {
                // act
                _partOfMonthService.GetPartOfMonth(It.IsAny<DateTime>());
            });
        }

        [Test]
        public void Get_WhenDateIsFirstDayOfMonth_ReturnFirstDay()
        {
            // arrange
            var firstDay = _dateTimeGenerator.FirstDay(2019, 10);
            const PartOfMonth expected = PartOfMonth.FirstDay;

            // act
            var result = _partOfMonthService.GetPartOfMonth(firstDay);

            // asset
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Get_WhenDateIsLastDayOfMonth_ReturnLastDay()
        {
            // arrange
            var lastDate = _dateTimeGenerator.LastDay(2019, 10);
            const PartOfMonth expected = PartOfMonth.LastDay;

            // act
            var result = _partOfMonthService.GetPartOfMonth(lastDate);

            // asset
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Get_WhenDateIsInFirstPartOfMonth_ReturnLastDay()
        {
            // arrange
            var dateInFirstHalfOfMonth = _dateTimeGenerator.DateInFirstHalfOfMonth(2019, 10);
            const PartOfMonth expected = PartOfMonth.FirstHalf;

            // act
            var result = _partOfMonthService.GetPartOfMonth(dateInFirstHalfOfMonth);

            // asset
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Get_WhenDateIsInSecondPartOfMonth_ReturnLastDay()
        {
            // arrange
            var dateInSecondHalfOfMonth = _dateTimeGenerator.DateInSecondHalfOfMonth(2019, 10);
            const PartOfMonth expected = PartOfMonth.SecondHalf;

            // act
            var result = _partOfMonthService.GetPartOfMonth(dateInSecondHalfOfMonth);

            // asset
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}