using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.FileProviders;

namespace Platform
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            app.Run(context =>
            {
                throw new Exception("Something has gone wrong");
            });

			app.Run();
        }
    }
}