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
        public IChipSet _chipSet = null;
        private IRepository<ChipSet> _fakeRepository = null;
        private HardwareInventoryContext _fakeContext = null;
        private ChipSetOperations _chipSetOperations = null;

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

        public IChipSet ChipSetOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<ChipSet> chipSetRepository = new GenericRepository<ChipSet>(context);
            IChipSet chipSetOperations = new ChipSetOperations(chipSetRepository, context);
            return chipSetOperations;
        }
        //[Test]
        //public void When_InsertChipSet_Called_Then_Data_Inserted()
        //{
        //    var dataToInsert = new ChipSet() { ChipSetName = "ImageURL", Description = "Description" };
        //    _chipSet = ChipSetOperationsInstance();
        //    _chipSet.InsertChipSet(dataToInsert);
        //}

        [Test]
        public void When_InsertChipSet_Called_Then_Check_Argument_Type()
        {
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _chipSetOperations = new ChipSetOperations(_fakeRepository, _fakeContext);
            _chipSetOperations.InsertChipSet(Arg.Any<ChipSet>());
        }
        [Test]
        public void When_InsertChipSet_Called_Then_Create_Function_Received_Call_Once()
        {
            var chipSet = new ChipSet() { ChipSetName = "ImageURL", Description = "Description" };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _chipSetOperations = new ChipSetOperations(_fakeRepository, _fakeContext);
            _chipSetOperations.InsertChipSet(chipSet);
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
            _chipSetOperations = new ChipSetOperations(_fakeRepository, _fakeContext);
            _chipSetOperations.UpdateChipSet(chipSet);
            _fakeRepository.Received(1).Update();
        }

        [Test]
        public void When_DeleteChipSet_Called_Then_Delete_Method_Receive_Call_Once()
        {
            var chipSet = new ChipSet() { ChipSetId = 1, ChipSetName = "ChipSetName", Description = "Description" };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _chipSetOperations = new ChipSetOperations(_fakeRepository, _fakeContext);
            _chipSetOperations.DeleteChipSet(chipSet);
            _fakeRepository.Received(1).Delete(chipSet);
        }

        [Test]
        public void When_SelectChipSet_Called_Then_Select_Method_Receive_Call_Once()
        {
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _chipSetOperations = new ChipSetOperations(_fakeRepository, _fakeContext);
            _chipSetOperations.DisplayChipSet();
            _fakeRepository.Received(1).Select();
        }
    }
}
