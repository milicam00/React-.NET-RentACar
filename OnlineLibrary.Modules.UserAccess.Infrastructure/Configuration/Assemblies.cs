using OnlineRentCar.Modules.UserAccess.Application.Configuration.Commands;
using System.Reflection;

namespace OnlineRentCar.Modules.UserAccess.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(InternalCommandBase).Assembly;
    }
}
