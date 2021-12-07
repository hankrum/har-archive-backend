using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Har.Archive.Backend.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // TODO: add exceptions logging
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
