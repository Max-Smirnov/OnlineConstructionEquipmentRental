using System.Collections.Generic;
using System.Linq;
using OnlineConstructionEquipmentRental.Core.Model;
using OnlineConstructionEquipmentRental.Persistence.Repositories.Abstract;

namespace OnlineConstructionEquipmentRental.Persistence.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        public ICustomersRepository CustomersRepo { get; }
        public IList<Order> Orders { get; set; }

        public OrdersRepository(ICustomersRepository customersRepo)
        {
            CustomersRepo = customersRepo;
            Orders = new List<Order>();
        }

        public IEnumerable<Order> Get(Customer customer)
        {
            return Orders.Where(o => o.Customer == customer);
        }

        public void Checkout(Cart cart)
        {
            var order = new Order(cart.Customer)
            {
                Items = cart.Items, Id = Orders.Max(o => o.Id) + 1
            };
            Orders.Add(order);
        }

        public Order Get(int id)
        {
            return Orders.FirstOrDefault(o => o.Id == id);
        }
    }
}