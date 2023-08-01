using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
	public class HomeController : Controller
	{
		public ViewResult Index()
		{
			return View("MyView");
		}
	}
}
