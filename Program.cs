using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AutogestionAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHotBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHotBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
