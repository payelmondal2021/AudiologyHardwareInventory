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
        public void UpdateHearingAId(HearingAId hearingAId)
        {
            _hardwareInventoryContext.Entry(hearingAId).State = EntityState.Modified;
            _hearingAIdRepository.Update();
        }
        public void DeleteHearingAId(HearingAId hearingAId)
        {
            _hearingAIdRepository.Delete(hearingAId);
        }
        public void DisplayHearingAId()
        {
            _hearingAIdRepository.Select();
        }
    }
}
