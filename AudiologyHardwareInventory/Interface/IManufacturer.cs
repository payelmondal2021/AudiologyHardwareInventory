using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.Models;

namespace AudiologyHardwareInventory.Interface
{
    public interface IManufacturer
    {
        void InsertManufacturer(Manufacturer manufacturer);
        void UpdateManufacturer(Manufacturer manufacturer);
        void DeleteManufacturer(Manufacturer manufacturer);
        IEnumerable<Manufacturer> DisplayManufacturer();
    }
}
