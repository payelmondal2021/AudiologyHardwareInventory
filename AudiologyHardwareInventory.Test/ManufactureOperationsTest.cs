using System;
using System.Collections.Generic;
using System.Text;
using AudiologyHardwareInventory.BusinessLayer;
using AudiologyHardwareInventory.DataAccessLayer;
using AudiologyHardwareInventory.Interface;
using AudiologyHardwareInventory.Models;
using NSubstitute;
using NUnit.Framework;

namespace AudiologyHardwareInventory.Test
{
    [TestFixture]
    public class ManufactureOperationsTest
    {
        public IManufacturer _manufacturerOperations = null;
        private IRepository<Manufacturer> _fakeRepository = null;
        private HardwareInventoryContext _fakeContext = null;

        [SetUp]
        public void Setup()
        {
            _fakeRepository = Substitute.For<IRepository<Manufacturer>>();
        }
        [TearDown]
        public void CleanUp()
        {
            _fakeRepository = null;
            _fakeContext = null;
            _manufacturerOperations = null;
        }

        public IManufacturer ManufactureOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<Manufacturer> manufactureRepository = new GenericRepository<Manufacturer>(context);
            IManufacturer manufactureOperations = new ManufacturerOperations(manufactureRepository, context);
            return manufactureOperations;
        }
        //[Test]
        //public void When_InsertManufacturer_Called_Then_Data_Inserted()
        //{
        //    var dataToInsert = new Manufacturer() { ManufacturerName = "ManufacturerName",LogoUrl = "URL",Description = "Working for AU" };
        //    _manufacturerOperations = ManufactureOperationsInstance();
        //    _manufacturerOperations.InsertManufacturer(dataToInsert);
        //}

        [Test]
        public void When_InsertManufacturer_Called_Then_Check_Argument_Type()
        {
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _manufacturerOperations = new ManufacturerOperations(_fakeRepository, _fakeContext);
            _manufacturerOperations.InsertManufacturer(Arg.Any<Manufacturer>());
        }
        [Test]
        public void When_InsertManufacturer_Called_Then_Create_Function_Received_Call_Once()
        {
            var manufacturer = new Manufacturer() { ManufacturerName = "ManufacturerName", LogoUrl = "URL", Description = "Working for AU" };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _manufacturerOperations = new ManufacturerOperations(_fakeRepository, _fakeContext);
            _manufacturerOperations.InsertManufacturer(manufacturer);
            _fakeRepository.Received().Create(manufacturer);
        }
        //[Test]
        //public void When_UpdateManufacturer_Called_Then_Data_Updated()
        //{
        //    var dataToUpdate = new Manufacturer() {ManufacturerId = 1,ManufacturerName = "Updated_ManufacturerName", LogoUrl = "URL", Description = "Working for AU" };
        //    _manufacturerOperations = ManufactureOperationsInstance();
        //    _manufacturerOperations.UpdateManufacturer(dataToUpdate);
        //}
        [Test]
        public void When_UpdateManufacturer_Called_Then_Update_Function_Received_Call_Once()
        {
            var dataToUpdate = new Manufacturer() { ManufacturerId = 1, ManufacturerName = "Updated_ManufacturerName", LogoUrl = "URL", Description = "Working for AU" };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _manufacturerOperations = new ManufacturerOperations(_fakeRepository, _fakeContext);
            _manufacturerOperations.UpdateManufacturer(dataToUpdate);
            _fakeRepository.Received().Update();
        }

        [Test]
        public void When_DeleteManufacturer_Called_Then_Delete_Function_Received_Call_Once()
        {
            var dataToDelete = new Manufacturer() { ManufacturerId = 1, ManufacturerName = "Updated_ManufacturerName", LogoUrl = "URL", Description = "Working for AU" };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _manufacturerOperations = new ManufacturerOperations(_fakeRepository, _fakeContext);
            _manufacturerOperations.DeleteManufacturer(dataToDelete);
            _fakeRepository.Received().Delete(dataToDelete);
        }

        [Test]
        public void When_DisplayManufacturer_Called_Then_Display_Function_Received_Call_Once()
        {
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _manufacturerOperations = new ManufacturerOperations(_fakeRepository, _fakeContext);
            _manufacturerOperations.DisplayManufacturer();
            _fakeRepository.Received().Select();
        }
    }
}
