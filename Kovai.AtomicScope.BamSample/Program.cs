using Kovai.AtomicScope.Bam;

namespace Kovai.AtomicScope.BamSample
{
	class Program
	{
		static void Main(string[] args)
		{
			var activityService = new ActivityService("https://asfnappbiz370.azurewebsites.net");
			var processor = new LogisticsProcessor(activityService);
			processor.SendBookingRequest();
			processor.ConfirmBooking();
			processor.SendShippingInstructions();
			processor.ReceiveInvoice();
		}
	}
}
