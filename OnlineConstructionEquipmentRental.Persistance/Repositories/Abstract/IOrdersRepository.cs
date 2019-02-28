using System.Collections.Generic;
using OnlineConstructionEquipmentRental.Core.Model;

namespace OnlineConstructionEquipmentRental.Persistence.Repositories.Abstract
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> Get(Customer customer);
        void Checkout(Cart cart);
        Order Get(int id);
    }
}