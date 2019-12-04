namespace UnitTestingCourse.Examples.Example5.Models
{
    public class Person
    {
        public Person(string row)
        {
            var personRaw = new PersonRaw(row);

            FirstName = personRaw.FirstName;
            LastName = personRaw.LastName;
            Age = personRaw.Age;
            HasJob = personRaw.HasJob;
        }

        public Person(string firstName, string lastName, int age, bool hasJob)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HasJob = hasJob;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; set; }
        public bool IsFullCitizen => Age >= 18;
        public bool HasJob { get; }
    }
}