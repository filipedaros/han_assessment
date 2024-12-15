
using FluentMigrator.Runner;
using hahn.domain.contracts;

using hahn.infrastructure.migrations;
using hahn.infrastructure.persistence;
using hahn.infrastructure.repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;

namespace hahn.infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
    {
        //THIS SHOULD BE IN A SECURE STORE
        var connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING");
        
        services.AddEntityFrameworkSqlServer();
        services.AddDbContext<ApplicationDbContext>(optionsBuilder =>
        {    
            optionsBuilder.UseSqlServer(connectionString);
        });
        
        services.AddFluentMigratorCore()
            .ConfigureRunner(rb =>
            {
                rb.AddSqlServer()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(InitialMigration).Assembly).For.Migrations();
            })
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
        
        //Set up http clients
        services.AddHttpClient("countries-api", client =>
        {
            client.BaseAddress = new Uri("https://countries-api-abhishek.vercel.app/");
        });
        
        //Add all repos in this layer
        services.AddScoped<ICountryExternalRepository, CountryExternalRepository>();
        services.AddTransient<ICountryRepository, CountryRepository>();
        
        return services;
    }
}