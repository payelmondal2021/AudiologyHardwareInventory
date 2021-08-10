using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.DataAccessLayer;
using AudiologyHardwareInventory.Interface;
using AudiologyHardwareInventory.Models;

namespace AudiologyHardwareInventory.BusinessLayer
{
    public class ManufacturerOperations:IManufacturer
    {
        private readonly IRepository<Manufacturer> _manufactureRepository;
        private readonly HardwareInventoryContext _hardwareInventoryContext = null;
        public ManufacturerOperations(IRepository<Manufacturer> manufactureRepository, HardwareInventoryContext hardwareInventoryContext)
        {
            this._manufactureRepository = manufactureRepository;
            this._hardwareInventoryContext = hardwareInventoryContext;
        }

        public void InsertManufacturer(Manufacturer manufacturer)
        {
            _manufactureRepository.Create(manufacturer);
        }

    }
}
