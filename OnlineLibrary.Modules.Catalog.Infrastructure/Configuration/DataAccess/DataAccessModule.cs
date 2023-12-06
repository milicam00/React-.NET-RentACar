using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineRentCar.BuildingBlocks.Application.Data;
using OnlineRentCar.BuildingBlocks.Application.Emails;
using OnlineRentCar.BuildingBlocks.Infrastructure;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscription;
using OnlineRentCar.Modules.Catalog.Domain.RentalCars.RentalCarSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Rentals.RentalSubscription;
using OnlineRentCar.Modules.Catalog.Infrastructure.Domain.Catalog.Cars;
using OnlineRentCar.Modules.Catalog.Infrastructure.Domain.Catalog.Clients;
using OnlineRentCar.Modules.Catalog.Infrastructure.Domain.Catalog.Locations;
using OnlineRentCar.Modules.Catalog.Infrastructure.Domain.Catalog.Owners;
using OnlineRentCar.Modules.Catalog.Infrastructure.Domain.Catalog.RentalCars;
using OnlineRentCar.Modules.Catalog.Infrastructure.Domain.Catalog.Rentals;

namespace OnlineRentCar.Modules.Catalog.Infrastructure.Configuration.DataAccess
{
    public class DataAccessModule : Autofac.Module
    {
        private readonly string _databaseConnectionString;
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly bool _enableSsl;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;
        private readonly ILoggerFactory _loggerFactory;
        public DataAccessModule(string databaseConnectionString, string smtpServer, int smtpPort, bool enableSsl, string smtpUsername, string smtpPassword, ILoggerFactory loggerFactory)
        {
            _databaseConnectionString = databaseConnectionString;
            _loggerFactory = loggerFactory;
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _enableSsl = enableSsl;
            _smtpUsername = smtpUsername;
            _smtpPassword = smtpPassword;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlConnectionFactory>()
                .As<ISqlConnectionFactory>()
                .WithParameter("connectionString", _databaseConnectionString)
                .InstancePerLifetimeScope();

            builder.RegisterType<SmtpEmailService>()
                .As<IEmailService>()
                .WithParameter("smtpServer", _smtpServer)
                .WithParameter("smtpPort", _smtpPort)
                .WithParameter("enableSsl", _enableSsl)
                .WithParameter("smtpUsername", _smtpUsername)
                .WithParameter("smtpPassword", _smtpPassword)

                .InstancePerLifetimeScope();

            builder
                .Register(c =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<CatalogContext>();
                    dbContextOptionsBuilder.UseSqlServer(_databaseConnectionString);

                    return new CatalogContext(dbContextOptionsBuilder.Options, _loggerFactory);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();


            builder.RegisterType<CarRepository>()
                .As<ICarRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<LocationRepository>()
               .As<ILocationRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<OwnerRepository>()
               .As<IOwnerRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<ClientRepository>()
               .As<IClientRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<RentalCarRepository>()
               .As<IRentalCarRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<RentalRepository>()
            .As<IRentalRepository>()
            .InstancePerLifetimeScope();


        }
    }
}
