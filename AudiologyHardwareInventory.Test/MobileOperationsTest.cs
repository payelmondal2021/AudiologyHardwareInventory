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
    public class MobileOperationsTest
    {
        public IMobile _mobileOperations = null;

        public IMobile MobileOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<Mobile> mobileRepository = new GenericRepository<Mobile>(context);
            IMobile mobileOperations = new MobileOperations(mobileRepository, context);
            return mobileOperations;
        }
        [Test]
        public void When_InsertMobile_Called_Then_Data_Inserted()
        {
            var dataToInsert = new Mobile() { ModelId = 1,OSVersion = "2",ChipSetId = 1,DisplayInInches = "20",TeamId = 1 };
            _mobileOperations = MobileOperationsInstance();
            _mobileOperations.InsertMobile(dataToInsert);
        }

        [Test]
        public void When_InsertMobile_Called_Then_Check_Argument_Type()
        {
            var fakeRepository = Substitute.For<IRepository<Mobile>>();
            var fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            var mobileOperations = new MobileOperations(fakeRepository, fakeContext);
            mobileOperations.InsertMobile(Arg.Any<Mobile>());
        }
        [Test]
        public void When_InsertMobile_Function_Called_Then_Create_Function_Received_Call_Once()
        {
            var mobile = new Mobile() { ModelId = 1, OSVersion = "2", ChipSetId = 1, DisplayInInches = "20", TeamId = 1 };
            var fakeRepository = Substitute.For<IRepository<Mobile>>();
            var fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            var mobileOperations = new MobileOperations(fakeRepository, fakeContext);
            mobileOperations.InsertMobile(mobile);
            fakeRepository.Received(1).Create(mobile);
        }


    }
}
