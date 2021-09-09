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
        private IRepository<Images> _fakeRepository = null;
        private HardwareInventoryContext _fakeContext = null;

        [SetUp]
        public void Setup()
        {
            _fakeRepository = Substitute.For<IRepository<Images>>();
        }
        [TearDown]
        public void CleanUp()
        {
            _fakeRepository = null;
            _fakeContext = null;
            _imagesOperations = null;
        }

        public IImages ImagesOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<Images> imagesRepository = new GenericRepository<Images>(context);
            IImages imagesOperations = new ImagesOperations(imagesRepository, context);
            return imagesOperations;
        }
        //[Test]
        //public void When_InsertImages_Called_Then_Data_Inserted()
        //{
        //    var dataToInsert = new Images() { ImageUrl = "ImageURL", HearingAidId = 1 };
        //    _imagesOperations = ImagesOperationsInstance();
        //    _imagesOperations.InsertImages(dataToInsert);
        //}

        [Test]
        public void When_InsertImages_Called_Then_Check_Argument_Type()
        {
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _imagesOperations = new ImagesOperations(_fakeRepository, _fakeContext);
            _imagesOperations.InsertImages(Arg.Any<Images>());
        }

        [Test]
        public void When_InsertImages_Called_Then_Create_Function_Received_Call_Once()
        {
            var image = new Images() { ImageUrl = "ImageURL", HearingAidId = 1 };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _imagesOperations = new ImagesOperations(_fakeRepository, _fakeContext);
            _imagesOperations.InsertImages(image);
            _fakeRepository.Received(1).Create(image);
        }
        //[Test]
        //public void When_UpdateImages_Called_Then_Data_Updated()
        //{
        //    var dataToUpdate = new Images() {ImageUrlId = 3,ImageUrl = "UpdatedImageURL", HearingAidId = 1 };
        //    _imagesOperations = ImagesOperationsInstance();
        //    _imagesOperations.UpdateImages(dataToUpdate);
        //}
        [Test]
        public void When_UpdateImages_Called_Then_Update_Function_Received_Call_Once()
        {
             var image = new Images() { ImageUrl = "ImageURL", HearingAidId = 1 };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _imagesOperations = new ImagesOperations(_fakeRepository, _fakeContext);
            _imagesOperations.UpdateImages(image);
            _fakeRepository.Received(1).Update();
        }

        [Test]
        public void When_DeleteImages_Called_Then_Delete_Function_Received_Call_Once()
        {
             var image = new Images() { ImageUrl = "ImageURL", HearingAidId = 1 };
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _imagesOperations = new ImagesOperations(_fakeRepository, _fakeContext);
            _imagesOperations.DeleteImages(image);
            _fakeRepository.Received(1).Delete(image);
        }

        [Test]
        public void When_SelectImages_Called_Then_Delete_Function_Received_Call_Once()
        {
            _fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            _imagesOperations = new ImagesOperations(_fakeRepository, _fakeContext);
            _imagesOperations.DisplayImages();
            _fakeRepository.Received(1).Select();
        }
    }
}
