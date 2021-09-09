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
        private IRepository<Mobile> _fakeRepository = null;
        private HardwareInventoryContext _fakeContext = null;

        [SetUp]
        public void Setup()
        {
            _fakeRepository = Substitute.For<IRepository<Mobile>>();
        }
        [TearDown]
        public void CleanUp()
        {
            _fakeRepository = null;
            _fakeContext = null;
            _mobileOperations = null;
        }


        public IMobile MobileOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<Mobile> mobileRepository = new GenericRepository<Mobile>(context);
            IMobile mobileOperations = new MobileOperations(mobileRepository, context);
            return mobileOperations;
        }
        ////[Test]
        //public void When_InsertMobile_Called_Then_Data_Inserted()
        //{
        //    var dataToInsert = new Mobile() { ModelId = 1,OSVersion = "2",ChipSetId = 1,DisplayInInches = "20",TeamId = 1 };
        //    _mobileOperations = MobileOperationsInstance();
        //    _mobileOperations.InsertMobile(dataToInsert);
        //}

        [Test]
        public void When_InsertMobile_Called_Then_Check_Argument_Type()
        {
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _mobileOperations = new MobileOperations(_fakeRepository, _fakeContext);
            _mobileOperations.InsertMobile(Arg.Any<Mobile>());
        }
        [Test]
        public void When_InsertMobile_Function_Called_Then_Create_Function_Received_Call_Once()
        {
            var mobile = new Mobile() { ModelId = 1, OSVersion = "2", ChipSetId = 1, DisplayInInches = "20", TeamId = 1 };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            var mobileOperations = new MobileOperations(_fakeRepository, _fakeContext);
            mobileOperations.InsertMobile(mobile);
            _fakeRepository.Received(1).Create(mobile);
        }

        //[Test]
        //public void When_UpdateMobile_Called_Then_Data_Updated()
        //{
        //    var mobile = new Mobile() { MobileId = 1, ModelId = 1, OSVersion = "2", ChipSetId = 1, DisplayInInches = "Updated_20", TeamId = 1 };
        //    _mobileOperations = MobileOperationsInstance();
        //    _mobileOperations.UpdateMobile(mobile);
        //}

        [Test]
        public void When_UpdateMobile_Function_Called_Then_Update_Function_Received_Call_Once()
        {
            var mobile = new Mobile() {MobileId = 1,ModelId = 1, OSVersion = "2", ChipSetId = 1, DisplayInInches = "Updated_20", TeamId = 1 };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _mobileOperations = new MobileOperations(_fakeRepository, _fakeContext);
            _mobileOperations.UpdateMobile(mobile);
            _fakeRepository.Received(1).Update();
        }

        [Test]
        public void When_DeleteMobile_Function_Called_Then_Delete_Function_Received_Call_Once()
        {
            var mobile = new Mobile() { MobileId = 1, ModelId = 1, OSVersion = "2", ChipSetId = 1, DisplayInInches = "Updated_20", TeamId = 1 };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _mobileOperations = new MobileOperations(_fakeRepository, _fakeContext);
            _mobileOperations.DeleteMobile(mobile);
            _fakeRepository.Received(1).Delete(mobile);
        }

        [Test]
        public void When_DisplayMobile_Function_Called_Then_Select_Function_Received_Call_Once()
        {
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _mobileOperations = new MobileOperations(_fakeRepository, _fakeContext);
            _mobileOperations.DisplayMobile();
            _fakeRepository.Received(1).Select();
        }


    }
}
