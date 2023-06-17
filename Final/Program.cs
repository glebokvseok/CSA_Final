using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Final;

public static class Program {
    private static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(builder => builder.UseStartup<Startup>());
}

