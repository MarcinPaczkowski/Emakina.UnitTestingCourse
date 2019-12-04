using System.Collections.Generic;
using System.Threading.Tasks;
using UnitTestingCourse.Examples.Example5.Models;

namespace UnitTestingCourse.Examples.Example5
{
    public interface IDealingWithStaticClassesService
    {
        Task<List<Person>> GetPersons();
    }
}