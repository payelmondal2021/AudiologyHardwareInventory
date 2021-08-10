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

        public IHardwareType HardwareTypeOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<HardwareType> hardwareTypeRepository = new GenericRepository<HardwareType>(context);
            IHardwareType hardwareTypeOperations = new HardwareTypeOperations(hardwareTypeRepository,context);
            return hardwareTypeOperations;
        }
        [Test]
        public void When_InsertHardwareType_Called_Then_Data_Inserted()
        {
            var dataToInsert = new HardwareType() { HardwareName = "HardWreName1", Description = "Working for AU" };
            _hardwareTypeOperations = HardwareTypeOperationsInstance();
            _hardwareTypeOperations.InsertHardwareType(dataToInsert);
        }

        [Test]
        public void When_InsertHardwareType_Called_Then_Check_Argument_Type()
        {
            var fakeRepository = Substitute.For<IRepository<HardwareType>>();
            var fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            var hardwareTypeOperations = new HardwareTypeOperations(fakeRepository, fakeContext);
            hardwareTypeOperations.InsertHardwareType(Arg.Any<HardwareType>());
        }
        [Test]
        public void When_InsertHardwareType_Called_Then_Create_Function_Received_Call_Once()
        {
            var hardwareType = new HardwareType() { HardwareName = "HardWreName1", Description = "Working for AU" };
            var fakeRepository = Substitute.For<IRepository<HardwareType>>();
            var fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            var hardwareTypeOperations = new HardwareTypeOperations(fakeRepository, fakeContext);
            hardwareTypeOperations.InsertHardwareType(hardwareType);
            fakeRepository.Received(1).Create(hardwareType);
        }
    }
}
