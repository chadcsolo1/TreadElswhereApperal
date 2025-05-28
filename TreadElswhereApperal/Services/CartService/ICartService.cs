using TreadElswhereApperal.Models;

namespace TreadElswhereApperal.Services.CartService
{
    public interface ICartService
    {

        event Action OnChange;
        Task AddToCart(ShoppingCart cart, Product product);
    }
}
