using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TechnicalAxos.App.interfaces;
using TechnicalAxos.App.models;

namespace TechnicalAxos.App.repositories
{
    public class ServiceRepository
    {
        private readonly IRestCountriesApi _context;

        public event EventHandler<List<CountryData>> CountrySuccess;
        public event EventHandler<string> CountryError;

        public ServiceRepository(IRestCountriesApi context)
        {
            _context = context;
        }

        public async Task GetCountries()
        {
            var response = await _context.GetAllCountries();

            try
            {
                if (response != null)
                {
                    CountrySuccess.Invoke(this, response);
                }
                else
                {
                    CountryError.Invoke(this, "No se ha podido obtener la información");
                }
            }
            catch (HttpRequestException ex)
            {
                CountryError?.Invoke(this, ex.Message);
            }
            catch (Exception ex)
            {
                CountryError?.Invoke(this, ex.Message);
            }
        }
    }
}
