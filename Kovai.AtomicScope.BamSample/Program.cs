using Kovai.AtomicScope.Bam;

namespace Kovai.AtomicScope.BamSample
{
	class Program
	{
		static void Main(string[] args)
		{
			var activityService = new ActivityService("https://asfnappbt36935.azurewebsites.net");
			var processor = new LogisticsProcessor(activityService);
			processor.SendBookingRequest(); //Transaction 1
			processor.ConfirmBooking(); //Transaction 2
			processor.SendShippingInstructions(); //Transaction 3
			processor.ReceiveInvoice(); //Transaction 4
		}
	}
}
