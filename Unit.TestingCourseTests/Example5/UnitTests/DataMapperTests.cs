using System.Linq;
using Moq;
using NUnit.Framework;
using Unit.TestingCourseTests.Example5.Helpers;
using UnitTestingCourse.Examples.Example5.Exceptions;
using UnitTestingCourse.Examples.Example5.Good;

namespace Unit.TestingCourseTests.Example5.UnitTests
{
    [TestFixture]
    public class DataMapperTests
    {
        private DataMapper _dataMapper;
        private FileDataBuilder _fileDataBuilder;

        [SetUp]
        public void Init()
        {
            _dataMapper = new DataMapper();
            _fileDataBuilder = new FileDataBuilder();
        }

        [Test]
        public void MapDataToPersons_WhenFileWithDataIsEmpty_ReturnEmptyList()
        {
            // arrange
            var dataRows = _fileDataBuilder.Build();

            // act
            var result = _dataMapper.MapDataToPersons(dataRows);

            // assert
            Assert.That(result, Is.Empty);
        }

        [TestCase("1;2;3")]
        [TestCase("1;2;3;4;5")]
        public void MapDataToPersons_WhenRowHasIncorrectAmountOfData_ThrowSplittedDataValidatorException(string incorrectRow)
        {
            // arrange
            var dataRows = _fileDataBuilder
                .AddRowWithIncorrectStructure(incorrectRow)
                .Build();

            // assert
            Assert.Throws<SplittedDataValidatorException>(() =>
            {
                // act
                _dataMapper.MapDataToPersons(dataRows);
            });
        }

        [TestCase("a;b;c;0")]
        [TestCase("a;b;1;d")]
        [TestCase("a;b;c;d")]
        [TestCase("a;b;;0")]
        [TestCase("a;b;1;")]
        [TestCase("a;b;;")]
        public void MapDataToPersons_WhenAtLeastOneOfNonStringFieldsCantBeValidated_ThrowPersonValidationException(string incorrectRow)
        {
            // arrange
            var dataRows = _fileDataBuilder
                .AddRowWithIncorrectStructure(incorrectRow)
                .Build();

            // assert
            Assert.Throws<PersonValidationException>(() =>
            {
                // act
                _dataMapper.MapDataToPersons(dataRows);
            });
        }

        [TestCase(";b;1;0")]
        [TestCase("a;;1;0")]
        [TestCase(";;1;0")]
        public void MapDataToPersons_WhenAtLeastOneOfStringFieldsIsEmpty_ThrowPersonValidationException(string incorrectRow)
        {
            // arrange
            var dataRows = _fileDataBuilder
                .AddRowWithIncorrectStructure(incorrectRow)
                .Build();

            // assert
            Assert.Throws<MissingDataInRowException>(() =>
            {
                // act
                _dataMapper.MapDataToPersons(dataRows);
            });
        }

        [Test]
        public void MapDataToPersons_WhenAgeIsLessThan0_ThrowIncorrectAgeValueException()
        {
            // arrange
            var dataRows = _fileDataBuilder
                .AddCorrectRow(-1, false)
                .Build();

            // assert
            Assert.Throws<IncorrectAgeValueException>(() =>
            {
                // act
                _dataMapper.MapDataToPersons(dataRows);
            });
        }

        [Test]
        public void MapDataToPersons_WhenDataFromFileIsCorrect_ReturnNonEmptyListOfPerson()
        {
            // arrange
            var dataRows = _fileDataBuilder
                .AddCorrectRow(It.IsAny<int>(), It.IsAny<bool>())
                .AddCorrectRow(It.IsAny<int>(), It.IsAny<bool>())
                .AddCorrectRow(It.IsAny<int>(), It.IsAny<bool>())
                .Build();

            // act
            var result = _dataMapper.MapDataToPersons(dataRows);

            // assert
            Assert.That(result, Is.Not.Empty);
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(17)]
        public void MapDataToPersons_WhenRowContainsAgeBelow18_PersonIsNotFullCitizen(int age)
        {
            // arrange
            var dataRows = _fileDataBuilder
                .AddCorrectRow(age, It.IsAny<bool>())
                .Build();

            // act
            var result = _dataMapper.MapDataToPersons(dataRows);
            var person = result.First();

            // assert
            Assert.That(person.IsFullCitizen, Is.False);
        }

        [TestCase(18)]
        [TestCase(20)]
        [TestCase(100)]
        public void MapDataToPersons_WhenRowContainsAgeAtLeast18_PersonIsFullCitizen(int age)
        {
            // arrange
            var dataRows = _fileDataBuilder
                .AddCorrectRow(age, It.IsAny<bool>())
                .Build();

            // act
            var result = _dataMapper.MapDataToPersons(dataRows);
            var person = result.First();

            // assert
            Assert.That(person.IsFullCitizen, Is.True);
        }
    }
}