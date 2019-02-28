namespace OnlineConstructionEquipmentRental.Core.Model.Abstract
{
    public interface IInvoiceGenerator
    {
        string MediaType { get; }
        string GenerateInvoice(Order order, IFee fee);
    }
}