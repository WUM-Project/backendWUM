using Catalog.API.Application.Contracts.Infrastructure;
using Catalog.API.Application.Models;
using Catalog.API.Application.Services.Interfaces;
using Catalog.API.Application.Services.Mail;
using Catalog.API.Application.Services;
// using Catalog.API.Grpc.Interfaces;
using Catalog.API.Grpc;
using Microsoft.Extensions.Configuration;
using System;
using Catalog.API.Middleware;
using Microsoft.OpenApi.Models;
using Catalog.API.Application.Configurations;
using System.Text;
using Catalog.Infrasructure;
using Catalog.Domain.Repositories;
using Catalog.Infrasructure.Persistance.Repositories;
using Catalog.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

  builder.Services.AddDbContext<AppDbContext>(opt =>
         
         opt.UseSqlServer(builder.Configuration.GetConnectionString("UsersConnection")));

// if (builder.Environment.IsStaging())
// {
//     Console.WriteLine("\n---> Staging");
//     Console.WriteLine("\n---> Using SQL Server Staging\n");
     
//     builder.Services.AddDbContext<AppDbContext>(opt =>
//          opt.UseSqlServer(builder.Configuration.GetConnectionString("UsersConnection")));

//     //Console.WriteLine("\n---> Using InMem Db Staging\n");

//     //services.AddDbContext<AppDbContext>(opt =>
//     //   opt.UseInMemoryDatabase("InMem"));
// }

//Grpc


// Email configuration
builder.Services.Configure<EmailSettings>(c => builder.Configuration.GetSection("EmailSettings").Bind(c));
builder.Services.AddTransient<IEmailService, EmailService>();

//add service CustomAuthentication
builder.Services.AddCustomAuthentication(builder.Configuration);


//add service ServiceManager
builder.Services.AddScoped<IServiceManager, ServiceManager>();

//add service RepositoryManager
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddGrpc();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog.API", Version = "v1" });

    //Add authorize to swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API v1"));
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseRouting();
//For images
app.UseStaticFiles();
app.UseCors("AllowOrigin");
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGrpcService<CatalogGrpcService>();
});
//PrepDb.PrepPopulation(app, builder.Environment.IsProduction());

app.Run();



static class CustomExtensionsMethods
{
    public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));
        var key = Encoding.ASCII.GetBytes(configuration["JwtConfig:Secret"]);

        var tokenValidationParams = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            RequireExpirationTime = false
        };

        services.AddSingleton(tokenValidationParams);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(jwt =>
        {
            jwt.SaveToken = true;
            jwt.TokenValidationParameters = tokenValidationParams;
        });

        return services;
    }

}