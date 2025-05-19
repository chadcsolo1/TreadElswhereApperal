using Microsoft.EntityFrameworkCore;
using TreadElswhereApperal.Models;

namespace TreadElswhereApperal.Services.ProductsService
{
    public class ProductsService : IProductsService
    {
        private readonly EcommerceDbContext _dbContext;

        public ProductsService(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new Exception($"Product with id {id} not found");
            }
            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await _dbContext.Products.ToListAsync();

            if (products == null || products.Count == 0)
            {
                throw new Exception("No products found");
            }

            return products;
        }
    }
}
