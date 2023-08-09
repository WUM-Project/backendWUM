

using Microsoft.EntityFrameworkCore;

//Scaffold - DbContext "Server=DESKTOP-9M6MTGC\SQLEXPRESS02;Database=WUMAccounts;Trusted_Connection=True;Encrypt=False;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models - Project UserIdentityService


using Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shed.CoreKit.WebApi;
using System;

using ProductsService;

using ProductsService.Models;
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

                services.AddScoped<IProductService, ProductService>();
                services.AddControllers();

                var configuration = hostContext.Configuration;

                string connectionString = configuration.GetConnectionString("DefaultConnection");

                services.AddDbContext<WumContext>(options =>
                    options.UseSqlServer(connectionString));

               
            });

            webBuilder.Configure((hostContext, app) =>
            {
                // Конфигурация HTTP-пайплайна
                app.UseHttpsRedirection();
                app.UseRouting();
                app.UseAuthorization();

               

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });
        });

}
