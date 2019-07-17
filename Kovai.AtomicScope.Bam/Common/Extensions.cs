using System.Net.Http.Headers;

namespace Kovai.AtomicScope.Bam.Common
{
	internal static class Extensions
	{
		internal static void AddOrReplace(this HttpRequestHeaders headers, string name, string value)
		{
			if (headers.Contains(name))
				headers.Remove(name);
			headers.Add(name, value);
		}
	}
}
