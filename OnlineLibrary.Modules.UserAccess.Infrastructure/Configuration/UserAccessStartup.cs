using Autofac;
using MediatR;
using OnlineRentCar.BuildingBlocks.Application;
using OnlineRentCar.BuildingBlocks.Infrastructure.EventBus;
using OnlineRentCar.Modules.UserAccess.Infrastructure.Configuration.DataAccess;
using OnlineRentCar.Modules.UserAccess.Infrastructure.Configuration.EventBus;
using OnlineRentCar.Modules.UserAccess.Infrastructure.Configuration.Mediation;
using OnlineRentCar.Modules.UserAccess.Infrastructure.Configuration.Processing;
using Serilog.Extensions.Logging;
using System.Reflection;
using ILogger = Serilog.ILogger;
namespace OnlineRentCar.Modules.UserAccess.Infrastructure.Configuration
{
    public class UserAccessStartup
    {
        private static IContainer _container;

        public static void Initialize(
            //IContainer container,
            string connectionString, string smtpServer, int smtpPort, bool enableSsl, string smtpUsername, string smtpPassword,
            IExecutionContextAccessor executionContextAccessor,
            Serilog.ILogger logger,
            IEventsBus eventsBus
           )
        {
           
            ConfigureContainer(connectionString, smtpServer, smtpPort, enableSsl, smtpUsername, smtpPassword, logger, executionContextAccessor, eventsBus);
           
        }

        private static void ConfigureContainer(
            string connectionString,
              string smtpServer,
            int smtpPort,
            bool enableSsl,
            string smtpUsername,
            string smtpPassword,
            ILogger logger,
            IExecutionContextAccessor executionContextAccessor,
            IEventsBus eventsBus)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            var loggerFactory = new SerilogLoggerFactory(logger);

            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new EventsBusModule(eventsBus));
            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, smtpServer, smtpPort, enableSsl, smtpUsername, smtpPassword, loggerFactory));

            //containerBuilder.RegisterModule(new QuartzModule());
            containerBuilder.RegisterInstance(executionContextAccessor);

       

            _container = containerBuilder.Build();
            UserAccessCompositionRoot.SetContainer(_container);

        }
    }
}
