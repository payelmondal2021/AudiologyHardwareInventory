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
    public class ChipSetOperationsTest
    {
        public IChipset _chipSet = null;
        private IRepository<ChipSet> _fakeRepository = null;
        private HardwareInventoryContext _fakeContext = null;
        private ChipsetOperations _chipSetOperations = null;

        [SetUp]
        public void Setup()
        {
            _fakeRepository = Substitute.For<IRepository<ChipSet>>();
        }
        [TearDown]
        public void CleanUp()
        {
            _fakeRepository = null;
            _fakeContext = null;
            _chipSetOperations = null;
        }

        public IChipset ChipSetOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<ChipSet> chipSetRepository = new GenericRepository<ChipSet>(context);
            IChipset chipSetOperations = new ChipsetOperations(chipSetRepository, context);
            return chipSetOperations;
        }
        //[Test]
        //public void When_InsertChipSet_Called_Then_Data_Inserted()
        //{
        //    var dataToInsert = new ChipSet() { ChipSetName = "ImageURL", Description = "Description" };
        //    _chipSet = ChipSetOperationsInstance();
        //    _chipSet.InsertChipset(dataToInsert);
        //}

        [Test]
        public void When_InsertChipSet_Called_Then_Check_Argument_Type()
        {
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _chipSetOperations = new ChipsetOperations(_fakeRepository, _fakeContext);
            _chipSetOperations.InsertChipset(Arg.Any<ChipSet>());
        }
        [Test]
        public void When_InsertChipSet_Called_Then_Create_Function_Received_Call_Once()
        {
            var chipSet = new ChipSet() { ChipSetName = "ImageURL", Description = "Description" };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _chipSetOperations = new ChipsetOperations(_fakeRepository, _fakeContext);
            _chipSetOperations.InsertChipset(chipSet);
            _fakeRepository.Received(1).Create(chipSet);
        }
        //[Test]
        //public void When_UpdateChipSet_Called_Then_Data_Updated_In_Database()
        //{
        //    var dataToUpdate = new ChipSet() { ChipSetId = 4, ChipSetName = "UpdatedChipSet", Description = "UpdatedDescription" };
        //    _chipSet = ChipSetOperationsInstance();
        //    _chipSet.UpdateChipSet(dataToUpdate);
        //}

        [Test]
        public void When_UpdateChipSet_Called_Then_Update_Method_Receive_Call_Once()
        {
            var chipSet = new ChipSet() {ChipSetId = 1,ChipSetName = "ChipSetName", Description = "Description" };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _chipSetOperations = new ChipsetOperations(_fakeRepository, _fakeContext);
            _chipSetOperations.UpdateChipSet(chipSet);
            _fakeRepository.Received(1).Update();
        }
    }
}
