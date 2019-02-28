using System.Collections.Generic;
using OnlineConstructionEquipmentRental.Core.Model.Abstract;

namespace OnlineConstructionEquipmentRental.Core.Model
{
    public class Inventory
    {
        public IEnumerable<EquipmentItem> Items { get; set; }
    }
}