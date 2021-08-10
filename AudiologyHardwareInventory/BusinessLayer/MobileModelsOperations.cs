﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.DataAccessLayer;
using AudiologyHardwareInventory.Interface;
using AudiologyHardwareInventory.Models;

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
    }
}