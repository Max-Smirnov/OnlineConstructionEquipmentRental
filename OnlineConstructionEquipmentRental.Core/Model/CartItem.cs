using OnlineConstructionEquipmentRental.Core.Model.Abstract;

namespace OnlineConstructionEquipmentRental.Core.Model
{
    public class CartItem
    {
        public EquipmentItem EquipmentItem { get; set; }
        public int RentalPeriod { get; set; }

        public CartItem(EquipmentItem equipmentItem, int rentalPeriod = 1)
        {
            EquipmentItem = equipmentItem;
            RentalPeriod = rentalPeriod;
        }

        public decimal GetRentalPrice(IFee fee)
        {
            return EquipmentItem.CalculateRentalPrice(RentalPeriod, fee);
        }
    }
}