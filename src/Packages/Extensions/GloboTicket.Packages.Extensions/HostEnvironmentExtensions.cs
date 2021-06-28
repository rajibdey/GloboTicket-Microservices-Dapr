using Microsoft.Extensions.Hosting;

namespace GloboTicket.Packages.Extensions
{
    public static class HostEnvironmentExtensions
    {
        public static bool IsDocker(this IHostEnvironment hostEnvironment) =>
            "docker" == hostEnvironment.EnvironmentName.ToLower();
        public static bool IsTest(this IHostEnvironment hostEnvironment) =>
            "test" == hostEnvironment.EnvironmentName.ToLower();
    }
}
