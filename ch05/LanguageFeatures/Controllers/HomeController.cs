namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            Product?[] products = Product.GetProducts();
            return View(new string[] { $"Name: {products[0]?.Name}, Price: {products[0]?.Price}" });
        }
    }
}
