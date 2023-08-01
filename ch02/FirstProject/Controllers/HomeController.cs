using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
	public class HomeController : Controller
	{
		public string Index()
		{
			return "Hello world";
		}
	}
}
