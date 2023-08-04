using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components
{
	public class NavigationMenuViewComponent : ViewComponent
	{
		public IStoreRepository repository;

		public NavigationMenuViewComponent(IStoreRepository repo)
		{
			this.repository = repo;
		}

		public IViewComponentResult Invoke()
		{
			return View(repository.Products
				.Select(x => x.Category)
				.Distinct()
				.OrderBy(x => x));
		}
	}
}
