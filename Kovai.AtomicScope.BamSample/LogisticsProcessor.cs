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

			#region Stage 1 Receive

			var receiveResponse =  _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				PreviousStage = ".",
				IsArchiveEnabled = true,
				MessageBody = "{\"tim\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
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
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
			});

			#endregion

			#region Stage 2 Process

			var processResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Process",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Receive",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
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
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
			});

			#endregion
			
			#region Stage 3 Send

			var sendResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Send",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Process",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
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
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
			});

			#endregion
		}
		public void ConfirmBooking()
		{
			var businessTransaction = "Confirm Booking";

			#region Receive

			var receiveResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				PreviousStage = ".",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
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
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
			});

			#endregion

			#region Process

			var processResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Process",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Receive",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
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
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
			});

			#endregion

			#region Send

			var sendResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Send",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Process",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
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
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
			});

			#endregion
		}

		public void SendShippingInstructions()
		{
			var businessTransaction = "Send Shipping Instructions";

			#region Receive

			var receiveResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				PreviousStage = ".",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
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
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
			});

			#endregion

			//To Archive at any point

			_activityService.ArchiveActivity(new ArchiveActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				StageActivityId = receiveResponse.StageActivityId,
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
			});

			#region Process

			var processResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Process",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Receive",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
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
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
			});

			#endregion

			#region Send

			var sendResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Send",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Process",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
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
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
			});

			#endregion
		}

		public void ReceiveInvoice()
		{
			var businessTransaction = "Receive Invoice";

			#region Receive

			var receiveResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				PreviousStage = ".",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
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
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
			});

			#endregion

			#region Process

			var processResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Process",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Receive",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
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
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
			});

			#endregion

			#region Send

			var sendResponse = _activityService.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Send",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Process",
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
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
				ResourceId = "0303ac15-71b0-4966-a573-cca55e2cfbfc"
			});

			#endregion

			//To log an Exception

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
