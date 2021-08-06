using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.Interface;
using AudiologyHardwareInventory.Models;

namespace AudiologyHardwareInventory.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamOperations _teamOperations = null;
        public TeamController(ITeamOperations teamOperations)
        {
            this._teamOperations = teamOperations;
        }
        public IActionResult Status()
        {
           var result= _teamOperations.CheckHardwareStatus();
            return View();
        }
        public IActionResult AddNewTeam()
        {
            var teamDetails = new Team {TeamName = "AU", Description = "Working with Mobile device"};
            _teamOperations.InsertNewHardware(teamDetails);
            return View();
        }
    }
}
