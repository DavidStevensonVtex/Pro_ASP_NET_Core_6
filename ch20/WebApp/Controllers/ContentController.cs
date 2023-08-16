﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ContentController : ControllerBase
	{
		private DataContext context;

		public ContentController(DataContext ctx) 
		{
			context = ctx;
		}

		[HttpGet("string")]
		public string GetString() => "This is a string response";

		[HttpGet("object")]
		[Produces("application/json")]
		public async Task<ProductBindingTarget> GetObject()
		{
			Product p = await context.Products.FirstAsync();
			return new ProductBindingTarget()
			{
				Name = p.Name,
				Price = p.Price,
				CategoryId = p.CategoryId,
				SupplierId = p.SupplierId
			};
		}
	}
}
