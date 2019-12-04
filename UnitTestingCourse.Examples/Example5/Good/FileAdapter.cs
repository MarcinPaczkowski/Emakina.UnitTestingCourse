using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestingCourse.Examples.Example5.Good
{
    public class FileAdapter
    {
        public virtual async Task<List<string>> ReadAllLinesAsync(string path)
        {
            var data = await File.ReadAllLinesAsync(path);
            return data.ToList();
        }
    }
}