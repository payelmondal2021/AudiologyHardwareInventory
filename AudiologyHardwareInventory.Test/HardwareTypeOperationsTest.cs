using System;
using System.Collections.Generic;
using System.Text;
using AudiologyHardwareInventory.BusinessLayer;
using AudiologyHardwareInventory.DataAccessLayer;
using AudiologyHardwareInventory.Interface;
using AudiologyHardwareInventory.Models;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AudiologyHardwareInventory.Test
{
    [TestFixture]
    public class HardwareTypeOperationsTest
    {
        public IHardwareType _hardwareTypeOperations = null;
        private IRepository<HardwareType> _fakeRepository = null;
        private HardwareInventoryContext _fakeContext = null;

        [SetUp]
        public void Setup()
        {
            _fakeRepository = Substitute.For<IRepository<HardwareType>>();
        }
        [TearDown]
        public void CleanUp()
        {
            _fakeRepository = null;
            _fakeContext = null;
            _hardwareTypeOperations = null;
        }
        public IHardwareType HardwareTypeOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<HardwareType> hardwareTypeRepository = new GenericRepository<HardwareType>(context);
            IHardwareType hardwareTypeOperations = new HardwareTypeOperations(hardwareTypeRepository,context);
            return hardwareTypeOperations;
        }
        //[Test]
        //public void When_InsertHardwareType_Called_Then_Data_Inserted()
        //{
        //    var dataToInsert = new HardwareType() { HardwareName = "HardWreName1", Description = "Working for AU" };
        //    _hardwareTypeOperations = HardwareTypeOperationsInstance();
        //    _hardwareTypeOperations.InsertHardwareType(dataToInsert);
        //}

        [Test]
        public void When_InsertHardwareType_Called_Then_Check_Argument_Type()
        {
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _hardwareTypeOperations = new HardwareTypeOperations(_fakeRepository, _fakeContext);
            _hardwareTypeOperations.InsertHardwareType(Arg.Any<HardwareType>());
        }
        [Test]
        public void When_InsertHardwareType_Called_Then_Create_Function_Received_Call_Once()
        {
            var hardwareType = new HardwareType() { HardwareName = "HardWreName1", Description = "Working for AU" };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _hardwareTypeOperations = new HardwareTypeOperations(_fakeRepository, _fakeContext);
            _hardwareTypeOperations.InsertHardwareType(hardwareType);
            _fakeRepository.Received(1).Create(hardwareType);
        }

        //[Test]
        //public void When_UpdateHardwareType_Called_Then_Data_Updated()
        //{
        //    var dataToInsert = new HardwareType() {HardwareTypeId = 1,HardwareName = "Updated_HardWreName", Description = "Working for AU" };
        //    _hardwareTypeOperations = HardwareTypeOperationsInstance();
        //    _hardwareTypeOperations.UpdateHardwareType(dataToInsert);
        //}
        [Test]
        public void When_UpdateHardwareType_Called_Then_Update_Function_Received_Call_Once()
        {
            var hardwareType = new HardwareType() {HardwareTypeId = 1,HardwareName = "Update_HardWreName1", Description = "Working for AU" };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _hardwareTypeOperations = new HardwareTypeOperations(_fakeRepository, _fakeContext);
            _hardwareTypeOperations.UpdateHardwareType(hardwareType);
            _fakeRepository.Received(1).Update();
        }
    }
}
