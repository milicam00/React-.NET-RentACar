using Autofac;
using OnlineRentCar.Modules.UserAccess.Application.Contracts;

namespace OnlineRentCar.Modules.UserAccess.Infrastructure
{
    public class UserAccessAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserAccessModule>()
                .As<IUserAccessModule>()
                .InstancePerLifetimeScope();
        }
    }
}
