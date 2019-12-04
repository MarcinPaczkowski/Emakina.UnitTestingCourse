using System.IO;

namespace UnitTestingCourse.Examples.Example5.Good
{
    public class PathToDataFile
    {
        public virtual string Get()
        {
            return $"{Directory.GetCurrentDirectory()}\\example5\\data.txt";
        }
    }
}