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
    public class MobileModelsOperationsTest
    {
        public IMobileModels _mobileModelsOperations = null;

        public IMobileModels MobileModelsOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<MobileModels> mobileModelsRepository = new GenericRepository<MobileModels>(context);
            IMobileModels mobileModelsOperations = new MobileModelsOperations(mobileModelsRepository, context);
            return mobileModelsOperations;
        }
        [Test]
        public void When_InsertMobileModels_Called_Then_Data_Inserted()
        {
            var dataToInsert = new MobileModels() { ModelName = "MobileModels", Description = "Description" };
            _mobileModelsOperations = MobileModelsOperationsInstance();
            _mobileModelsOperations.InsertMobileModels(dataToInsert);
        }

        [Test]
        public void When_InsertMobileModels_Called_Then_Check_Argument_Type()
        {
            var fakeRepository = Substitute.For<IRepository<MobileModels>>();
            var fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            var mobileModelsOperations = new MobileModelsOperations(fakeRepository, fakeContext);
            mobileModelsOperations.InsertMobileModels(Arg.Any<MobileModels>());
        }
        [Test]
        public void When_InsertMobileModels_Called_Then_Create_Function_Received_Call_Once()
        {
            var mobileModel = new MobileModels() { ModelName = "MobileModels", Description = "Description" };
            var fakeRepository = Substitute.For<IRepository<MobileModels>>();
            var fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            var mobileModelOperations = new MobileModelsOperations(fakeRepository, fakeContext);
            mobileModelOperations.InsertMobileModels(mobileModel);
            fakeRepository.Received(1).Create(mobileModel);
        }
    }
}
