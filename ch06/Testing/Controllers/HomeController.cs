using Microsoft.AspNetCore.Mvc;
using Testing.Models;

namespace Testing.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View(Product.GetProducts());
		}
	}
}
