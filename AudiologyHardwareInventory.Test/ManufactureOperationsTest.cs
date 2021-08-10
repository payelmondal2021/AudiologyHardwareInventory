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

        public IManufacturer ManufactureOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<Manufacturer> manufactureRepository = new GenericRepository<Manufacturer>(context);
            IManufacturer manufactureOperations = new ManufacturerOperations(manufactureRepository, context);
            return manufactureOperations;
        }
        [Test]
        public void When_InsertManufacturer_Called_Then_Data_Inserted()
        {
            var dataToInsert = new Manufacturer() { ManufacturerName = "ManufacturerName",LogoUrl = "URL",Description = "Working for AU" };
            _manufacturerOperations = ManufactureOperationsInstance();
            _manufacturerOperations.InsertManufacturer(dataToInsert);
        }

        [Test]
        public void When_InsertManufacturer_Called_Then_Check_Argument_Type()
        {
            var fakeRepository = Substitute.For<IRepository<Manufacturer>>();
            var fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            var manufacturerOperations = new ManufacturerOperations(fakeRepository, fakeContext);
            manufacturerOperations.InsertManufacturer(Arg.Any<Manufacturer>());
        }
        [Test]
        public void When_InsertManufacturer_Called_Then_Create_Function_Received_Call_Once()
        {
            var manufacturer = new Manufacturer() { ManufacturerName = "ManufacturerName", LogoUrl = "URL", Description = "Working for AU" };
            var fakeRepository = Substitute.For<IRepository<Manufacturer>>();
            var fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            var manufacturerOperations = new ManufacturerOperations(fakeRepository, fakeContext);
            manufacturerOperations.InsertManufacturer(manufacturer);
            fakeRepository.Received().Create(manufacturer);
        }
    }
}
