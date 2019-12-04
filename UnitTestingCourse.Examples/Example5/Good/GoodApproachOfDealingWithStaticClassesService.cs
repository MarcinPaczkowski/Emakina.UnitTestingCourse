using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnitTestingCourse.Examples.Example5.Models;

namespace UnitTestingCourse.Examples.Example5.Good
{
    public class GoodApproachOfDealingWithStaticClassesService : IDealingWithStaticClassesService
    {
        private readonly FileAdapter _fileAdapter;
        private readonly DataMapper _dataMapper;
        private readonly PathToDataFile _pathToDataFile;

        public GoodApproachOfDealingWithStaticClassesService(
            FileAdapter fileAdapter, 
            DataMapper dataMapper,
            PathToDataFile pathToDataFile)
        {
            _fileAdapter = fileAdapter;
            _dataMapper = dataMapper;
            _pathToDataFile = pathToDataFile;
        }

        public async Task<List<Person>> GetPersons()
        {
            var path = _pathToDataFile.Get();
            var dataRows = await _fileAdapter.ReadAllLinesAsync(path);
            var persons = _dataMapper.MapDataToPersons(dataRows);
            return persons;
        }
    }
}