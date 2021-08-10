﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.DataAccessLayer;
using AudiologyHardwareInventory.Interface;
using AudiologyHardwareInventory.Models;

namespace AudiologyHardwareInventory.BusinessLayer
{
    public class PlatformOperations : IPlatform
    {
        private readonly IRepository<Platform> _platformRepository;
        private readonly HardwareInventoryContext _hardwareInventoryContext = null;

        public PlatformOperations(IRepository<Platform> platformRepository, HardwareInventoryContext hardwareInventoryContext)
        {
            this._platformRepository = platformRepository;
            this._hardwareInventoryContext = hardwareInventoryContext;
        }
        public void InsertPlatform(Platform platform)
        {
            _platformRepository.Create(platform);
        }
    }
}
