using System.Collections.Generic;
using System.Linq;
using UnitTestingCourse.Examples.Example5.Exceptions;

namespace UnitTestingCourse.Examples.Example5.Models
{
    public class PersonRaw
    {
        public PersonRaw(string row)
        {
            var splittedData = TryToSplitData(row);
            var firstName = splittedData[0];
            var lastName = splittedData[1];
            var age = splittedData[2];
            var hasJob = splittedData[3];

            FirstName = TryToGetName(firstName);
            LastName = TryToGetName(lastName);
            Age = TryToGetAge(age);
            HasJob = TryToGetHasJob(hasJob);
        }

        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }
        public bool HasJob { get; }

        private static List<string> TryToSplitData(string row)
        {
            var splittedData = row.Split(";").ToList();
            if (splittedData.Count != 4)
                throw new SplittedDataValidatorException();
            return splittedData;
        }

        private static string TryToGetName(string name)
        {
            return name.Length > 0 ? name : throw new MissingDataInRowException();
        }

        private static bool TryToGetHasJob(string hasJob)
        {
            return int.TryParse(hasJob, out var parsedHasJob) ?
                parsedHasJob == 1 :
                throw new PersonValidationException("HasJob", hasJob, typeof(int));
        }

        private static int TryToGetAge(string age)
        {
            var isParsed =  int.TryParse(age, out var parsedAge); 
            if (!isParsed)
                throw new PersonValidationException("Age", age, typeof(int));
            if (parsedAge < 0)
                throw new IncorrectAgeValueException();
            return parsedAge;
        }
    }
}