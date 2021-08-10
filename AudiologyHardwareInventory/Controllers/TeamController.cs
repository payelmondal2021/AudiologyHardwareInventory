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
        //Not using TeamController as of now..Using UNIT Testing
        private readonly ITeam _teamOperations = null;
        public TeamController(ITeam teamOperations)
        {
            this._teamOperations = teamOperations;
        }

        public IActionResult Status()
        {
           var result= _teamOperations.CheckTeamStatus();
            return View();
        }
        public IActionResult AddNewTeam()
        {
            var teamDetails = new Team {TeamName = "AU", Description = "Working with Mobile device"};
            _teamOperations.InsertNewTeam(teamDetails);
            return View();
        }
    }
}
