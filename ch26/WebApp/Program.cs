using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WebApp.TagHelpers;

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
            builder.Services.AddTransient<ITagHelperComponent, TimeTagHelperComponent>();
            builder.Services.AddTransient<ITagHelperComponent, TableFooterTagHelperComponent>();

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