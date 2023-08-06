using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Controllers
{
    public class OrderController : Controller
    {
        public ViewResult Checkout() => View();
    }
}
