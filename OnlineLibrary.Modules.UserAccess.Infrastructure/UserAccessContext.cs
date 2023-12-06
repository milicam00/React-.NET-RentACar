using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineRentCar.Modules.UserAccess.Domain.Users;
using OnlineRentCar.Modules.UserAccess.Infrastructure.Domain.RefreshTokens;
using OnlineRentCar.Modules.UserAccess.Infrastructure.Domain.Users;

namespace OnlineRentCar.Modules.UserAccess.Infrastructure
{
    public class UserAccessContext : DbContext
    {
        public DbSet<User> Users { get; set; }
       
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        private readonly ILoggerFactory _loggerFactory;

        public UserAccessContext (DbContextOptions options,ILoggerFactory loggerFactory)
            :base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = @"Server=DESKTOP-VCC3D1R\SQLEXPRESS01;Database=ProjekatDB;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;";
            optionsBuilder.UseSqlServer(connection, b => b.MigrationsAssembly("OnlineRentCar.API"));
        }
    }
}
