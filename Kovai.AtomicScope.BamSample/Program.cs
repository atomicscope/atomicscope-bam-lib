using Kovai.AtomicScope.Bam;
using Serilog;

namespace Kovai.AtomicScope.BamSample
{
	class Program
	{
		static void Main(string[] args)
		{
			//var activityService = new ActivityService("https://asfnappbt36480.azurewebsites.net");

			// You can also pass any of your Logger implementation, here i'm making use of Serilog just an example
			var logger = new Logger();
			var activityService = new ActivityService("https://asfnappbt36480.azurewebsites.net", logger);
			var processor = new LogisticsProcessor(activityService);
			processor.SendBookingRequest(); //Transaction 1
			processor.ConfirmBooking(); //Transaction 2
			processor.SendShippingInstructions(); //Transaction 3
			processor.ReceiveInvoice(); //Transaction 4
		}
	}
}
