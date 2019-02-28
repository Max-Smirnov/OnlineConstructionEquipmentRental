using OnlineConstructionEquipmentRental.Core.Model.Abstract;

namespace OnlineConstructionEquipmentRental.Core.Model
{
    public class SpecializedEquipmentItem : EquipmentItem
    {
        private int _feeThreshold = 3;
        public override int LoyaltyPoints => 1;

        public override decimal CalculateRentalPrice(int days, IFee fee)
        {
            if (days <= _feeThreshold)
            {
                return fee.Premium * days;
            }

            return fee.Premium * _feeThreshold + fee.Regular * (days - _feeThreshold);
        }
    }
}
