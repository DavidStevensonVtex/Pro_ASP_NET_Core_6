namespace Platform
{
	public class QueryStringMiddleware
	{
		private RequestDelegate next;

		public QueryStringMiddleware(RequestDelegate nextDelegate)
		{
			this.next = nextDelegate;
		}

		public async Task Invoke(HttpContext context)
		{
			if (context.Request.Method == HttpMethods.Get &&
				context.Request.Query["custom"] == "true")
			{
				context.Response.ContentType = "text/plain";
				await context.Response.WriteAsync("Custom Middleware \n");
			}
			await next(context);
		}
	}
}
