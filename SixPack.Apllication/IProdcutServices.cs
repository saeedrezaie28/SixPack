using SixPack.Domain.Entity;

namespace SixPack.Apllication
{
    public interface IProdcutServices
    {
        Task<Product> GetProductById(int id);
        Task<IList<Product>> GetProduct();
        Task EditProduct(int id, ProductDto productDto);
        Task AddProduct(ProductDto productDto);
    }
}