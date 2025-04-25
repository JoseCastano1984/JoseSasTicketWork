using Core.Interfaces;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Services.Infrastructure;

public class MigrationService :  IMigrationService
{
    private readonly IServiceProvider _serviceProvider;

    public MigrationService(string connectionString)
    {
        _serviceProvider = new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(typeof(Data.Migrations.InitialTicketSchema250425).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider();
    }

    public void RunMigrations()
    {
        using var scope = _serviceProvider.CreateScope();
        var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
        runner.MigrateUp();
    }
}