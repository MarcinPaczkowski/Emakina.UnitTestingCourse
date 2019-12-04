using System.Collections.Generic;
using System.Linq;
using UnitTestingCourse.Examples.Example5.Models;

namespace UnitTestingCourse.Examples.Example5.Good
{
    public class DataMapper
    {
        public virtual List<Person> MapDataToPersons(List<string> dataRows)
        {
            return dataRows
                .Select(row => new Person(row))
                .ToList();
        }
    }
}