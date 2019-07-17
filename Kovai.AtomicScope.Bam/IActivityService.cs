using System;
using System.Threading.Tasks;
using Kovai.AtomicScope.Bam.Messages;

namespace Kovai.AtomicScope.Bam
{
	public interface IActivityService
	{
		Task<StartActivityResponse> StartActivity(StartActivityRequest activityRequest);
		Task<bool> UpdateActivity(UpdateActivityRequest activityRequest);
		Task<bool> ArchiveActivity(ArchiveActivityRequest activityRequest);
		Task<bool> LogExceptionActivity(LogExceptionActivityRequest activityRequest);
	}
}
