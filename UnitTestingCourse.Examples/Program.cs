using System;
using System.Threading.Tasks;
using UnitTestingCourse.Examples.Example5;
using UnitTestingCourse.Examples.Example5.Good;

namespace UnitTestingCourse.Examples
{
    class Program
    {
        private static readonly IDealingWithStaticClassesService DealingWithStaticClassesService = 
            new GoodApproachOfDealingWithStaticClassesService(new FileAdapter(), new DataMapper(), new PathToDataFile());
        static async Task Main()
        {
            Console.WriteLine("Start...");
            await DealingWithStaticClassesService.GetPersons();
            Console.WriteLine("Stop...");
        }
    }
}
