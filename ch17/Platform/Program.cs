using Microsoft.AspNetCore.HostFiltering;
using Platform.Services;

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

            var app = builder.Build();

            app.UseResponseCaching();

			app.MapGet("sum/{count:long=1000000000}", SumEndpoint.Endpoint);

            app.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

			app.Run();
        }
    }
}