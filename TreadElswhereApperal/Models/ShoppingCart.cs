namespace TreadElswhereApperal.Models
{
    public class ShoppingCart
    {
        public event Action OnChange;
        public int CustomerId
        {
            get;
            set;
        }

        public List<Product> LineItems          
        {
            get;
            set;
        } = new List<Product>();

    }
}
