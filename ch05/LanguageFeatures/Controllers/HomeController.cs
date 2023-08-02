namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            Product?[] products = Product.GetProducts();

            string? val = products[0]?.Name;
            if ( val != null)
            {
                return View(new string[] { val });
            }
            return View(new string[] { "No Value" });
        }
    }
}
