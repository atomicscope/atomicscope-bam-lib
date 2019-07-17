namespace Kovai.AtomicScope.Bam.Logging
{
	class NullBamActivityLogger : IBamActivityLogger
	{
		public void Debug(string message)
		{
			//do nothing
		}

		public void Info(string message)
		{
			//do nothing
		}

		public void Warning(string message)
		{
			//do nothing
		}

		public void Error(string message)
		{
			//do nothing
		}

		public void Fatal(string message)
		{
			//do nothing
		}
	}
}
