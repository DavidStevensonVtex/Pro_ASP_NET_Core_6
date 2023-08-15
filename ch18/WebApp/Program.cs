using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<DataContext>(opts =>
			{
				opts.UseSqlServer(builder.Configuration["ConnectionStrings:ProductConnection"]);
			});

			var app = builder.Build();

			app.MapGet("/", () => "Hello World!");

			var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();

			app.Run();
		}
	}
}