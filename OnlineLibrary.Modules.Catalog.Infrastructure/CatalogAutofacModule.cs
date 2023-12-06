using Autofac;
using OnlineLibary.Modules.Catalog.Application.Contracts;

namespace OnlineRentCar.Modules.Catalog.Infrastructure
{
    public class CatalogAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CatalogModule>()
                .As<ICatalogModule>()
                .InstancePerLifetimeScope();
        }
    }
}
