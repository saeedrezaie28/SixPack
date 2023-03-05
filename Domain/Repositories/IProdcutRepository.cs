using SixPack.Domain.Entity;

namespace SixPack.Domain.Repositories;

public interface IProdcutRepository
{
    Task<IList<Product>> GetProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task SaveProdcut(Product product);
}
