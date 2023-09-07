using Advanced.Models;
using Microsoft.EntityFrameworkCore;

namespace Advanced
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            builder.Services.AddDbContext<DataContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration["ConnectionStrings:PeopleConnection"]);
                opts.EnableSensitiveDataLogging(true);
            });

            var app = builder.Build();

            //app.MapGet("/", () => "Hello World !");

            app.UseStaticFiles();

            app.MapControllers();
            app.MapControllerRoute("controllers", "controllers/{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            app.MapBlazorHub();

            var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
            SeedData.SeedDatabase(context);

            app.Run();
        }
    }
}