﻿using Microsoft.Extensions.Caching.Distributed;
using Platform.Models;
using Platform.Services;

namespace Platform
{
	public static class SumEndpoint
	{
		public static async Task Endpoint(HttpContext context, CalculationContext dataContext)
		{
			int count;
			int.TryParse((string?)context.Request.RouteValues["count"], out count);
			long total = dataContext.Calculations?.FirstOrDefault(c => c.Count == count)?.Result ?? 0;
			if (total == 0)
			{
				for ( int i = 1; i <= count; i++ )
				{
					total += i;
				}

				dataContext.Calculations?.Add(new() { Count = count, Result = total });
				await dataContext.SaveChangesAsync();
			}

			string totalString = $"({DateTime.Now.ToLongTimeString()}) {total}";
			await context.Response.WriteAsync($"({DateTime.Now.ToLongTimeString()}) Total for {count}" +
				$" values: \n{ totalString}");
		}
	}
}
