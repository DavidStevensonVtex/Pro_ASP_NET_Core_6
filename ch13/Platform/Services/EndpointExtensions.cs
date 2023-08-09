namespace Platform.Services
{
	public static class EndpointExtensions
	{
		public static void MapWeather(this IEndpointRouteBuilder app, string path)
		{
			IResponseFormatter formatter = app.ServiceProvider.GetRequiredService<IResponseFormatter>();
			app.MapGet(path, context => Platform.WeatherEndpoint.Endpoint(context, formatter));
		}
	}
}
