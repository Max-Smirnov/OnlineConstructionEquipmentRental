using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using OnlineConstructionEquipmentRental.API.Mappers;
using OnlineConstructionEquipmentRental.API.Models;
using OnlineConstructionEquipmentRental.Core.Model.Abstract;
using OnlineConstructionEquipmentRental.Persistence.Repositories;
using OnlineConstructionEquipmentRental.Persistence.Repositories.Abstract;

namespace OnlineConstructionEquipmentRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public IOrdersRepository OrdersRepo { get; }
        public IInvoiceGenerator InvoiceGenerator { get; }
        public IFeeRepository FeeRepository { get; }
        public ICustomersRepository CustomersRepository { get; }

        public OrdersController(IOrdersRepository ordersRepo, IInvoiceGenerator invoiceGenerator, 
            IFeeRepository feeRepository, ICustomersRepository customersRepository)
        {
            OrdersRepo = ordersRepo;
            InvoiceGenerator = invoiceGenerator;
            FeeRepository = feeRepository;
            CustomersRepository = customersRepository;
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<OrderDto> Get()
        {
            return OrdersRepo.Get(CustomersRepository.GetCurrentCustomer()).Select(o => o.ToOrderDto(FeeRepository.Get()));
        }

        // GET: api/Orders/invoice
        [HttpGet("invoice/{id}")]
        public IActionResult GetInvoice(int id)
        {
            var order = OrdersRepo.Get(id);
            var invoice = InvoiceGenerator.GenerateInvoice(order, FeeRepository.Get());
            return new FileContentResult(Encoding.UTF8.GetBytes(invoice), InvoiceGenerator.MediaType);
        }
    }
}
