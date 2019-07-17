using System;
using System.Collections.Generic;
using System.Text;

namespace Kovai.AtomicScope.Bam.Common
{
	public class Constants
	{
		public const string FunctionApiUrl = "https://asfnappbiz370.azurewebsites.net/";

		internal class Headers
		{
			public const string BusinessProcess = "AS-BusinessProcess";
			public const string BusinessTransaction = "AS-BusinessTransaction";
			public const string CurrentStage = "AS-CurrentStage";
			public const string MainActivityId = "AS-MainActivityId";
			public const string StageActivityId = "AS-StageActivityId";
			public const string PreviousStage = "AS-PreviousStage";
			public const string ArchiveMessage = "AS-ArchiveMessage";
			public const string BatchId = "AS-BatchId";
			public const string Status = "AS-Status";
			public const string ExceptionMessage = "AS-ExceptionMessage";
			public const string ExceptionCode = "AS-ExceptionCode";
			public const string ResourceId = "AS-ResourceId";
		}
		internal class Operations
		{
			public const string StartActivity = "StartActivity";
			public const string UpdateActivity = "UpdateActivity";
			public const string ArchiveActivity = "ArchiveActivity";
			public const string LogExceptionActivity = "LogExceptionActivity";
		}
	}
}
