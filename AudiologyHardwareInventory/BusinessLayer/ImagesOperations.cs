using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.DataAccessLayer;
using AudiologyHardwareInventory.Interface;
using AudiologyHardwareInventory.Models;

namespace AudiologyHardwareInventory.BusinessLayer
{
    public class ImagesOperations : IImages
    {
        private readonly IRepository<Images> _imagesRepository;
        private readonly HardwareInventoryContext _hardwareInventoryContext = null;
        public ImagesOperations(IRepository<Images> imagesRepositoryRepository, HardwareInventoryContext hardwareInventoryContext)
        {
            this._imagesRepository = imagesRepositoryRepository;
            this._hardwareInventoryContext = hardwareInventoryContext;
        }
        public void InsertImages(Images images)
        {
            _imagesRepository.Create(images);
        }
    }
}
