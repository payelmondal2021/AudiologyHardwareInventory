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
    public class PlatformOperationsTest
    {
        public IPlatform _platformOperations = null;

        public IPlatform PlatformOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<Platform> platformRepository = new GenericRepository<Platform>(context);
            IPlatform platformOperations = new PlatformOperations(platformRepository, context);
            return platformOperations;
        }
        [Test]
        public void When_InsertPlatform_Called_Then_Data_Inserted()
        {
            var dataToInsert = new Platform() { PlatformName = "PlatformName",  Description = "Working for AU" };
            _platformOperations = PlatformOperationsInstance();
            _platformOperations.InsertPlatform(dataToInsert);
        }

        [Test]
        public void When_InsertPlatform_Called_Then_Check_Argument_Type()
        {
            var fakeRepository = Substitute.For<IRepository<Platform>>();
            var fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            var platformOperations = new PlatformOperations(fakeRepository, fakeContext);
            platformOperations.InsertPlatform(Arg.Any<Platform>());
        }
        [Test]
        public void When_InsertPlatform_Called_Then_Create_Function_Received_Call_Once()
        {
            var platform = new Platform() { PlatformName = "PlatformName", Description = "Working for AU" };
            var fakeRepository = Substitute.For<IRepository<Platform>>();
            var fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            var manufacturerOperations = new PlatformOperations(fakeRepository, fakeContext);
            manufacturerOperations.InsertPlatform(platform);
            fakeRepository.Received(1).Create(platform);
        }
    }
}
