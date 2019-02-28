using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OnlineConstructionEquipmentRental.Core.Model.Abstract;
using OnlineConstructionEquipmentRental.Persistence.Repositories.Abstract;

namespace OnlineConstructionEquipmentRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Default")]
    public class EquipmentController : ControllerBase
    {
        public IEquipmentRepository EquipmentRepo { get; }

        public EquipmentController(IEquipmentRepository equipmentRepo)
        {
            EquipmentRepo = equipmentRepo;
        }

        // GET api/equipment
        [HttpGet]
        public IEnumerable<EquipmentItem> Get()
        {
            return EquipmentRepo.GetAll();
        }

        // GET api/equipment/5
        [HttpGet("{id}")]
        public EquipmentItem Get(int id)
        {
            return EquipmentRepo.Get(id);
        }
    }
}
