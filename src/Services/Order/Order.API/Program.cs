using System;
using System.IO;
using System.Text;
using Order.Api.Application.Services;
using Order.Api.Application.Services.Interfaces;
using Order.Api.Grpc;
using Order.Api.Grpc.Interfaces;
using Order.Api.Middleware;
using Order.Domain.Repositories;
using Order.Infrastructure;
using Order.Infrastructure.Persistance.Repositories;
using GrpcApplicant;

using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using GrpcOrder;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel(options =>
{
    // Конфігурація Kestrel тут
    // options.ListenAnyIP(443, o => o.Protocols = HttpProtocols.Http2);
    // options.ListenAnyIP(80, o => o.Protocols = HttpProtocols.Http1);
});

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(jwt =>
{
    var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtConfig:Secret"]);
    var tokenValidationParams = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        RequireExpirationTime = false
    };
    jwt.SaveToken = true;
    jwt.TokenValidationParameters = tokenValidationParams;
});

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddDbContext<OrderDbContext>(opt =>
{
    if (builder.Environment.IsProduction())
    {
        Console.WriteLine("\n---> Using SqlServer Db Production\n");
        opt.UseSqlServer(builder.Configuration.GetConnectionString("ExamsConnection"));
    }
    else if (builder.Environment.IsDevelopment())
    {
        Console.WriteLine("\n---> Using SqlServer Db Development\n");
        opt.UseSqlServer(builder.Configuration.GetConnectionString("ExamsConnection"));
    }
    else if (builder.Environment.IsStaging())
    {
        Console.WriteLine("\n---> Using SqlServer Db Staging\n");
        opt.UseSqlServer(builder.Configuration.GetConnectionString("ExamsConnection"));
    }
});

builder.Services.AddHealthChecks();

builder.Services.AddScoped<IServiceManager, ServiceManager>();


 //GRPC
builder.Services.AddScoped<IApplicantGrpcService, ApplicantGrpcService>();
          
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();


builder.Services.AddGrpc();

Console.WriteLine($"---> GRPCReport: {builder.Configuration["GrpcReportSettings:ReportUrl"]}");
Console.WriteLine($"---> GRPCApplicant: {builder.Configuration["GrpcApplicantSettings:ApplicantUrl"]}");

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Order.Api", Version = "v1" });
});

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order.Api v1"));
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseRouting();
app.UseCors("AllowOrigin");
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGrpcService<OrderGrpcService>();

    endpoints.MapGet("/proto/order.proto", async context =>
    {
        await context.Response.WriteAsync(File.ReadAllText("Proto/order.proto"));
    });
    // endpoints.MapGet("/proto/exam.proto", async context =>
    // {
    //     await context.Response.WriteAsync(File.ReadAllText("Proto/exam.proto"));
    // });
    endpoints.MapGet("/proto/platforms.proto", async context =>
    {
        await context.Response.WriteAsync(File.ReadAllText("Proto/platforms.proto"));
    });

});

// OrderDbContextSeed.PrepPopulation(app, app.Environment.IsProduction());

app.Run();