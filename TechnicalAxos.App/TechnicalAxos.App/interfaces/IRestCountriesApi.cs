using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalAxos.App.models;

namespace TechnicalAxos.App.interfaces
{
    public interface IRestCountriesApi
    {
        [Get("/v3.1/all?fields=name,flags")]
        Task<List<CountryData>> GetAllCountries();
    }
}
