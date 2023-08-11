namespace Platform
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var servicesConfig = builder.Configuration;
            builder.Services.Configure<MessageOptions>(servicesConfig.GetSection("Location"));

            var servicesEnv = builder.Environment;
            // - use environment to set up services

			var app = builder.Build();

            var pipelineConfig = app.Configuration;
            // - use configuration settings to set up pipeline

            var pipelineEnv = app.Environment;
            // - use environment to set up pipeline

            app.UseMiddleware<LocationMiddleware>();

            app.MapGet("config", async (HttpContext context, IConfiguration config, IWebHostEnvironment env) =>
            {
                string defaultDebug = config["Logging:LogLevel:Default"];
                await context.Response.WriteAsync($"The config setting is: {defaultDebug}");
                await context.Response.WriteAsync($"\nThe env setting is: {env.EnvironmentName}");

                string wsID = config["WebService:Id"];
                string wsKey = config["WebService:Key"];
                await context.Response.WriteAsync($"\nThe secret ID is: {wsID}");
                await context.Response.WriteAsync($"\nThe secret Key is: {wsKey}");
            });

            app.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

			app.Run();
        }
    }
}