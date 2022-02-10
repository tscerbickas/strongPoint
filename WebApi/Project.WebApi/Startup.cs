using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Project.WebApi.DataAccess;
using Project.WebApi.Filters;
using Project.WebApi.Services;
using Project.WebApi.Swagger;

namespace Project.WebApi;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var origins = Configuration.GetValue<string>("AllowedOrigins");

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                .WithOrigins(origins)
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ModelStateFilter));
                options.Filters.Add(typeof(CustomExceptionFilter));
            })
            .AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<Startup>();
            });

        services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("Default")));

        services.AddSingleton<IKineticEnergyCalculator, KineticEnergyCalculator>();

        services.AddScoped<ICalculationHistoryService, CalculationHistoryService>();
        services.AddScoped<IKineticImpactService, KineticImpactService>();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Kinetic Energy Calculator API",
                Version = "v1"
            });

            c.OperationFilter<AddRequiredHeaderParameter>();
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }

        app.UseCors();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
