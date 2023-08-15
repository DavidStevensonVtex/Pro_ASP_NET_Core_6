using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
	[Route("api/[controller]")]
	//[ApiController]
	public class ProductsController : ControllerBase
	{
		[HttpGet]
		public IEnumerable<Product> GetProducts()
		{
			return new Product[]
			{
				new Product() { Name = "Product #1" },
				new Product() { Name = "Product #2" }
			};
		}

		[HttpGet("{id}")]
		public Product GetProduct()
		{
			return new Product() { ProductId = 1, Name = "Test Product" };
		}
	}
}
