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
        public IChipset _chipSetOperations = null;

        public IChipset ChipSetOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<ChipSet> chipSetRepository = new GenericRepository<ChipSet>(context);
            IChipset chipSetOperations = new ChipsetOperations(chipSetRepository, context);
            return chipSetOperations;
        }
        [Test]
        public void When_InsertChipSet_Called_Then_Data_Inserted()
        {
            var dataToInsert = new ChipSet() { ChipSetName = "ImageURL", Description = "Description" };
            _chipSetOperations = ChipSetOperationsInstance();
            _chipSetOperations.InsertChipset(dataToInsert);
        }

        [Test]
        public void When_InsertChipSet_Called_Then_Check_Argument_Type()
        {
            var fakeRepository = Substitute.For<IRepository<Images>>();
            var fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            var imageOperations = new ImagesOperations(fakeRepository, fakeContext);
            imageOperations.InsertImages(Arg.Any<Images>());
        }
        [Test]
        public void When_InsertChipSet_Called_Then_Create_Function_Received_Call_Once()
        {
            var chipSet = new ChipSet() { ChipSetName = "ImageURL", Description = "Description" };
            var fakeRepository = Substitute.For<IRepository<ChipSet>>();
            var fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            var chipSetOperations = new ChipsetOperations(fakeRepository, fakeContext);
            chipSetOperations.InsertChipset(chipSet);
            fakeRepository.Received(1).Create(chipSet);
        }
    }
}
