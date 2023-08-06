namespace SportsStore.Models
{
	public class IOrderRepository
	{
		IQueryable<Order> Orders { get; }
		void SaveOrder(Order order);
	}
}
