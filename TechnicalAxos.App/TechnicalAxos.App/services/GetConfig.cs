using Refit;
using TechnicalAxos.App.interfaces;

namespace TechnicalAxos.App.services
{
    public static class GetConfig
    {
        private static string service = helpers.Utils.Service;

        public static IRestCountriesApi GetServicesAPI()
        {
            return RestService.For<IRestCountriesApi>(service, new RefitSettings
            {
                Buffered = true
            });
        }
    }
}
