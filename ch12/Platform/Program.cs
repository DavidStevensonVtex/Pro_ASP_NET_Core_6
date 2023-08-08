namespace Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            ((IApplicationBuilder)app).Map("/branch", branch =>
            {
                branch.UseMiddleware<Platform.QueryStringMiddleware>();

                branch.Use(async (HttpContext context, Func<Task> next) =>
                {
                    await context.Response.WriteAsync($"Branch middleware");
                });
            });

            app.UseMiddleware<QueryStringMiddleware>();

            app.MapGet("/", () => "Hello, World!");

            app.Run();
        }
    }
}