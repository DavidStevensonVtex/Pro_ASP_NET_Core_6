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
				opts.EnableSensitiveDataLogging(true);
			});

			builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
			builder.Services.AddRazorPages();
			builder.Services.AddSingleton<CitiesData>();

			var app = builder.Build();

			app.UseStaticFiles();
			app.MapControllers();
			app.MapDefaultControllerRoute();
			app.MapRazorPages();

			var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
			SeedData.SeedDatabase(context);

			app.Run();
		}
	}
}