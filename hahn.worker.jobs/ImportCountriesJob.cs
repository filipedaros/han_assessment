using hahn.application.commands;
using hahn.application.contracts;
using Hangfire;
using Hangfire.Storage;
using MediatR;

namespace hahn.worker.jobs;

public interface IImportCountriesJob
{
    [Hangfire.AutomaticRetry(Attempts = 2, OnAttemptsExceeded = AttemptsExceededAction.Delete)]
    Task Run();
}

public class ImportCountriesJob(ISender sender) : IImportCountriesJob
{
    public async Task Run()
    {
        await sender.Send(new ImportCountriesRequest());
    }
}