using AudiologyHardwareInventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.DataAccessLayer;
using AudiologyHardwareInventory.Interface;

namespace AudiologyHardwareInventory.Controllers
{
    //Not Using HomeController as of now...Using UNIT Testing
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITeam _hardwareOperations;


        public HomeController(ILogger<HomeController> logger, ITeam teamOperation)
        {
            _logger = logger;
            _hardwareOperations = teamOperation;
        }

        public IActionResult Index()
        {
            var result = _hardwareOperations.DisplayTeamStatus();
            return View();
        }

        public IActionResult InsertHardware()
        {
            //var dataToAdd = new Hardware
            //    { HardwareName = "HardwareTest5", HardwareStatus = "Available" };
            //_hardwareOperations.InsertNewHardware(dataToAdd);

            return View();
        }


















        [HttpPost]
        public IActionResult Data()
        {
            //////To Update Data
            //var dataToUpdate = new Student
            //    { StudentId = 1, FullName = "Test1" };
            //_studentContext.Entry(dataToUpdate).State = EntityState.Modified;
            //_studentRepository.Update();

            //////To Delete Data
            //var dataToDelete = new Student
            //{ StudentId = 3, FullName = "Test2" };
            //_studentRepository.Delete(dataToDelete);

            //////To Select Data
            //var student= _studentRepository.Select();
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
