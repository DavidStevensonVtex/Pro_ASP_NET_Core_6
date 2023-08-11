using Microsoft.AspNetCore.HttpLogging;

namespace Platform
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpLogging(opts =>
            {
                opts.LoggingFields = HttpLoggingFields.RequestMethod |
                    HttpLoggingFields.RequestPath | HttpLoggingFields.ResponseStatusCode;
            });

			var app = builder.Build();

            app.UseHttpLogging();

            app.UseStaticFiles();

            app.MapGet("population/{city?}", Population.Endpoint);

			app.Run();
        }
    }
}