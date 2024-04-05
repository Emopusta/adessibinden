using Core.Logging.Serilog;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Diagnostics;

namespace Core.CrossCuttingConcerns.Interceptors;

public class LoggingInterceptor : DbCommandInterceptor
{
    private Stopwatch? _timer;
    
    private readonly IEmopLogger _emopLogger;

    public LoggingInterceptor(IEmopLoggerFactory emopLoggerFactory)
    {
        _emopLogger = emopLoggerFactory.ForContext<LoggingInterceptor>();
    }

    public override InterceptionResult<DbCommand> CommandCreating(
       CommandCorrelatedEventData eventData, InterceptionResult<DbCommand> result)
    {
        _timer = Stopwatch.StartNew();
        _emopLogger.Information($"DbCommandCreating Date = {eventData.StartTime}");

        return result;
    }

    public override DbCommand CommandInitialized(
       CommandEndEventData eventData, DbCommand result)
    {
        _timer.Stop();
        _emopLogger.Information($"DbCommandInitialized Elapsed Time = {_timer}");

        return result;
    }

    public override void CommandFailed(DbCommand command, CommandErrorEventData eventData)
    {
        _emopLogger.Error($"DbCommandFailed Failed: {eventData.Exception.Message}");

        base.CommandFailed(command, eventData);
    }

    public override Task CommandFailedAsync(DbCommand command, CommandErrorEventData eventData, CancellationToken cancellationToken = default)
    {
        _emopLogger.Error($"DbCommandFailedAsync Failed: {eventData.Exception.Message}");

        return base.CommandFailedAsync(command, eventData, cancellationToken);
    }

    public override ValueTask<DbDataReader> ReaderExecutedAsync(DbCommand command, CommandExecutedEventData eventData, DbDataReader result, CancellationToken cancellationToken = default)
    {
        _emopLogger.Information($"DbReaderExecutedAsync Query: {command.CommandText}");

        return base.ReaderExecutedAsync(command, eventData, result, cancellationToken);
    }
}
