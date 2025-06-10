using Blazored.LocalStorage;
using Blazored.Toast.Services;
using TreadElswhereApperal.Models;
using TreadElswhereApperal.Services.ProductsService;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Text.Json;
using NuGet.Protocol;


namespace TreadElswhereApperal.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IToastService _toastService;
        private readonly IProductsService _productService;
        private readonly ProtectedLocalStorage _protectedLocalStorage;

        public event Action OnChange;

        public CartService(ILocalStorageService localStorage, IToastService toastService, IProductsService productService, ProtectedLocalStorage protectedLocalStorage)
        {
            _localStorage = localStorage;
            _toastService = toastService;
            _productService = productService;
            _protectedLocalStorage = protectedLocalStorage;
        }

        public void ShowCart() => OnChange.Invoke();

        //public async Task AddToCart(Product product)
        //{
        //    var cart = await _localStorage.GetItemAsync<List<Product>>("cart");

        //    //var cart = await 

        //    if (cart == null)
        //    {
        //        cart = new List<Product>();
        //    }

        //    cart.Add(product);

        //    await _localStorage.SetItemAsync("cart", cart);

        //    //Add this code after creating ProductService
        //    var _product = await _productService.GetProduct(product.Id);
        //    _toastService.ShowSuccess($"{product.Name} Added to Cart");

        //    OnChange.Invoke();
        //}

        public async Task GetCart(List<OrderDetail> orderDetails)
        {
            var cart = await _protectedLocalStorage.GetAsync<List<Product>>("cart1");
            //List<Product> products = new List<Product>();

            if (!cart.Success)
            {
                Console.WriteLine("There are no items in the shopping cart");
                return;
            }

            foreach (var product in cart.Value)
            {
                orderDetails.Add(new OrderDetail
                {
                    Product = product,
                    ProductId = product.Id,
                    Quantity = 1, // Default quantity, can be adjusted later
                    PricePerUnit = (decimal)product.Price // Assuming Price is a property of Product
                });
            }




            //dorderDetail.Product = cart.Value;
        }

        public async Task AddToCart(Product product)
        {
            var result = await _protectedLocalStorage.GetAsync<List<Product>>("cart1");

            if (result.Success)
            {
                // Deserialize the existing cart if it exists
                //var existingCart = JsonSerializer.Deserialize<List<Product>>(result.Value.ToString()) ?? new List<Product>();
                var existingCart = result.Value.ToList();
                existingCart.Add(product);
                await _protectedLocalStorage.SetAsync("cart1", existingCart);
            } else
            {
                // If no cart exists, create a new one with the product
                await _protectedLocalStorage.SetAsync("cart1", new List<Product> { product });
            }

            OnChange.Invoke();
        }
    }

}
