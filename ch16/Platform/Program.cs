using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.FileProviders;

namespace Platform
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(opts =>
            {
                opts.IdleTimeout = TimeSpan.FromMinutes(30);
                opts.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            app.UseSession();

            app.UseMiddleware<ConsentMiddleware>();

            app.MapFallback(async context => await context.Response.WriteAsync("Hello World!"));

			app.Run();
        }
    }
}