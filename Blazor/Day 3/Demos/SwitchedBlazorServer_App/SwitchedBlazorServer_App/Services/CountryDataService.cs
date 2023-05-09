using SharedLibrary;
using System.Net.Http.Json;

namespace BlazorWebAssembly_43.Services
{
    public class CountryDataService : ICountryDataService
    {
        public HttpClient HttpClient { get; }
        public CountryDataService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await HttpClient.GetFromJsonAsync<IEnumerable<Country>>("/api/Country");
        }

        public async Task<Country> GetCountryDetails(int countryId)
        {
            return await HttpClient.GetFromJsonAsync<Country>("/api/Country/" + countryId);
        }
    }
}
