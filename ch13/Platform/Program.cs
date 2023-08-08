using Microsoft.Extensions.Options;
using System.Net.Mime;

namespace Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            app.MapGet("{first}/{second}/{third}", async context =>
            {
                await context.Response.WriteAsync("Request was routed\n");
                foreach (var kvp in context.Request.RouteValues)
                {
                    await context.Response.WriteAsync($"{kvp.Key}: {kvp.Value}\n");
                }
            });

			app.MapGet("capital/uk", Capital.Endpoint);
			app.MapGet("population/paris", Population.Endpoint);

			app.Run();
        }
    }
}