using System.Collections.Generic;

namespace OnlineConstructionEquipmentRental.Core.Model
{
    public class Cart
    {
        public Customer Customer { get; set; }
        public IList<CartItem> Items { get; set; }

        public Cart(Customer customer)
        {
            Customer = customer;
            Items = new List<CartItem>();
        }
    }
}
