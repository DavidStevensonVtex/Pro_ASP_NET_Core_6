using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using System.Text;

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

        public async Task<IActionResult> Index(long? id)
        {
            ViewBag.Categories = new SelectList(context.Categories, "CategoryId", "Name");

            return View("Form", await context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p =>  id == null || p.ProductId == id));
        }

        [HttpPost]
        public IActionResult SubmitForm(Category category)
        {
            TempData["category"] = System.Text.Json.JsonSerializer.Serialize(category);
            return RedirectToAction(nameof(Results));
        }

        public IActionResult Results()
        {
            return View();
        }
    }
}
