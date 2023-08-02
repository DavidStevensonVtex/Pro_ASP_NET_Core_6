namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View(Product.GetProducts().Select(p => p?.Name));
        }
    }
}
