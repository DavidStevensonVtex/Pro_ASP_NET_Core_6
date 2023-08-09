namespace Platform
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<RouteOptions>(opts =>
            {
                opts.ConstraintMap.Add("countryName", typeof(CountryRouteConstraint));
            });

            var app = builder.Build();

            app.MapGet("{first:alpha:length(3)}/{second:bool}", async context =>
            {
                await context.Response.WriteAsync("Request Was Routed\n");
                foreach (var kvp in context.Request.RouteValues)
                {
                    await context.Response.WriteAsync($"{kvp.Key}: {kvp.Value}\n");
                }
            });

			app.MapGet("capital/{country:countryName}", Capital.Endpoint);
            app.MapGet("size/{city?}", Population.Endpoint)
                .WithMetadata(new RouteNameMetadata("population"));

            app.MapFallback(async context =>
            {
                await context.Response.WriteAsync("Routed to fallback endpoint");
            });

			app.Run();
        }
    }
}