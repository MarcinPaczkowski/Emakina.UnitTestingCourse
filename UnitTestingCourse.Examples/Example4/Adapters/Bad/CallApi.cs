using System;
using System.Net.Http;
using System.Threading.Tasks;
using UnitTestingCourse.Examples.Example4.Adapters.Good;

namespace UnitTestingCourse.Examples.Example4.Adapters.Bad
{
    public class CallApi
    {
        public async Task<object> GetMappedData()
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri("https://www.api.com"),
            };
            var response = await client.GetAsync("data");
            var data = await response.Content.ReadAsStringAsync();
            var serializedData = Serialize(data);
            var mappedDate = Map(serializedData);
            return mappedDate;
        }

        private object Serialize(string data)
        {
            throw new NotImplementedException();
        }

        private object Map(object serializedData)
        {
            throw new NotImplementedException();
        }
    }
}