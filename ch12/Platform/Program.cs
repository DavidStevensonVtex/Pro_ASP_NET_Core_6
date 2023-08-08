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
                branch.Run(new Platform.QueryStringMiddleware().Invoke);
            });

            app.UseMiddleware<QueryStringMiddleware>();

            app.MapGet("/", () => "Hello, World!");

            app.Run();
        }
    }
}