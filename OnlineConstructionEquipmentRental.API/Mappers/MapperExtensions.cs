using System.Linq;
using OnlineConstructionEquipmentRental.API.Models;
using OnlineConstructionEquipmentRental.Core.Model;
using OnlineConstructionEquipmentRental.Core.Model.Abstract;

namespace OnlineConstructionEquipmentRental.API.Mappers
{
    public static class MapperExtensions
    {
        public static CartItemDto ToCartItemDto(this CartItem cartItem, IFee fee)
        {
            return new CartItemDto
            {
                Id = cartItem.EquipmentItem.Id,
                Name = cartItem.EquipmentItem.Name,
                Price = cartItem.GetRentalPrice(fee),
                LoyaltyPoints = cartItem.EquipmentItem.LoyaltyPoints,
                RentalPeriod = cartItem.RentalPeriod
            };
        }

        public static OrderDto ToOrderDto(this Order order, IFee fee)
        {
            return new OrderDto
            {
                Id = order.Id,
                ItemsCount = order.Items.Count(),
                Price = order.Items.Sum(i => i.GetRentalPrice(fee)),
                LoyaltyPoints = order.Items.Sum(i => i.EquipmentItem.LoyaltyPoints),
                OrderDate = order.OrderDate
            };
        }
    }
}
