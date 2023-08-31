using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApp.Filters;

namespace WebApp.Controllers
{
    [Message("This is the controller-scoped filter")]
    public class HomeController : Controller
    {
        [Message("This is the first action-scoped filter")]
        [Message("This is the second action-scoped filter")]
        public IActionResult Index()
        {
            return View("Message", "This is the Index action on the Home controller");
        }
    }
}
