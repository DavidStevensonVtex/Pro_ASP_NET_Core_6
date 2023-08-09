using System.Runtime.CompilerServices;

namespace Platform.Services
{
	public class TestResponseFormatter : IResponseFormatter
	{
		private int responseCounter = 0;

		public async Task Format(HttpContext context, string content)
		{
			await context.Response.WriteAsync($"Response {++responseCounter}:\n{content}");
		}
	}
}