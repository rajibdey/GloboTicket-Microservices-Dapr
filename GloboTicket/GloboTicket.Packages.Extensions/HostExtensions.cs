﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace GloboTicket.Packages.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<T>(this IHost webHost, ILogger logger) where T : DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var db = services.GetRequiredService<T>();
                    db.Database.Migrate();
                }
                catch (Exception ex)
                {
                    //var logger = services.GetRequiredService<ILogger<Program>>();
                    logger?.LogError(ex, "An error occurred while migrating the database.");
                }
            }
            return webHost;
        }
    }
}
