using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore.Models;
using SportsStore.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportsStore.Infrastructure;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SportsStore.Components;

namespace SportsStore.Tests
{
	public class NavigationMenuViewComponentTests
	{
		[Fact]
		public void Can_Select_Categories()
		{
			// Arrange
			Mock<IStoreRepository> mock = new();
			mock.Setup(m => m.Products).Returns(new Product[]
			{
				new Product { ProductID = 1, Name = "P1", Category = "Apples" },
				new Product { ProductID = 2, Name = "P2", Category = "Apples" },
				new Product { ProductID = 3, Name = "P3", Category = "Plums" },
				new Product { ProductID = 4, Name = "P4", Category = "Oranges" },
			}.AsQueryable<Product>());

			NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);

			// Act = get the set of categories
			string[] results = ((IEnumerable<string>?)(target.Invoke() as ViewViewComponentResult)?.ViewData?.Model 
				?? Enumerable.Empty<string>()).ToArray();

			// Assert 
			Assert.True(Enumerable.SequenceEqual(new string[] { "Apples", "Oranges", "Plums" }, results));
		}
	}
}
