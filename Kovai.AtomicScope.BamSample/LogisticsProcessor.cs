using Kovai.AtomicScope.Bam;
using Kovai.AtomicScope.Bam.Common;
using Kovai.AtomicScope.Bam.Messages;

namespace Kovai.AtomicScope.BamSample
{
	public class LogisticsProcessor
	{
		private readonly IActivityService _activityService;
		private readonly string _businessProcess;

		public LogisticsProcessor(IActivityService activityService)
		{
			_activityService = activityService;
			_businessProcess = "Ship Any Where Logistics";
		}
		public void SendBookingRequest()
		{
			var businessTransaction = "Booking Request";

			//Receive

			var receiveResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				PreviousStage = ".",
				IsArchiveEnabled = true,
				MessageBody = "{\"tim\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			}).Result;

			_activityService.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				MainActivityId = receiveResponse.MainActivityId,
				StageActivityId = receiveResponse.StageActivityId,
				Status = StageStatus.Success,
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			});

			//Process

			var processResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Process",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Receive",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			}).Result;

			_activityService.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Process",
				MainActivityId = processResponse.MainActivityId,
				StageActivityId = processResponse.StageActivityId,
				Status = StageStatus.Success,
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			});

			//Send

			var sendResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Send",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Process",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			}).Result;

			_activityService.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Send",
				MainActivityId = sendResponse.MainActivityId,
				StageActivityId = sendResponse.StageActivityId,
				Status = StageStatus.Success,
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			});
		}
		public void ConfirmBooking()
		{
			var businessTransaction = "Confirm Booking";

			//Receive

			var receiveResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				PreviousStage = ".",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			}).Result;

			_activityService.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				MainActivityId = receiveResponse.MainActivityId,
				StageActivityId = receiveResponse.StageActivityId,
				Status = StageStatus.Success,
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			});

			//Process

			var processResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Process",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Receive",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			}).Result;

			_activityService.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Process",
				MainActivityId = processResponse.MainActivityId,
				StageActivityId = processResponse.StageActivityId,
				Status = StageStatus.Success,
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			});

			//Send

			var sendResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Send",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Process",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			}).Result;

			_activityService.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Send",
				MainActivityId = sendResponse.MainActivityId,
				StageActivityId = sendResponse.StageActivityId,
				Status = StageStatus.Success,
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			});
		}

		public void SendShippingInstructions()
		{
			var businessTransaction = "Send Shipping Instructions";

			//Receive

			var receiveResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				PreviousStage = ".",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			}).Result;

			_activityService.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				MainActivityId = receiveResponse.MainActivityId,
				StageActivityId = receiveResponse.StageActivityId,
				Status = StageStatus.Success,
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			});

			_activityService.ArchiveActivity(new ArchiveActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				StageActivityId = receiveResponse.StageActivityId,
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			});

			//Process

			var processResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Process",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Receive",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			}).Result;

			_activityService.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Process",
				MainActivityId = processResponse.MainActivityId,
				StageActivityId = processResponse.StageActivityId,
				Status = StageStatus.Success,
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			});

			//Send

			var sendResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Send",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Process",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			}).Result;

			_activityService.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Send",
				MainActivityId = sendResponse.MainActivityId,
				StageActivityId = sendResponse.StageActivityId,
				Status = StageStatus.Success,
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			});
		}

		public void ReceiveInvoice()
		{
			var businessTransaction = "Receive Invoice";

			//Receive

			var receiveResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				PreviousStage = ".",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			}).Result;

			_activityService.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				MainActivityId = receiveResponse.MainActivityId,
				StageActivityId = receiveResponse.StageActivityId,
				Status = StageStatus.Success,
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			});

			//Process

			var processResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Process",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Receive",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			}).Result;

			_activityService.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Process",
				MainActivityId = processResponse.MainActivityId,
				StageActivityId = processResponse.StageActivityId,
				Status = StageStatus.Success,
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			});

			//Send

			var sendResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Send",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Process",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			}).Result;

			_activityService.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Send",
				MainActivityId = sendResponse.MainActivityId,
				StageActivityId = sendResponse.StageActivityId,
				Status = StageStatus.Success,
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			});

			_activityService.LogExceptionActivity(new LogExceptionActivityRequest
			{
				StageActivityId = sendResponse.StageActivityId,
				ExceptionMessage = "Sample Error Message",
				ExceptionCode = "XXX0000",
				BusinessProcess = _businessProcess
			});
		}
	}
}
