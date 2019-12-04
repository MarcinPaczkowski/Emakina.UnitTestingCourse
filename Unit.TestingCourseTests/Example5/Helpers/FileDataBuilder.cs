using System.Collections.Generic;

namespace Unit.TestingCourseTests.Example5.Helpers
{
    public class FileDataBuilder
    {
        private readonly List<string> _fileData;

        public FileDataBuilder()
        {
            _fileData = new List<string>();
        }

        public FileDataBuilder AddCorrectRow(int age, bool hasJob)
        {
            var row = $"firstName;lastName;{age};{(hasJob ? 1 : 0)}";
            _fileData.Add(row);
            return this;
        }
        public FileDataBuilder AddRowWithIncorrectStructure()
        {
            var row = ";;;;";
            _fileData.Add(row);
            return this;
        }

        public FileDataBuilder AddRowWithIncorrectStructure(string incorrectRow)
        {
            var row = incorrectRow;
            _fileData.Add(row);
            return this;
        }

        public List<string> Build()
        {
            return _fileData;
        }
    }
}