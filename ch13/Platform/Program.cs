using Platform.Services;

namespace Platform
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            app.UseMiddleware<WeatherMiddleware>();

            //IResponseFormatter formatter = new TextResponseFormatter();
            app.MapGet("middleware/function", async (context) =>
            {
                await TypeBroker.Formatter.Format(context, "Middleware Function: It is snowing in Chicago");
            });

            app.MapGet("endpoint/class", WeatherEndpoint.Endpoint);

            app.MapGet("endpoint/function", async context =>
            {
                await TypeBroker.Formatter.Format(context, "Endpoint Function: It is sunny in LA");
            });

			app.Run();
        }
    }
}