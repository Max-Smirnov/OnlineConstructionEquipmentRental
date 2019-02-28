using OnlineConstructionEquipmentRental.Core.Model.Abstract;

namespace OnlineConstructionEquipmentRental.Core.Model
{
    public class Fee : IFee
    {
        public Fee(decimal oneTime, decimal premium, decimal regular)
        {
            OneTime = oneTime;
            Premium = premium;
            Regular = regular;
        }
        public decimal OneTime { get; }
        public decimal Premium { get; }
        public decimal Regular { get; }
    }
}