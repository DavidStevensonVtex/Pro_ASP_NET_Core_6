using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Routing;
using Moq;
using SportsStore.Components;
using SportsStore.Controllers;
using SportsStore.Models;

namespace SportsStore.Tests
{
	public class OrderControllerTests
	{
		[Fact]
		public void Cannot_Checkout_Empty_Cart()
		{
			// Arrange - create a mock repository
			Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
			// Arrange - create an empty cart
			Cart cart = new Cart();
			// Arrange - create the order
			Order order = new Order();
			// Arrange - create an instance of the controller
			OrderController target = new OrderController(mock.Object, cart);

			// Act
			ViewResult? result = target.Checkout(order) as ViewResult;

			// Assert - check that the order hasn't been stored.
			mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Never);
			// Assert - check that the method is returning the default view
			Assert.True(string.IsNullOrEmpty(result?.ViewName));
			// Assert - check that I am passing an invalid model to the view
			Assert.False(result?.ViewData.ModelState.IsValid);
		}

		[Fact]
		public void Cannot_Checkout_Invalid_ShippingDetails()
		{
			// Arrange - create a mock order repository
			Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
			// Arrange - create a cart with one item
			Cart cart = new Cart();
			cart.AddItem(new Product(), 1);
			// Arrange - create an instance of the controller
			OrderController target = new OrderController(mock.Object, cart);
			// Arrange - add an error to the model
			target.ModelState.AddModelError("error", "error");

			// Act
			ViewResult? result = target.Checkout(new Order()) as ViewResult;

			// Assert - check that the order hasn't been stored.
			mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Never);
			// Assert - check that the method is returning the default view
			Assert.True(string.IsNullOrEmpty(result?.ViewName));
			// Assert - check that I am passing an invalid model to the view
			Assert.False(result?.ViewData.ModelState.IsValid);
		}

		[Fact]
		public void Can_Checkout_And_Submit_Order()
		{
			// Arrange - create a mock order repository
			Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
			// Arrange - create a cart with one item
			Cart cart = new Cart();
			cart.AddItem(new Product(), 1);
			// Arrange - create the order
			Order order = new Order();
			// Arrange - create an instance of the controller
			OrderController target = new OrderController(mock.Object, cart);

			// Act - try to Checkout
			RedirectToPageResult? result = target.Checkout(new Order()) as RedirectToPageResult;

			// Assert - check that the order has been stored
			mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Once);
			// Assert - check that the method is redirecting to the Completed section
			Assert.Equal("/Completed", result?.PageName);
		}
	}
}
