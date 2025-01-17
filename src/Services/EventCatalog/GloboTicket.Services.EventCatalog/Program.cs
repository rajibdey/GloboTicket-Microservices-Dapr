using GloboTicket.Packages.Extensions;
using GloboTicket.Services.EventCatalog.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace GloboTicket.Services.EventCatalog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().MigrateDatabase<EventCatalogDbContext>(null).Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
