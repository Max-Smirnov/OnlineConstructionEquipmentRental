using System.Collections.Generic;
using System.Linq;
using OnlineConstructionEquipmentRental.Core.Model;
using OnlineConstructionEquipmentRental.Persistence.Repositories.Abstract;

namespace OnlineConstructionEquipmentRental.Persistence.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private IList<Customer> Customers { get; }
        private Customer Current { get; set; }

        public CustomersRepository()
        {
            // pre-defined customer
            Customers = new List<Customer> {new Customer(1, "Test")};
        }

        public IEnumerable<Customer> GetAll()
        {
            return Customers;
        }

        public Customer Get(int id)
        {
            return Customers.FirstOrDefault(c => c.Id == id);
        }

        public Customer GetCurrentCustomer()
        {
            return Current;
        }
    }
}