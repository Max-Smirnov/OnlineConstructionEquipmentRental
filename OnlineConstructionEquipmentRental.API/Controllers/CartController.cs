using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OnlineConstructionEquipmentRental.API.Models;
using OnlineConstructionEquipmentRental.Core.Model;
using OnlineConstructionEquipmentRental.Persistence.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;
using OnlineConstructionEquipmentRental.API.Mappers;
using OnlineConstructionEquipmentRental.Persistence.Repositories;

namespace OnlineConstructionEquipmentRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Default")]
    public class CartController : ControllerBase
    {
        public ICartRepository CartRepo { get; }
        public IOrdersRepository OrdersRepository { get; }
        public IFeeRepository FeeRepository { get; }

        public CartController(ICartRepository cartRepo, IOrdersRepository ordersRepository, IFeeRepository feeRepository)
        {
            CartRepo = cartRepo;
            OrdersRepository = ordersRepository;
            FeeRepository = feeRepository;
        }

        // GET: api/Cart
        [HttpGet]
        public IEnumerable<CartItemDto> Get()
        {
            return CartRepo.Get().Items.Select(cartItem => cartItem.ToCartItemDto(FeeRepository.Get()));
        }

        // POST: api/Cart
        [HttpPost]
        [EnableCors("Default")]
        [ActionName("AddToCart")]

        public IActionResult AddToCart([Microsoft.AspNetCore.Mvc.FromBody] int id)
        {
            CartRepo.AddToCart(id);
            return new OkResult();
        }

        // POST: api/Cart
        [HttpPost("update")]
        [EnableCors("Default")]
        public IEnumerable<CartItemDto> UpdateCart([Microsoft.AspNetCore.Mvc.FromBody] IEnumerable<UpdateRentalPeriodItemDto> items)
        {
            var cart = CartRepo.Get();
            RefreshCart(items, cart);
            CartRepo.UpdateCart(cart);
            return cart.Items.Select(cartItem => cartItem.ToCartItemDto(FeeRepository.Get()));
        }

        private static void RefreshCart(IEnumerable<UpdateRentalPeriodItemDto> items, Cart cart)
        {
            foreach (CartItem cartItem in cart.Items)
            {
                var updateItemDto = items.FirstOrDefault(item => item.Id == cartItem.EquipmentItem.Id);
                if (updateItemDto == null) continue;
                cartItem.RentalPeriod = updateItemDto.RentalPeriod;
            }
        }

        // POST: api/Cart
        [HttpPost("checkout")]
        public IActionResult Checkout([Microsoft.AspNetCore.Mvc.FromBody] IEnumerable<UpdateRentalPeriodItemDto> items)
        {
            var cart = CartRepo.Get();
            RefreshCart(items, cart);
            OrdersRepository.Checkout(cart);
            CartRepo.Clear();
            return new OkResult();
        }

        // DELETE: api/Cart/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            CartRepo.DeleteFromCart(id);
            return new OkResult();
        }
    }
}
