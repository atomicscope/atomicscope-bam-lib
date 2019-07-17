using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Kovai.AtomicScope.Bam.Common;
using Kovai.AtomicScope.Bam.Logging;
using Kovai.AtomicScope.Bam.Messages;
using Newtonsoft.Json;

namespace Kovai.AtomicScope.Bam
{
	public class ActivityService : IActivityService
	{
		private readonly string _url;
		private readonly IBamActivityLogger _bamActivityLogger;
		private readonly HttpClient _client;

		public ActivityService()
		{
			_url = Constants.FunctionApiUrl;
			_client = new HttpClient();
			_bamActivityLogger = new NullBamActivityLogger();
		}

		public ActivityService(IBamActivityLogger bamActivityLogger)
		{
			_url = Constants.FunctionApiUrl;
			_client = new HttpClient();
			_bamActivityLogger = bamActivityLogger;
		}

		public ActivityService(string functionUrl, IBamActivityLogger bamActivityLogger)
		{
			_url = functionUrl;
			_client = new HttpClient();
			_bamActivityLogger = bamActivityLogger;
		}

		public ActivityService(string functionUrl)
		{
			_url = functionUrl;
			_client = new HttpClient();
			_bamActivityLogger = new NullBamActivityLogger();
		}
		public async Task<StartActivityResponse> StartActivity(StartActivityRequest activityRequest)
		{
			var result = new StartActivityResponse();
			try
			{
				_bamActivityLogger.Debug($"Starting Stage Activity - {JsonConvert.SerializeObject(activityRequest)}");
				activityRequest.Validate();


				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BusinessProcess, activityRequest.BusinessProcess);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BusinessTransaction, activityRequest.BusinessTransaction);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.CurrentStage, activityRequest.CurrentStage);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.MainActivityId, activityRequest.MainActivityId.ToString());
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.PreviousStage, activityRequest.PreviousStage);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.ArchiveMessage, Convert.ToString(activityRequest.IsArchiveEnabled));
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BatchId, activityRequest.BatchId);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.ResourceId, activityRequest.ResourceId);

				if (activityRequest.MessageHeader == null)
					activityRequest.MessageHeader = "{\"Content-Type\":\"application/json\"}";

				if (activityRequest.MessageBody == null)
					activityRequest.MessageBody = "{}";

				if (string.IsNullOrEmpty(activityRequest.PreviousStage))
					activityRequest.PreviousStage = ".";

				var header = JsonConvert.DeserializeObject<Dictionary<string, string>>(activityRequest.MessageHeader);
				header["Content-Type"] = "application/json";

				var activityContent = new ActivityContent
				{
					MessageBody = activityRequest.MessageBody,
					MessageHeader = activityRequest.MessageHeader
				};

				var uri = $"{_url}/api/{Constants.Operations.StartActivity}";
				var data = new StringContent(JsonConvert.SerializeObject(activityContent), Encoding.UTF8, "application/json");
				var response = await _client.PostAsync(uri, data);

				if (response.IsSuccessStatusCode)
				{
					result = JsonConvert.DeserializeObject<StartActivityResponse>(response.Content.ReadAsStringAsync().Result);
				}
			}
			catch (Exception ex)
			{
				_bamActivityLogger.Error(ex.Message);
			}

			return result;
		}

		public async Task<bool> UpdateActivity(UpdateActivityRequest activityRequest)
		{
			try
			{
				_bamActivityLogger.Debug($"Updating Stage Activity - {JsonConvert.SerializeObject(activityRequest)}");
				activityRequest.Validate();

				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BusinessProcess, activityRequest.BusinessProcess);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BusinessTransaction, activityRequest.BusinessTransaction);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.CurrentStage, activityRequest.CurrentStage);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.MainActivityId, activityRequest.MainActivityId.ToString());
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.StageActivityId, activityRequest.StageActivityId.ToString());
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.Status, Enum.GetName(typeof(StageStatus), activityRequest.Status));
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.ArchiveMessage, Convert.ToString(activityRequest.IsArchiveEnabled));
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.ResourceId, activityRequest.ResourceId);

				if (activityRequest.MessageHeader == null)
					activityRequest.MessageHeader = "{\"Content-Type\":\"application/json\"}";
				if (activityRequest.MessageBody == null)
					activityRequest.MessageBody = "{}";

				var header = JsonConvert.DeserializeObject<Dictionary<string, string>>(activityRequest.MessageHeader);
				header["Content-Type"] = "application/json";

				var activityContent = new ActivityContent
				{
					MessageBody = activityRequest.MessageBody,
					MessageHeader = activityRequest.MessageHeader
				};

				var uri = $"{_url}/api/{Constants.Operations.UpdateActivity}";
				var data = new StringContent(JsonConvert.SerializeObject(activityContent), Encoding.UTF8, "application/json");
				var response = await _client.PostAsync(uri, data);
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_bamActivityLogger.Error(ex.Message);
			}

			return false;
		}

		public async Task<bool> ArchiveActivity(ArchiveActivityRequest activityRequest)
		{
			try
			{
				_bamActivityLogger.Debug($"Archiving Stage Activity - {JsonConvert.SerializeObject(activityRequest)}");
				activityRequest.Validate();

				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BusinessProcess, activityRequest.BusinessProcess);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BusinessTransaction, activityRequest.BusinessTransaction);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.CurrentStage, activityRequest.CurrentStage);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.StageActivityId, activityRequest.StageActivityId.ToString());

				if (activityRequest.MessageHeader == null)
					activityRequest.MessageHeader = "{\"Content-Type\":\"application/json\"}";
				if (activityRequest.MessageBody == null)
					activityRequest.MessageBody = "{}";

				var header = JsonConvert.DeserializeObject<Dictionary<string, string>>(activityRequest.MessageHeader);
				header["Content-Type"] = "application/json";

				var activityContent = new ActivityContent
				{
					MessageBody = activityRequest.MessageBody,
					MessageHeader = activityRequest.MessageHeader
				};

				var uri = $"{_url}/api/{Constants.Operations.ArchiveActivity}";
				var data = new StringContent(JsonConvert.SerializeObject(activityContent), Encoding.UTF8, "application/json");
				var response = await _client.PostAsync(uri, data);
				return response.IsSuccessStatusCode;

			}
			catch (Exception ex)
			{
				_bamActivityLogger.Error(ex.Message);
			}
			return false;
		}

		public async Task<bool> LogExceptionActivity(LogExceptionActivityRequest activityRequest)
		{
			try
			{
				_bamActivityLogger.Debug($"Logging Exception Activity - {JsonConvert.SerializeObject(activityRequest)}");
				activityRequest.Validate();

				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.StageActivityId, activityRequest.StageActivityId.ToString());
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BusinessProcess, activityRequest.BusinessProcess);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.ExceptionCode, activityRequest.ExceptionCode);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.ExceptionMessage, activityRequest.ExceptionMessage);

				var uri = $"{_url}/api/{Constants.Operations.LogExceptionActivity}";
				var response = await _client.PostAsync(uri, null);
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_bamActivityLogger.Error(ex.Message);
			}
			return false;
		}
	}
}
