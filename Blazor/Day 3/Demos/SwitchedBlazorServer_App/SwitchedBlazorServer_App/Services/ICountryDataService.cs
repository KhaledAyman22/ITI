using SharedLibrary;

namespace BlazorWebAssembly_43.Services
{
    public interface ICountryDataService
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetCountryDetails(int countryId);
    }
}
