using System;
using System.Collections.Generic;
using System.Linq;
using OnlineConstructionEquipmentRental.Core.Model;
using OnlineConstructionEquipmentRental.Core.Model.Abstract;
using OnlineConstructionEquipmentRental.Persistence.Repositories.Abstract;

namespace OnlineConstructionEquipmentRental.Persistence.Repositories
{
    public class CartRepository : ICartRepository
    {
        public IEquipmentRepository EquipmentRepository { get; }
        public IFeeRepository FeeRepository { get; }
        public ICustomersRepository CustomersRepository { get; }
        private Cart Cart { get; }

        public CartRepository(IEquipmentRepository equipmentRepository, IFeeRepository feeRepository, ICustomersRepository customersRepository)
        {
            EquipmentRepository = equipmentRepository;
            FeeRepository = feeRepository;
            CustomersRepository = customersRepository;
            Cart = new Cart(customersRepository.GetCurrentCustomer()) {Items = new List<CartItem>()};
        }

        public Cart Get()
        {
            return Cart;
        }

        public void AddToCart(int id)
        {
            var cartItem = Cart.Items.FirstOrDefault(item => item.EquipmentItem.Id == id);
            // if there's no such item in cart
            if (cartItem == null) // add it to cart
            {
                var equipmentItem = EquipmentRepository.Get(id);
                Cart.Items.Add(new CartItem(equipmentItem));
                return;
            }
            else // if it already exists in cart - add one more day to rental period
            {
                cartItem.RentalPeriod++;
                return;
            }
        }

        public void DeleteFromCart(int id)
        {
            var equipmentItem = Cart.Items.FirstOrDefault(item => item.EquipmentItem.Id == id);
            if (equipmentItem == null)
                throw new ArgumentException("There's no such item in cart");
            Cart.Items.Remove(equipmentItem);
        }

        public void UpdateCart(Cart cart)
        {
            Cart.Items = cart.Items;
        }

        public void Clear()
        {
            Cart.Items = new List<CartItem>();
        }
    }
}