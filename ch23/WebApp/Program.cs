using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Packaging;

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

			builder.Services.AddDistributedMemoryCache();
			builder.Services.AddSession(options =>
			{
				options.Cookie.IsEssential = true;
			});

			builder.Services.Configure<RazorPagesOptions>(opts =>
			{
				opts.Conventions.AddPageRoute("/Index", "/extra/page/{id:long?}");
			});

			var app = builder.Build();

			app.UseStaticFiles();
			app.UseSession();
			app.MapControllers();
			app.MapDefaultControllerRoute();
			app.MapRazorPages();

			var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
			SeedData.SeedDatabase(context);

			app.Run();
		}
	}
}