using System;

namespace OnlineConstructionEquipmentRental.API.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int ItemsCount { get; set; }
        public DateTime OrderDate { get; set; }
        public int LoyaltyPoints { get; set; }
        public decimal Price { get; set; }
    }
}