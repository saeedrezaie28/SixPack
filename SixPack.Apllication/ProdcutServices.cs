
using SixPack.Domain.Entity;
using SixPack.Domain.Repositories;

namespace SixPack.Apllication;

public class ProdcutServices : IProdcutServices
{
    private readonly IProdcutRepository _prodcutRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProdcutServices(
        IProdcutRepository prodcutRepository,
        IUnitOfWork unitOfWork)
    {
        _prodcutRepository = prodcutRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddProduct(ProductDto productDto)
    {
        var prodcut = new Product();
        prodcut.Title = productDto.Title;
        prodcut.Color = productDto.Color;
        prodcut.Price = productDto.Price;
        prodcut.Desc = productDto.Desc;
        prodcut.Slag = productDto.Slag;
        prodcut.CategoryID = productDto.CategoryID;

        ProdcutImage prodcutImage = default;

        prodcut.Images = new List<ProdcutImage>();

        if (productDto.IndexImage != null)
        {
            prodcutImage = new ProdcutImage()
            {
                DownloadPath = productDto.IndexImage.DownloadPath
            };
            prodcut.Images.Add(prodcutImage);
        }

        if (productDto.Images != null && productDto.Images.Count > 0)
        {
            productDto.Images?.ForEach(image =>
            {
                prodcut.Images.Add(new ProdcutImage()
                {
                    DownloadPath = image.DownloadPath,
                });
            });
        }

        _unitOfWork.Set<Product>().Add(prodcut);

        if (prodcutImage != null && prodcutImage.ID > 0)
        {
            prodcut.IndexImage = prodcutImage.ID;
        }

        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
    }

    public async Task EditProduct(int id, ProductDto productDto)
    {
        var prodcut = await _prodcutRepository.GetProductByIdAsync(id);
        prodcut.Title = productDto.Title;
        prodcut.Color = productDto.Color;
        prodcut.Price = productDto.Price;
        prodcut.Desc = productDto.Desc;
        prodcut.Slag = productDto.Slag;
        prodcut.CategoryID = productDto.CategoryID;

        if (productDto.Images != null && productDto.Images.Count > 0)
        {
            prodcut.Images = new List<ProdcutImage>();

            productDto.Images?.ForEach(image =>
            {
                prodcut.Images.Add(new ProdcutImage()
                {
                    DownloadPath = image.DownloadPath,
                });
            });
        }

        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
    }

    public async Task<IList<Product>> GetProduct()
    {
        var products = await _prodcutRepository.GetProductsAsync();
        return products;
    }

    public async Task<Product> GetProductById(int id)
    {
        var product = await _prodcutRepository.GetProductByIdAsync(id);
        return product;
    }
}
