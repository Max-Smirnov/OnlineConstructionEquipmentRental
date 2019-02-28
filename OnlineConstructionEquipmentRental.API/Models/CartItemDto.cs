namespace OnlineConstructionEquipmentRental.API.Models
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int LoyaltyPoints { get; set; }
        public int RentalPeriod { get; set; }
    }
}
