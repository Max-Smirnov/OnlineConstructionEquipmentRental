using System;
using System.Collections.Generic;

namespace OnlineConstructionEquipmentRental.Core.Model
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<CartItem> Items { get; set; }
        public DateTime OrderDate { get; set; }

        public Order(Customer customer)
        {
            Items = new List<CartItem>();
            Customer = customer;
        }
    }
}