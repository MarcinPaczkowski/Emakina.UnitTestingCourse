using System;
using System.Threading.Tasks;

namespace UnitTestingCourse.Examples.Example4.Adapters.Good
{
    public class CallApi
    {
        private readonly HttpClientAdapter _httpClientAdapter;

        public CallApi(HttpClientAdapter httpClientAdapter)
        {
            _httpClientAdapter = httpClientAdapter;
        }
        public async Task<object> GetMappedData()
        {
            var serializedData = await _httpClientAdapter.FetchDataFromApi();
            var mappedDate = Map(serializedData);
            return mappedDate;
        }

        private object Map(object serializedData)
        {
            throw new NotImplementedException();
        }
    }
}