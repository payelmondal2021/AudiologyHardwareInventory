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

        public IHearingAId HearingAIdOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<HearingAId> hearingAIdRepository = new GenericRepository<HearingAId>(context);
            IHearingAId hearingAIdOperations = new HearingAIdOperations(hearingAIdRepository, context);
            return hearingAIdOperations;
        }
        [Test]
        public void When_InsertHearingAId_Called_Then_Data_Inserted()
        {
            var dataToInsert = new HearingAId() { HearingAidName = "HearingAidName", SerialNumber = "A12", Description = "Working for AU",Status = "Working", ManufacturerId = 1, TeamId = 1,PlatformId = 1};
            _hearingAIdOperations = HearingAIdOperationsInstance();
            _hearingAIdOperations.InsertHearingAId(dataToInsert);
        }

        [Test]
        public void When_InsertHearingAId_Called_Then_Check_Argument_Type()
        {
            var fakeRepository = Substitute.For<IRepository<HearingAId>>();
            var fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            var hearingAIdOperations = new HearingAIdOperations(fakeRepository, fakeContext);
            hearingAIdOperations.InsertHearingAId(Arg.Any<HearingAId>());
        }

        [Test]
        public void When_InsertHearingAId_Called_Then_Create_Function_Received_Call_Once()
        {
            var hearingAId = new HearingAId() { HearingAidName = "HearingAidName", SerialNumber = "A12", Description = "Working for AU", Status = "Working", ManufacturerId = 1, TeamId = 1, PlatformId = 1 };
            var fakeRepository = Substitute.For<IRepository<HearingAId>>();
            var fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            var hearingAIdOperations = new HearingAIdOperations(fakeRepository, fakeContext);
            hearingAIdOperations.InsertHearingAId(hearingAId);
            fakeRepository.Received(1).Create(hearingAId);
        }
    }
}
