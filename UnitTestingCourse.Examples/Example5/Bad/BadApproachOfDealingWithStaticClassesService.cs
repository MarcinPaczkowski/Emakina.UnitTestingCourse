using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnitTestingCourse.Examples.Example5.Models;

namespace UnitTestingCourse.Examples.Example5.Bad
{
    public class BadApproachOfDealingWithStaticClassesService : IDealingWithStaticClassesService
    {
        public async Task<List<Person>> GetPersons()
        {
            var pathToFile = $"{Directory.GetCurrentDirectory()}\\example5\\data.txt";
            var dataRows = await File.ReadAllLinesAsync(pathToFile);
            var persons = Map(dataRows.ToList());
            return persons;
        }

        private static List<Person> Map(List<string> dataRows)
        {
            return dataRows
                .Select(r => new Person(r))
                .ToList();
        }
    }
}