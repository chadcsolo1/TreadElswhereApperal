using Blazored.LocalStorage;
using Blazored.Toast.Services;
using TreadElswhereApperal.Models;

namespace TreadElswhereApperal.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IToastService _toastService;

        public event Action OnChange;

        public CartService(ILocalStorageService localStorage, IToastService toastService)
        {
            _localStorage = localStorage;
            _toastService = toastService;
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
            //var _product = await _productService.GetProduct(product.Id);
            //_toastService.ShowSuccess($"{product.Name} added to cart", "Success");

            OnChange.Invoke();
        }
    }

}
