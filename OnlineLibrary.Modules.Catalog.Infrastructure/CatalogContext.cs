using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineRentCar.Modules.Catalog.Domain.Cars.CarSubscriptions;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscriptions;
using OnlineRentCar.Modules.Catalog.Domain.Locations.LocationSubscriptions;
using OnlineRentCar.Modules.Catalog.Domain.Owners.OwnerSubscriptions;
using OnlineRentCar.Modules.Catalog.Domain.RentalCars.RentalCarSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Rentals.RentalSubscription;
using System.Reflection.PortableExecutable;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineRentCar.Modules.Catalog.Infrastructure
{
    public class CatalogContext : DbContext
    {
        
        public DbSet<Car> Cars { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<RentalCar> RentalCars { get; set; }

        private readonly ILoggerFactory _loggerFactory;

        public CatalogContext(DbContextOptions<CatalogContext> options, ILoggerFactory loggerFactory)
           : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = @"Server=DESKTOP-VCC3D1R\SQLEXPRESS01;Database=ProjekatDB;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;";
            optionsBuilder.UseSqlServer(connection, b=>b.MigrationsAssembly("OnlineRentCar.API"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
           => modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
