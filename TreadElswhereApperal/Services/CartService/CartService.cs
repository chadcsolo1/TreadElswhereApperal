using Blazored.LocalStorage;
using Blazored.Toast.Services;
using TreadElswhereApperal.Models;
using TreadElswhereApperal.Services.ProductsService;

namespace TreadElswhereApperal.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IToastService _toastService;
        private readonly IProductsService _productService;

        public event Action OnChange;

        public CartService(ILocalStorageService localStorage, IToastService toastService, IProductsService productService)
        {
            _localStorage = localStorage;
            _toastService = toastService;
            _productService = productService;
        }

        public async Task AddToCart(Product product)
        {
            var cart = await _localStorage.GetItemAsync<List<Product>>("cart");

            if (cart == null)
            {
                cart = new List<Product>();
            }

            cart.Add(product);

            await _localStorage.SetItemAsync("cart", cart);

            //Add this code after creating ProductService
            var _product = await _productService.GetProduct(product.Id);
            _toastService.ShowSuccess($"{product.Name} Added to Cart");

            OnChange.Invoke();
        }
    }

}
