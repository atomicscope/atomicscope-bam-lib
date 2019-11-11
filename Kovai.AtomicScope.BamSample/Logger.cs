using Kovai.AtomicScope.Bam.Logging;
using Serilog;
using Serilog.Events;

namespace Kovai.AtomicScope.BamSample
{
    public class Logger : IBamActivityLogger
    {
	    private readonly Serilog.Core.Logger _logger;
	    public Logger() =>
		    _logger = new LoggerConfiguration()
			    .WriteTo.Console()
			    .CreateLogger();

	    public void Debug(string message) => _logger.Write(LogEventLevel.Error,message);

	    public void Info(string message) => _logger.Write(LogEventLevel.Information,message);

	    public void Warning(string message) => _logger.Write(LogEventLevel.Warning,message);

	    public void Error(string message) => _logger.Write(LogEventLevel.Error,message);

	    public void Fatal(string message) => _logger.Write(LogEventLevel.Fatal,message);
    }
}
