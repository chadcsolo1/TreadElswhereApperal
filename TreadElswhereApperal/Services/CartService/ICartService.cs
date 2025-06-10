using TreadElswhereApperal.Models;

namespace TreadElswhereApperal.Services.CartService
{
    public interface ICartService
    {

        event Action OnChange;
        void ShowCart();
        Task AddToCart(Product product);
        Task GetCart(List<OrderDetail> orderDetails);
    }
}
