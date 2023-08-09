using Platform.Services;

namespace Platform
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IResponseFormatter, HtmlResponseFormatter>();

            var app = builder.Build();

            app.UseMiddleware<WeatherMiddleware>();

            app.MapGet("middleware/function", async (HttpContext context, IResponseFormatter formatter) =>
            {
                await formatter.Format(context, "Middleware Function: It is snowing in Chicago");
            });

            //app.MapWeather("endpoint/class");
            app.MapEndpoint<WeatherEndpoint>("endpoint/class");

            app.MapGet("endpoint/function", async (HttpContext context, IResponseFormatter formatter) =>
            {
                await formatter.Format(context, "Endpoint Function: It is sunny in LA");
            });

			app.Run();
        }
    }
}