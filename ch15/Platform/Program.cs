namespace Platform
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            app.MapGet("config", async (HttpContext context, IConfiguration config) =>
            {
                string defaultDebug = config["Logging:LogLevel:Default"];
                await context.Response.WriteAsync($"The config setting is: {defaultDebug}");
            });

            app.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

			app.Run();
        }
    }
}