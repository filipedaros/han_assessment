using hahn.application;
using hahn.infrastructure;
using hahn.worker;
using hahn.worker.jobs;
using Hangfire;
using Hangfire.Storage;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer();

builder.Services.AddScoped<IImportCountriesJob, ImportCountriesJob>();


//Set up hangfire
GlobalConfiguration.Configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseActivator(new HangfireActivator(builder.Services.BuildServiceProvider()))
    .UseSqlServerStorage(Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING"));

//Change to hourly here. Even better is to store the jobs parameter in a settings file.
RecurringJob.AddOrUpdate<IImportCountriesJob>("import_countries", (job) => job.Run(), Cron.MinuteInterval(1));


var host = builder.Build();

var server = new BackgroundJobServer();

host.Run();
