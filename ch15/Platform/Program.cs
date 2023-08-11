namespace Platform
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			var app = builder.Build();

            app.MapGet("population/{city?}", Population.Endpoint);

			app.Run();
        }
    }
}