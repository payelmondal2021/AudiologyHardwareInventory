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
    public class HardwareTypeOperations:IHardwareType
    {
        private readonly IRepository<HardwareType> _imagesRepository;
        private readonly HardwareInventoryContext _hardwareInventoryContext = null;
        public HardwareTypeOperations(IRepository<HardwareType> hardwareTypeRepository, HardwareInventoryContext hardwareInventoryContext)
        {
            this._imagesRepository = hardwareTypeRepository;
            this._hardwareInventoryContext = hardwareInventoryContext;
        }
        public void InsertHardwareType(HardwareType hardwareType)
        {
            _imagesRepository.Create(hardwareType);
        }
        public void UpdateHardwareType(HardwareType hardwareType)
        {
            _hardwareInventoryContext.Entry(hardwareType).State = EntityState.Modified;
            _imagesRepository.Update();
        }
    }
}
