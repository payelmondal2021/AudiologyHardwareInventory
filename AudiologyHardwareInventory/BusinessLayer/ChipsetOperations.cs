using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.DataAccessLayer;
using AudiologyHardwareInventory.Interface;
using AudiologyHardwareInventory.Models;

namespace AudiologyHardwareInventory.BusinessLayer
{
    public class ChipsetOperations:IChipset
    {
        private readonly IRepository<ChipSet> _chipsetRepository;
        private readonly HardwareInventoryContext _hardwareInventoryContext = null;
        public ChipsetOperations(IRepository<ChipSet> chipsetRepository, HardwareInventoryContext hardwareInventoryContext)
        {
            this._chipsetRepository = chipsetRepository;
            this._hardwareInventoryContext = hardwareInventoryContext;
        }

        public void InsertChipset(ChipSet chipset)
        {
            _chipsetRepository.Create(chipset);
        }
    }
}
