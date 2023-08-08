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

            app.MapGet("files/{filename}.{ext}", async context =>
            {
                await context.Response.WriteAsync("Request Was Routed\n");
                foreach (var kvp in context.Request.RouteValues)
                {
                    await context.Response.WriteAsync($"{kvp.Key}: {kvp.Value}\n");
                }
            });

			app.MapGet("capital/{country=France}", Capital.Endpoint);
            app.MapGet("size/{city}", Population.Endpoint)
                .WithMetadata(new RouteNameMetadata("population"));

			app.Run();
        }
    }
}