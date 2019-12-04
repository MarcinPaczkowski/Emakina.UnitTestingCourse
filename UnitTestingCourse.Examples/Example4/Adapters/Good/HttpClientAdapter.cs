using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UnitTestingCourse.Examples.Example4.Adapters.Good
{
    public class HttpClientAdapter
    {
        public virtual async Task<object> FetchDataFromApi()
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri("https://www.api.com"),
            };
            var response = await client.GetAsync("data");
            var data = await response.Content.ReadAsStringAsync();
            var serializedData = Serialize(data);
            return serializedData;
        }

        private object Serialize(string data)
        {
            throw new NotImplementedException();
        }
    }
}