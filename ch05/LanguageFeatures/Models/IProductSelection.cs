namespace LanguageFeatures.Models
{
    public interface IProductSelection
    {
        IEnumerable<Product>? Products { get; }
    }
}
