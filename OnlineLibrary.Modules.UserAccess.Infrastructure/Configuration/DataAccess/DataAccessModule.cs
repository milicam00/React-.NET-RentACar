﻿using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineRentCar.BuildingBlocks.Application.Data;
using OnlineRentCar.BuildingBlocks.Application.Emails;
using OnlineRentCar.BuildingBlocks.Infrastructure;
using OnlineRentCar.Modules.UserAccess.Domain.RefreshTokens;
using OnlineRentCar.Modules.UserAccess.Domain.Users;
using OnlineRentCar.Modules.UserAccess.Infrastructure.Domain.RefreshTokens;
using OnlineRentCar.Modules.UserAccess.Infrastructure.Domain.Users;

namespace OnlineRentCar.Modules.UserAccess.Infrastructure.Configuration.DataAccess
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
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<UserAccessContext>();
                    dbContextOptionsBuilder.UseSqlServer(_databaseConnectionString);

                    return new UserAccessContext(dbContextOptionsBuilder.Options, _loggerFactory);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RefreshTokenRepository>()
                 .As<IRefreshTokenRepository>()
                 .InstancePerLifetimeScope();
           

        }
    }
}
