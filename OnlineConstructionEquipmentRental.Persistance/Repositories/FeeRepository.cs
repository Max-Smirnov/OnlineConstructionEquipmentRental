using System.Collections.Generic;
using OnlineConstructionEquipmentRental.Core.Model;
using OnlineConstructionEquipmentRental.Core.Model.Abstract;
using OnlineConstructionEquipmentRental.Persistence.Repositories.Abstract;

namespace OnlineConstructionEquipmentRental.Persistence.Repositories
{
    public class FeeRepository : IFeeRepository
    {

        public IFee Get()
        {
            return new Fee(100, 60, 40);
        }
    }
}