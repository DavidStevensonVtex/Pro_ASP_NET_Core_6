namespace Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddRazorPages();

            var app = builder.Build();

            app.Use(async (context, next) =>
            {
                if (context.Request.Method == HttpMethods.Get &&
                    context.Request.Query["custom"] == "true")
                {
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Custom Middleware \n");
                }
                await next();
            });

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.MapGet("/", () => "Hello, World!");

            //app.MapRazorPages();

            app.Run();
        }
    }
}