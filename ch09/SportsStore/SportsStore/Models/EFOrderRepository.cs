namespace SportsStore.Models
{
	public class EFOrderRepository : IOrderRepository
	{
		private StoreDbContext context;
		public EFOrderRepository(StoreDbContext ctx) 
		{
			context = ctx;
		}


		public IQueryable<Order> Orders => context.Orders;

		public void SaveOrder(Order order)
		{
			context.AttachRange(order.Lines.Select(l => l.Product));
			if (order.OrderID == 0)
			{
				context.Orders.Add(order);
			}

			context.SaveChanges();
		}
	}
}
