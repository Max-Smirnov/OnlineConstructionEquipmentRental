using System.Collections.Generic;
using System.Linq;
using OnlineConstructionEquipmentRental.Core.Model;
using OnlineConstructionEquipmentRental.Core.Model.Abstract;
using OnlineConstructionEquipmentRental.Persistence.Repositories.Abstract;

namespace OnlineConstructionEquipmentRental.Persistence.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private string _inventoryPath = "D:\\inventory.xml";
        private IEnumerable<EquipmentItem> _inventory;
        private object _inventoryFileLocker = new object();

        public IEnumerable<EquipmentItem> GetAll()
        {
            if (_inventory == null)
            {
                lock (_inventoryFileLocker)
                {
                    var inventory = new List<EquipmentItem>();
                    inventory.Add(new HeavyEquipmentItem { Id = 1, Name = "Caterpillar bulldozer" });
                    inventory.Add(new RegularEquipmentItem() { Id = 2, Name = "KamAZ truck" });
                    inventory.Add(new HeavyEquipmentItem { Id = 3, Name = "Komatsu crane" });
                    inventory.Add(new RegularEquipmentItem { Id = 4, Name = "Volvo steamroller" });
                    inventory.Add(new SpecializedEquipmentItem() { Id = 5, Name = "Bosch jackhammer" });
                    //using (var file = File.OpenWrite(_inventoryPath))
                    //{
                    //    new XmlSerializerFactory().CreateSerializer(typeof(List<EquipmentItem>)).Serialize(file, inventory);
                    //    //File.WriteAllText(_inventoryPath, invString);
                    //}
                    _inventory = inventory;
                    //using (var file = File.OpenRead(_inventoryPath))
                    //{
                    //    _inventory = (IEnumerable<EquipmentItem>)new XmlSerializerFactory().CreateSerializer(typeof(List<EquipmentItem>)).Deserialize(file);
                    //    //var inventoryString = File.ReadAllText(_inventoryPath);
                    //    //_inventory = JsonConvert.DeserializeObject<List<EquipmentItem>>(inventoryString);
                    //}
                }
            }
            return _inventory;
        }

        public EquipmentItem Get(int id)
        {
            if (_inventory == null)
            {
                GetAll();
            }

            return _inventory.FirstOrDefault(eq => eq.Id == id);
        }
    }
}