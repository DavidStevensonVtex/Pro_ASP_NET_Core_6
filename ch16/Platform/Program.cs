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

            app.MapGet("/session", async context =>
            {
                int counter1 = (context.Session.GetInt32("counter1") ?? 0) + 1;
                int counter2 = (context.Session.GetInt32("counter2") ?? 0) + 1;
                context.Session.SetInt32("counter1", counter1);
                context.Session.SetInt32("counter2", counter2);
                await context.Session.CommitAsync();
                await context.Response.WriteAsync($"Counter1: {counter1}, Counter2: {counter2}");
            });

            app.MapFallback(async context =>
            {
                await context.Response.WriteAsync($"HTTPS Request: {context.Request.IsHttps}\n");
                await context.Response.WriteAsync("Hello World!");
            });

			app.Run();
        }
    }
}