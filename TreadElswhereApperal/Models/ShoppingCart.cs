namespace TreadElswhereApperal.Models
{
    public class ShoppingCart
    {
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
