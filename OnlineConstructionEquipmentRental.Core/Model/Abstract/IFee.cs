namespace OnlineConstructionEquipmentRental.Core.Model.Abstract
{
    public interface IFee
    {
        decimal OneTime { get; }

        decimal Premium { get; }

        decimal Regular { get; }
    }
}