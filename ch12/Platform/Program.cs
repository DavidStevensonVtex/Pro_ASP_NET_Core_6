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

            app.MapGet("/location", async (HttpContext context, IOptions<MessageOptions> msgOpts) =>
            {
                MessageOptions opts = msgOpts.Value;
                await context.Response.WriteAsync($"{opts.CityName}, {opts.CountryName}");
            });

            app.MapGet("/", () => "Hello, World!");

            app.Run();
        }
    }
}