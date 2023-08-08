using Microsoft.Extensions.Options;
using System.Net.Mime;

namespace Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<MessageOptions>(options => options.CityName = "Albany");

            var app = builder.Build();

            app.MapGet("routing", async context =>
            {
                await context.Response.WriteAsync("Request Was Routed");
            });

			app.MapGet("capital/uk", new Capital().Invoke);
			app.MapGet("population/paris", new Population().Invoke);

			//app.Run(async (context) =>
			//{
			//	await context.Response.WriteAsync("Terminal Middleware Reached");
			//});

			app.Run();
        }
    }
}