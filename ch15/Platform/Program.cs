namespace Platform
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			var app = builder.Build();

            app.Logger.LogDebug("Pipeline configuration starting");

            app.MapGet("population/{city?}", Population.Endpoint);

			app.Logger.LogDebug("Pipeline configuration complete");

			app.Run();
        }
    }
}