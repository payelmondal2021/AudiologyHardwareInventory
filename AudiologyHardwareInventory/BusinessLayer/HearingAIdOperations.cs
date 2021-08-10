using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.DataAccessLayer;
using AudiologyHardwareInventory.Interface;
using AudiologyHardwareInventory.Models;

namespace AudiologyHardwareInventory.BusinessLayer
{
    public class HearingAIdOperations:IHearingAId
    {
        private readonly IRepository<HearingAId> _hearingAIdRepository;
        private readonly HardwareInventoryContext _hardwareInventoryContext = null;
        public HearingAIdOperations(IRepository<HearingAId> hearingAIdRepository, HardwareInventoryContext hardwareInventoryContext)
        { 
            this._hearingAIdRepository = hearingAIdRepository;
            this._hardwareInventoryContext = hardwareInventoryContext;
        }
        
        public void InsertHearingAId(HearingAId hearingAId)
        {
            _hearingAIdRepository.Create(hearingAId);
        }
    }
}
