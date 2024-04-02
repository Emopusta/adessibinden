using Microsoft.Extensions.Configuration;
using NpgsqlTypes;
using Serilog;
using Serilog.Sinks.PostgreSQL;
using Serilog.Sinks.PostgreSQL.ColumnWriters;
using LoggingSerilog = Serilog;

namespace Core.Logging.Serilog;

public class SerilogPostgresLogger : ILogger
{
    private readonly LoggingSerilog.ILogger _logger;
    private readonly IConfiguration _configuration;

    public SerilogPostgresLogger(IConfiguration configuration)
    {
        _configuration = configuration;

        IDictionary<string, ColumnWriterBase> columnWriters = new Dictionary<string, ColumnWriterBase>
        {
            { "message", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
            { "level", new LevelColumnWriter(true, NpgsqlDbType.Varchar) },
            { "raise_date", new TimestampColumnWriter(NpgsqlDbType.TimestampTz) },
            { "exception", new ExceptionColumnWriter(NpgsqlDbType.Text) },
            { "properties", new LogEventSerializedColumnWriter(NpgsqlDbType.Jsonb) },
            { "props_test", new PropertiesColumnWriter(NpgsqlDbType.Jsonb) },
            { "machine_name", new SinglePropertyColumnWriter("MachineName", PropertyWriteMethod.ToString, NpgsqlDbType.Text, "l") }
        };

        var connectionString = _configuration.GetConnectionString("Adessibinden");
        var tableName = "logs";

        _logger = new LoggerConfiguration()
            .WriteTo.PostgreSQL(connectionString, tableName, columnWriters, needAutoCreateTable: true)
            .CreateLogger();
    }

    public void Debug(string message)
    {
        _logger?.Debug(message);
    }

    public void Error(string message)
    {
        _logger?.Error(message);
    }

    public void Fatal(string message)
    {
        _logger?.Fatal(message);
    }

    public void Information(string message)
    {
        _logger?.Information(message);
    }

    public void Verbose(string message)
    {
        _logger?.Verbose(message);
    }

    public void Warning(string message)
    {
        _logger?.Warning(message);
    }
}
