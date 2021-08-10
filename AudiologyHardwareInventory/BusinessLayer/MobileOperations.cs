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
    public class MobileOperations:IMobile
    {
        private readonly IRepository<Mobile> _mobileRepository;
        private readonly HardwareInventoryContext _hardwareInventoryContext = null;
        public MobileOperations(IRepository<Mobile> mobileRepository, HardwareInventoryContext hardwareInventoryContext)
        {
            this._mobileRepository = mobileRepository;
            this._hardwareInventoryContext = hardwareInventoryContext;
        }

        public void InsertMobile(Mobile mobile)
        {
            _mobileRepository.Create(mobile);
        }
        public void UpdateMobile(Mobile mobile)
        {
            _hardwareInventoryContext.Entry(mobile).State = EntityState.Modified;
            _mobileRepository.Update();
        }
    }
}
