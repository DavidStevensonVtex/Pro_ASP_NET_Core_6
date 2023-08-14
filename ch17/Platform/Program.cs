using Microsoft.AspNetCore.HostFiltering;

namespace Platform
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            app.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

			app.Run();
        }
    }
}