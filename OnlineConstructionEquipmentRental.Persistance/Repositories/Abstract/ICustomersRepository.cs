using System.Collections.Generic;
using OnlineConstructionEquipmentRental.Core.Model;

namespace OnlineConstructionEquipmentRental.Persistence.Repositories.Abstract
{
    public interface ICustomersRepository
    {
        IEnumerable<Customer> GetAll();
        Customer Get(int id);
        Customer GetCurrentCustomer();
    }
}