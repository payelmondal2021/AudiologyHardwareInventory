using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.DataAccessLayer;
using AudiologyHardwareInventory.Interface;
using AudiologyHardwareInventory.Models;
using Microsoft.AspNetCore.Mvc;

namespace AudiologyHardwareInventory.BusinessLayer
{
    public class TeamOperations : ITeam
    {
        private readonly IRepository<Team> _teamRepository;
        private readonly HardwareInventoryContext _hardwareInventoryContext = null;
       
        public TeamOperations(IRepository<Team> teamRepository, HardwareInventoryContext hardwareInventoryContext)
        {
            this._teamRepository = teamRepository;
            this._hardwareInventoryContext = hardwareInventoryContext;
        }
        public IEnumerable<Team> CheckTeamStatus()
        {
            return _teamRepository.Select();
        }

        public void InsertNewTeam(Team teamDetails)
        {
            _teamRepository.Create(teamDetails);
        }
    }
}
