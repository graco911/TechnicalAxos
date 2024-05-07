using TechnicalAxos.App.services;

namespace TechnicalAxos.App.repositories
{
    public class UnitOfWork
    {
        private ServiceRepository _serviceRepo;

        public ServiceRepository ServiceRepo
        {
            get
            {
                if (_serviceRepo == null)
                {
                    _serviceRepo = new ServiceRepository(GetConfig.GetServicesAPI());
                }
                return _serviceRepo;
            }
        }
    }
}
