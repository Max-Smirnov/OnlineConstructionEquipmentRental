using OnlineConstructionEquipmentRental.Core.Model.Abstract;

namespace OnlineConstructionEquipmentRental.Core.Model
{
    public class RegularEquipmentItem : EquipmentItem
    {
        private int _feeThreshold = 2;
        public override decimal CalculateRentalPrice(int days, IFee fee)
        {
            var totalFee = fee.OneTime;
            if (days <= _feeThreshold)
            {
                return totalFee + fee.Premium * days;
            }

            return totalFee + fee.Premium * _feeThreshold + fee.Regular * (days - _feeThreshold);
        }

        public override int LoyaltyPoints => 1;
    }
}
