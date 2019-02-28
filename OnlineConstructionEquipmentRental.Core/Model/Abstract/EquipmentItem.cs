namespace OnlineConstructionEquipmentRental.Core.Model.Abstract
{
    public abstract class EquipmentItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual int LoyaltyPoints => 0;

        public abstract decimal CalculateRentalPrice(int days, IFee fee);
    }
}
