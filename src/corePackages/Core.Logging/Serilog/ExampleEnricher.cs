using Serilog.Core;
using Serilog.Events;
using System.Diagnostics;
using System.Reflection;

namespace Core.Logging.Serilog;

public class ExampleEnricher : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    { 

        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ThreadId", Thread.CurrentThread.ManagedThreadId));
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ThreadName", Thread.CurrentThread.Name));
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("AssemblyName", Assembly.GetExecutingAssembly().FullName));
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("TraceId", logEvent.TraceId));
        
    }
}
