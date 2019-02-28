using OnlineConstructionEquipmentRental.Core.Model.Abstract;

namespace OnlineConstructionEquipmentRental.Core.Model
{
    public class HeavyEquipmentItem : EquipmentItem
    {
        public override int LoyaltyPoints => 2;
        public override decimal CalculateRentalPrice(int days, IFee fee)
        {
            return fee.OneTime + fee.Premium * days;
        }
    }
}
