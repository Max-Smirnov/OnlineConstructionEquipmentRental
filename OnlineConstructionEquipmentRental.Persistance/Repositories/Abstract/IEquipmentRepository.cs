using System.Collections.Generic;
using OnlineConstructionEquipmentRental.Core.Model.Abstract;

namespace OnlineConstructionEquipmentRental.Persistence.Repositories.Abstract
{
    public interface IEquipmentRepository
    {
        EquipmentItem Get(int id);
        IEnumerable<EquipmentItem> GetAll();
    }
}