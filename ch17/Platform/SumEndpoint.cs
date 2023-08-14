namespace Platform
{
	public class SumEndpoint
	{
		public async Task Endpoint(HttpContext context)
		{
			int count;
			int.TryParse((string?)context.Request.RouteValues["count"], out count);
			long total = 0;
			for (int i = 1; i <= count; i++ )
			{
				total += i;
			}
			string totalString = $"({DateTime.Now.ToLongTimeString()}) {total}";
			await context.Response.WriteAsync($"({DateTime.Now.ToLongTimeString()}) Total for {count}" +
				$" values: \n{ totalString}\n");
		}
	}
}
