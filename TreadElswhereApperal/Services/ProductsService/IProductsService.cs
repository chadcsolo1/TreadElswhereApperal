using TreadElswhereApperal.Models;

namespace TreadElswhereApperal.Services.ProductsService
{
    public interface IProductsService
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        //Task<List<Product>> GetProductsByCategory(string categoryUrl);
        //Task<List<string>> GetProductCategories();
        //Task<List<Product>> SearchProducts(string searchText);
        //Task<List<Product>> GetFeaturedProducts();
        //Task<List<Product>> GetLatestProducts();
        //Task<List<Product>> GetTopRatedProducts();
    }
}
