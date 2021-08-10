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
    public class HearingAIdOperationsTest
    {
        public IHearingAId _hearingAIdOperations = null;
        private IRepository<HearingAId> _fakeRepository = null;
        private HardwareInventoryContext _fakeContext = null;

        [SetUp]
        public void Setup()
        {
            _fakeRepository = Substitute.For<IRepository<HearingAId>>();
        }
        [TearDown]
        public void CleanUp()
        {
            _fakeRepository = null;
            _fakeContext = null;
            _hearingAIdOperations = null;
        }

        public IHearingAId HearingAIdOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<HearingAId> hearingAIdRepository = new GenericRepository<HearingAId>(context);
            IHearingAId hearingAIdOperations = new HearingAIdOperations(hearingAIdRepository, context);
            return hearingAIdOperations;
        }
        //[Test]
        //public void When_InsertHearingAId_Called_Then_Data_Inserted()
        //{
        //    var dataToInsert = new HearingAId() { HearingAidName = "HearingAidName", SerialNumber = "A12", Description = "Working for AU",Status = "Working", ManufacturerId = 1, TeamId = 1,PlatformId = 1};
        //    _hearingAIdOperations = HearingAIdOperationsInstance();
        //    _hearingAIdOperations.InsertHearingAId(dataToInsert);
        //}

        [Test]
        public void When_InsertHearingAId_Called_Then_Check_Argument_Type()
        {
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _hearingAIdOperations = new HearingAIdOperations(_fakeRepository, _fakeContext);
            _hearingAIdOperations.InsertHearingAId(Arg.Any<HearingAId>());
        }

        [Test]
        public void When_InsertHearingAId_Called_Then_Create_Function_Received_Call_Once()
        {
            var hearingAId = new HearingAId() { HearingAidName = "HearingAidName", SerialNumber = "A12", Description = "Working for AU", Status = "Working", ManufacturerId = 1, TeamId = 1, PlatformId = 1 };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _hearingAIdOperations = new HearingAIdOperations(_fakeRepository, _fakeContext);
            _hearingAIdOperations.InsertHearingAId(hearingAId);
            _fakeRepository.Received(1).Create(hearingAId);
        }
        //[Test]
        //public void When_UpdateHearingAId_Called_Then_Data_Updated()
        //{
        //    var dataToInsert = new HearingAId() {HearingAidId = 1,HearingAidName = "HearingAidName", Side="test",SerialNumber = "A12", Description = "Working for AU", Status = "Working", ManufacturerId = 1, TeamId = 1, PlatformId = 1 };
        //    _hearingAIdOperations = HearingAIdOperationsInstance();
        //    _hearingAIdOperations.UpdateHearingAId(dataToInsert);
        //}
        [Test]
        public void When_UpdateHearingAId_Called_Then_Update_Function_Received_Call_Once()
        {
            var hearingAId = new HearingAId() { HearingAidId = 1, HearingAidName = "HearingAidName", Side = "test", SerialNumber = "A12", Description = "Working for AU", Status = "Working", ManufacturerId = 1, TeamId = 1, PlatformId = 1 };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _hearingAIdOperations = new HearingAIdOperations(_fakeRepository, _fakeContext);
            _hearingAIdOperations.UpdateHearingAId(hearingAId);
            _fakeRepository.Received(1).Update();
        }
    }
}
