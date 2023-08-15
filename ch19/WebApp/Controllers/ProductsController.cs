﻿using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
	[Route("api/[controller]")]
	//[ApiController]
	public class ProductsController : ControllerBase
	{
		private DataContext context;

		public ProductsController(DataContext ctx )
		{
			context = ctx;
		}

		[HttpGet]
		public IEnumerable<Product> GetProducts()
		{
			return context.Products;
		}

		[HttpGet("{id}")]
		public Product? GetProduct(long id, [FromServices] ILogger<ProductsController> logger)
		{
			logger.LogDebug("GetProduct Action Invoked");
			return context.Products.Find(id);
		}
	}
}
