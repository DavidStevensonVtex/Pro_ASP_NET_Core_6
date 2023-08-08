namespace Platform
{
	public class QueryStringMiddleware
	{
		private RequestDelegate? next;

		public QueryStringMiddleware()
		{
			// do nothing
		}

		public QueryStringMiddleware(RequestDelegate nextDelegate)
		{
			this.next = nextDelegate;
		}

		public async Task Invoke(HttpContext context)
		{
			if (context.Request.Method == HttpMethods.Get &&
				context.Request.Query["custom"] == "true")
			{
				await context.Response.WriteAsync("Class-based Middleware \n");
			}
			await next(context);
		}
	}
}
