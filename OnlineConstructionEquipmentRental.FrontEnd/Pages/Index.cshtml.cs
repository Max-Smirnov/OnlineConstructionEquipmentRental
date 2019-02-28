using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlineConstructionEquipmentRental.FrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        //public IEnumerable<CartItem> EquipmentItems { get; set; }

        //public IndexModel()
        //{
        //    EquipmentItems = new List<CartItem>();
        //}
        public void OnGet()
        {

        }
    }

    //public class CartItem
    //{
    //    private EquipmentItem EquipmentItem { get; set; }
    //    public int Id => EquipmentItem.Id;
    //    public string Name => EquipmentItem.Name;
    //    public int RentalPeriod { get; set; }
    //    public int LoyaltyPoints => EquipmentItem.LoyaltyPoints;
    //    public decimal Price => EquipmentItem.CalculateRentalPrice();

    //    public CartItem(EquipmentItem item)
    //    {
    //        EquipmentItem = item;
    //    }
    //}
}
