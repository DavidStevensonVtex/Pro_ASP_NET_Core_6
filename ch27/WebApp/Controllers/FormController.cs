using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class FormController : Controller
    {
        private DataContext context;

        public FormController ( DataContext ctx )
        {
            context = ctx;
        }

        public async Task<IActionResult> Index(long id = 1)
        {
            ViewBag.Categories = new SelectList(context.Categories, "CategoryId", "Name");

            return View("Form", await context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstAsync(p => p.ProductId == id));
        }

        [HttpPost]
        public IActionResult SubmitForm()
        {
            foreach (string key in Request.Form.Keys)
            {
                TempData[key] = string.Join(", ", Request.Form[key]);
            }
            return RedirectToAction(nameof(Results));
        }

        public IActionResult Results()
        {
            return View();
        }
    }
}
