using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using System.Text.Json.Serialization;
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

			builder.Services.AddControllers().AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();

			builder.Services.Configure<MvcNewtonsoftJsonOptions>(opts =>
			{
				opts.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
			});

			//builder.Services.Configure<JsonOptions>(opts =>
			//{
			//	// Doesn't seem to work. JsonSerializerOptions renamed to SerializerOptions.
			//	// https://github.com/dotnet/docs/issues/27824
			//	opts.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
			//});

			var app = builder.Build();

			app.MapControllers();

			app.MapGet("/", () => "Hello World!");

			var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
			SeedData.SeedDatabase(context);

			app.Run();
		}
	}
}