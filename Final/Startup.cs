using Final.Interfaces;
using Final.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Final; 

public class Startup {
    public Startup(IConfiguration configuration) => _configuration = configuration;
    
    public void ConfigureServices(IServiceCollection services) {
        var host = _configuration["CinemaDataBase:Host"];
        var port = _configuration["CinemaDataBase:Port"];
        var name = _configuration["CinemaDataBase:Name"];
        var user = _configuration["CinemaDataBase:User"];
        var password = _configuration["CinemaDataBase:Password"];
        var moviesTableName = _configuration["CinemaDataBase:MoviesTableName"];
        var showTimesTableName = _configuration["CinemaDataBase:ShowTimesTableName"];

        services.AddControllers();

        services.AddSingleton<IMovieAccessLayer>(
            new MovieAccessLayer(host, port, name, user, password, moviesTableName));

        services.AddSingleton<IShowTimeAccessLayer>(
            new ShowTimeAccessLayer(host, port, name, user, password, showTimesTableName));
    }

    public void Configure(IApplicationBuilder application, IWebHostEnvironment environment) {
        if (environment.IsDevelopment()) {
            application.UseDeveloperExceptionPage();
        }
        
        application.UseCors(builder => {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });

        application.UseDefaultFiles();
        application.UseStaticFiles();
        application.UseRouting();
        
        application.UseEndpoints(endpoints => {
            endpoints.MapControllers();
        });
    }

    private readonly IConfiguration _configuration;
}