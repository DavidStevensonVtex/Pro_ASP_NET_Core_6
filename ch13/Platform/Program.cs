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

            app.UseMiddleware<LocationMiddleware>();

            app.MapGet("/", () => "Hello, World!");

            app.Run();
        }
    }
}