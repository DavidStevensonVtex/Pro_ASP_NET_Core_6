﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using WebApp.Filters;
using WebApp.Models;

namespace WebApp.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        private DataContext context;

        private IEnumerable<Category> Categories => context.Categories;
        private IEnumerable<Supplier> Suppliers => context.Suppliers;

        public HomeController(DataContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View(context.Products.Include(p => p.Category).Include(p => p.Supplier));
        }

        public async Task<IActionResult> Details ( long id )
        {
            Product? p = await context.Products.Include(p => p.Category).Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.ProductId == id) ?? new Product();
            ProductViewModel model = ViewModelFactory.Details(p);
            return View("ProductEditor", model);
        }
    }
}
