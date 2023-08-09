using Platform.Services;

namespace Platform
{
	public class WeatherEndpoint 
	{
		private IResponseFormatter formatter;

		public WeatherEndpoint(IResponseFormatter respFormatter)
		{
			formatter = respFormatter;
		}

		public async Task Endpoint(HttpContext context)
		{
			await formatter.Format(context, "Endpoint Class: It is cloudy in Milan");
		}
	}
}
