using Core.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Infrastructure;

public class MigrationHostedService : IHostedService
{
    private readonly IMigrationService _migrationService;
    private readonly ILogger<MigrationHostedService> _logger;

    public MigrationHostedService(IMigrationService migrationService, ILogger<MigrationHostedService> logger)
    {
        _migrationService = migrationService;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Running database migrations...");
        _migrationService.RunMigrations();
        _logger.LogInformation("Migrations completed ✅");

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}