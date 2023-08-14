using Platform.Services;
using Platform.Models;
using Microsoft.EntityFrameworkCore;

namespace Platform
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddDistributedMemoryCache(opts =>
            //{
            //    opts.SizeLimit = 200;
            //});

            builder.Services.AddDistributedSqlServerCache(opts =>
            {
                opts.ConnectionString = builder.Configuration["ConnectionStrings:CacheConnection"];
                opts.SchemaName = "dbo";
                opts.TableName = "DataCache";
            });

            builder.Services.AddResponseCaching();
            builder.Services.AddSingleton<IResponseFormatter, HtmlResponseFormatter>();

            builder.Services.AddDbContext<CalculationContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration["ConnectionStrings:CalcConnection"]);
                opts.EnableSensitiveDataLogging(true);
            });

            builder.Services.AddTransient<SeedData>();

            var app = builder.Build();

            app.UseResponseCaching();

			app.MapGet("sum/{count:long=1000000000}", SumEndpoint.Endpoint);

            app.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            bool cmdLineInit = (app.Configuration["INITDB"] ?? "false") == "true";
            if (app.Environment.IsDevelopment() || cmdLineInit)
            {
                var seedData = app.Services.GetRequiredService<SeedData>();
                seedData.SeedDatabase();
            }

            if (! cmdLineInit )
            {
                app.Run();
            }
        }
    }
}