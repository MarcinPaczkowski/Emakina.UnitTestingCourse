using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Unit.TestingCourseTests.Example5.Helpers;
using UnitTestingCourse.Examples.Example5.Good;

namespace Unit.TestingCourseTests.Example5.IntegrationTests
{
    [TestFixture]
    public class DealingWithStaticClassesServiceIntegrationTests
    {
        private FileDataBuilder _fileDataBuilder;
        private Mock<FileAdapter> _mockFileAdapter;
        private DataMapper _dataMapper;
        private PathToDataFile _pathToDataFile;

        [SetUp]
        public void Init()
        {
            _fileDataBuilder = new FileDataBuilder();
            _mockFileAdapter = new Mock<FileAdapter>();
            _dataMapper = new DataMapper();
            _pathToDataFile = new PathToDataFile();
        }

        [Test]
        public void GetPersons_WhenDataFromFileIsIncorrect_ThrowAnyException()
        {
            // arrange
            var dataRows = _fileDataBuilder
                .AddCorrectRow(It.IsAny<int>(), It.IsAny<bool>())
                .AddRowWithIncorrectStructure()
                .Build();

            _mockFileAdapter
                .Setup(m => m.ReadAllLinesAsync(It.IsAny<string>()))
                .ReturnsAsync(() => dataRows);

            // sut - system under test
            var sut = new GoodApproachOfDealingWithStaticClassesService(_mockFileAdapter.Object, _dataMapper, _pathToDataFile);

            // assert
            Assert.That(async () => await sut.GetPersons(), Throws.Exception);
        }

        [Test]
        public async Task GetPersons_WhenDataFromFileIsCorrect_ReturnNonEmptyListOfPerson()
        {
            // arrange
            var dataRows = _fileDataBuilder
                .AddCorrectRow(It.IsAny<int>(), It.IsAny<bool>())
                .AddCorrectRow(It.IsAny<int>(), It.IsAny<bool>())
                .AddCorrectRow(It.IsAny<int>(), It.IsAny<bool>())
                .AddCorrectRow(It.IsAny<int>(), It.IsAny<bool>())
                .Build();

            _mockFileAdapter
                .Setup(m => m.ReadAllLinesAsync(It.IsAny<string>()))
                .ReturnsAsync(() => dataRows);

            // sut - system under test
            var sut = new GoodApproachOfDealingWithStaticClassesService(_mockFileAdapter.Object, _dataMapper, _pathToDataFile);

            // act
            var result = await sut.GetPersons();

            // assert
            Assert.That(result, Is.Not.Empty);
        }
    }
}