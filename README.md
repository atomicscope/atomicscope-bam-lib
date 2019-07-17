# Atomic Scope BAM for ASP.NET applications
Library to help log activities to AtomicScope from any .NET Application or Client

# How to use

You need to get your Azure Function API Endpoint URL once you have installed Atomic Scope and deployed the Azure components.
Once you get the URL, Initialize the service like this
```
var activityService = new ActivityService("https://asfnappbiz370.azurewebsites.net");
```
Now you need to Add a new API Resource in Atomic Scope [Docs](https://docs.atomicscope.com/docs/tracking-using-apis) and provide the resourceId in the Activity Request params

Use the following code to start an activity

```
	var receiveResponse = _service.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				PreviousStage = ".",
				IsArchiveEnabled = true,
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
				ResourceId = "94a5d90d-4ff6-4919-8392-cd3b77d9727e"
			})
```

To update an activity

```
_service.UpdateActivity(new UpdateActivityRequest()
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
```
