using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Diagnostics;

namespace Core.CrossCuttingConcerns.Interceptors
{
    public class LoggingInterceptor : DbCommandInterceptor
    {
        private Stopwatch? _timer;
        public override InterceptionResult<DbCommand> CommandCreating(
           CommandCorrelatedEventData eventData, InterceptionResult<DbCommand> result)
        {
            _timer = Stopwatch.StartNew();
            Console.WriteLine($"Created Command Date = {eventData.StartTime}");
            

            return result;
        }
        public override DbCommand CommandInitialized(
           CommandEndEventData eventData, DbCommand result)
        {
            _timer.Stop();
            Console.WriteLine($"Elapsed Time = {_timer}");
            
            return result;
        }

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result,
            CancellationToken cancellationToken)
        {
            
            Console.WriteLine($"Executed Db Query = {command.CommandText}");

            return new ValueTask<InterceptionResult<DbDataReader>>(result);
        }



    }
}
