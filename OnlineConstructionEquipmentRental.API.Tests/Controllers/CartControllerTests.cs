using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using OnlineConstructionEquipmentRental.API.Controllers;
using OnlineConstructionEquipmentRental.API.Models;
using OnlineConstructionEquipmentRental.Core.Model;
using OnlineConstructionEquipmentRental.Core.Model.Abstract;
using OnlineConstructionEquipmentRental.Persistence.Repositories;
using OnlineConstructionEquipmentRental.Persistence.Repositories.Abstract;

namespace OnlineConstructionEquipmentRental.API.Tests.Controllers
{
    public class CartControllerTests
    {
        CartController _controller;
        Mock<ICartRepository> _cartRepo;
        Mock<IFeeRepository> _feeRepo;
        Mock<IOrdersRepository> _ordersRepo;
        Mock<ICustomersRepository> _customersRepo;


        [SetUp]
        public void Setup()
        {
            _cartRepo = new Mock<ICartRepository>();
            _feeRepo = new Mock<IFeeRepository>();
            _ordersRepo = new Mock<IOrdersRepository>();
            _customersRepo = new Mock<ICustomersRepository>();
            var cart = new Cart(_customersRepo.Object.GetCurrentCustomer());
            _cartRepo.Setup(r => r.Get()).Returns(cart);
            _cartRepo.Setup(r => r.Clear());
            _ordersRepo.Setup(r => r.Checkout(cart));


            _controller = new CartController(_cartRepo.Object, _ordersRepo.Object, _feeRepo.Object);
        }

        [Test]
        public void UpdateCart_ShouldCallUpdateCart()
        {
            var items = new List<UpdateRentalPeriodItemDto>();

            _controller.UpdateCart(items);

            _cartRepo.Verify(r=>r.UpdateCart(It.IsAny<Cart>()), Times.Once);
        }

        [Test]
        public void Checkout_ShouldCallCheckout()
        {
            var items = new List<UpdateRentalPeriodItemDto>();

            _controller.Checkout(items);

            _ordersRepo.Verify(r => r.Checkout(It.IsAny<Cart>()), Times.Once);
        }

        [Test]
        public void Checkout_ShouldCallClearCart()
        {
            var items = new List<UpdateRentalPeriodItemDto>();

            _controller.Checkout(items);

            _cartRepo.Verify(r => r.Clear(), Times.Once);
        }
    }
}