namespace Kovai.AtomicScope.Bam.Logging
{
	public interface IBamActivityLogger
	{
		void Debug(string message);
		void Info(string message);
		void Warning(string message);
		void Error(string message);
		void Fatal(string message);
	}
}
