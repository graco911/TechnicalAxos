using Autofac;
using TechnicalAxos.App.repositories;

namespace TechnicalAxos.App.helpers
{
    public class AppContainer
    {
        public static IContainer Container { get; private set; }

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UnitOfWork>().AsSelf();
            var container = builder.Build();
        }
    }
}
