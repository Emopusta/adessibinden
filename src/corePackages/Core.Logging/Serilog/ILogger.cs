namespace Core.Logging.Serilog;

public interface ILogger
{
    public void Debug(string message);
    public void Information(string message);
    public void Error(string message);
    public void Warning(string message);
    public void Verbose(string message);
    public void Fatal(string message);
}
