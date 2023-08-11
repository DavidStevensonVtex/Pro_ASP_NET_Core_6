namespace Platform
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			var app = builder.Build();

            app.UseHttpLogging();

   //         var logger = app.Services.GetRequiredService<ILoggerFactory>().CreateLogger("Pipeline");

			//logger.LogDebug("Pipeline configuration starting");

            app.MapGet("population/{city?}", Population.Endpoint);

			//logger.LogDebug("Pipeline configuration complete");

			app.Run();
        }
    }
}