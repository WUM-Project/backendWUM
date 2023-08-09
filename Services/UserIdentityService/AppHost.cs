

using Microsoft.EntityFrameworkCore;

//Scaffold - DbContext "Server=DESKTOP-9M6MTGC\SQLEXPRESS02;Database=WUMAccounts;Trusted_Connection=True;Encrypt=False;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models - Project UserIdentityService


using Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shed.CoreKit.WebApi;
using System;
using UserIdentityService;


using UserIdentityService.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;


public class AppHost
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        // Запуск хоста
        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.ConfigureServices((hostContext, services) =>
            {
                services.AddEndpointsApiExplorer();

                services.AddScoped<IUserService, UserServise>();
                services.AddControllers();

                var configuration = hostContext.Configuration;

                string connectionString = configuration.GetConnectionString("DefaultConnection");

                services.AddDbContext<WumaccountsContext>(options =>
                    options.UseSqlServer(connectionString));

                // Добавляем Swagger
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
                });
            });

            webBuilder.Configure((hostContext, app) =>
            {
                // Конфигурация HTTP-пайплайна
                app.UseHttpsRedirection();
                app.UseRouting();
                app.UseAuthorization();

                // Добавляем Swagger UI
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });
        });

}
