using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.DataAccessLayer;
using AudiologyHardwareInventory.Interface;
using AudiologyHardwareInventory.Models;
using Microsoft.EntityFrameworkCore;

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
        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            _hardwareInventoryContext.Entry(manufacturer).State = EntityState.Modified;
            _manufactureRepository.Update();
        }
        public void DeleteManufacturer(Manufacturer manufacturer)
        {
            _manufactureRepository.Delete(manufacturer);
        }
        public IEnumerable<Manufacturer> DisplayManufacturer()
        {
           return _manufactureRepository.Select();
        }

    }
}
