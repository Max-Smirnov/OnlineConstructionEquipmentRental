using OnlineConstructionEquipmentRental.Core.Model.Abstract;
using System.Linq;
using System.Text;

namespace OnlineConstructionEquipmentRental.Core.Model
{
    public class PlainTextInvoiceGenerator : IInvoiceGenerator
    {
        public string MediaType => "text/plain";

        public string GenerateInvoice(Order order, IFee fee)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Invoice #{order.Id}");
            foreach (CartItem orderItem in order.Items)
            {
                builder.AppendLine($"{orderItem.EquipmentItem.Name}\t{orderItem.GetRentalPrice(fee)}");
            }

            builder.AppendLine($"Total price: {order.Items.Sum(i => i.GetRentalPrice(fee))}; " +
                               $"points earned: {order.Items.Sum(i => i.EquipmentItem.LoyaltyPoints)}");
            return builder.ToString();
        }
    }
}