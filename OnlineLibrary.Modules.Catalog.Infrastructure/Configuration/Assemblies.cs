﻿using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using System.Reflection;

namespace OnlineRentCar.Modules.Catalog.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(InternalCommandBase).Assembly;
    }
}
