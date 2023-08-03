using Microsoft.AspNetCore.Mvc;
using Testing.Models;

namespace Testing.Controllers
{
	public class HomeController : Controller
	{
		public IDataSource dataSource = new ProductDataSource();
		public IActionResult Index()
		{
			return View(dataSource.Products);
		}
	}
}
