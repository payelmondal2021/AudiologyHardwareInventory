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
using ImagesOperations = AudiologyHardwareInventory.BusinessLayer.ImagesOperations;

namespace AudiologyHardwareInventory.Test
{
    [TestFixture]
    public class ImagesOperationTest
    {
        public IImages _imagesOperations = null;

        public IImages ImagesOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<Images> imagesRepository = new GenericRepository<Images>(context);
            IImages imagesOperations = new ImagesOperations(imagesRepository, context);
            return imagesOperations;
        }
        [Test]
        public void When_InsertImages_Called_Then_Data_Inserted()
        {
            var dataToInsert = new Images() { ImageUrl = "ImageURL", HearingAidId = 1};
            _imagesOperations = ImagesOperationsInstance();
            _imagesOperations.InsertImages(dataToInsert);
        }

        [Test]
        public void When_InsertImages_Called_Then_Check_Argument_Type()
        {
            var fakeRepository = Substitute.For<IRepository<Images>>();
            var fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            var imageOperations = new ImagesOperations(fakeRepository, fakeContext);
            imageOperations.InsertImages(Arg.Any<Images>());
        }

        [Test]
        public void When_InsertImages_Called_Then_Create_Function_Received_Call_Once()
        {
            var image = new Images() { ImageUrl = "ImageURL", HearingAidId = 1 };
            var fakeRepository = Substitute.For<IRepository<Images>>();
            var fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            var imageOperations = new ImagesOperations(fakeRepository, fakeContext);
            imageOperations.InsertImages(image);
            fakeRepository.Received(1).Create(image);
        }
    }
}
