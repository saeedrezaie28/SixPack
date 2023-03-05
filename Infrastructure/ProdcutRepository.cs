using Microsoft.EntityFrameworkCore;
using SixPack.Domain.Entity;
using SixPack.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixPack.Infrastructure
{
    public class ProdcutRepository : IProdcutRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProdcutRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.Set<Product>().FirstOrDefaultAsync(a => a.ID == id);
            return product;
        }

        public async Task<IList<Product>> GetProductsAsync()
        {
            var products = await _unitOfWork.Set<Product>().ToListAsync();
            return products;
        }

        public Task SaveProdcut(Product product)
        {
            _unitOfWork.Set<Product>().Add(product);
            return Task.CompletedTask;
        }
    }
}
