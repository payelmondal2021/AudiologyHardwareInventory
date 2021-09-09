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
    public class MobileModelsOperations:IMobileModels
    {
        private readonly IRepository<MobileModels> _mobileModelRepository;
        private readonly HardwareInventoryContext _hardwareInventoryContext = null;
        public MobileModelsOperations(IRepository<MobileModels> mobileModelRepository, HardwareInventoryContext hardwareInventoryContext)
        {
            this._mobileModelRepository = mobileModelRepository;
            this._hardwareInventoryContext = hardwareInventoryContext;
        }

        public void InsertMobileModels(MobileModels mobileModels)
        {
            _mobileModelRepository.Create(mobileModels);
        }
        public void UpdateMobileModels(MobileModels mobileModels)
        {
            _hardwareInventoryContext.Entry(mobileModels).State = EntityState.Modified;
            _mobileModelRepository.Update();
        }
        public void DeleteMobileModels(MobileModels mobileModels)
        {
            _mobileModelRepository.Delete(mobileModels);
        }
        public IEnumerable<MobileModels> DisplayMobileModels()
        {
           return _mobileModelRepository.Select();
        }
    }
}
