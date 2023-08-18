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

			builder.Services.AddDistributedMemoryCache();
			builder.Services.AddSession(options =>
			{
				options.Cookie.IsEssential = true;
			});

			var app = builder.Build();

			app.UseStaticFiles();
			app.UseSession();
			app.MapControllers();
			app.MapDefaultControllerRoute();

			var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
			SeedData.SeedDatabase(context);

			app.Run();
		}
	}
}