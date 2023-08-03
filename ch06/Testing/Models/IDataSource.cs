namespace Testing.Models
{
    public interface IDataSource
    {
        IEnumerable<Product> Products { get; }
    }
}
