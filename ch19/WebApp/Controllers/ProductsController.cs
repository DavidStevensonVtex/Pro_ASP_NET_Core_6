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
		public IAsyncEnumerable<Product> GetProducts()
		{
			return context.Products.AsAsyncEnumerable();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProduct(long id, [FromServices] ILogger<ProductsController> logger)
		{
			Product? p = await context.Products.FindAsync(id);
			if (p == null)
			{
				return NotFound("Product not found.");
			}
			return Ok(p);
		}

		[HttpPost]
		public async Task<IActionResult> SaveProduct([FromBody] ProductBindingTarget target)
		{
			Product p = target.ToProduct();
			await context.Products.AddAsync(p);
			await context.SaveChangesAsync();
			return Ok(p);
		}

		[HttpPut]
		public async Task UpdateProduct([FromBody] Product product)
		{
			context.Products.Update(product);
			await context.SaveChangesAsync();
		}

		[HttpDelete("{id}")]
		public async Task DeleteProduct(long id)
		{
			context.Products.Remove(new Product() { ProductId = id });
			await context.SaveChangesAsync();
		}
	}
}
