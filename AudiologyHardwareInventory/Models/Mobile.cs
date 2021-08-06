using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AudiologyHardwareInventory.Models
{
    public class Mobile
    {
        [Key]
        public int MobileId { get; set; }
        public string ModelId { get; set; }
        public string OSVersion { get; set; }
        public ChipSet ChipSet { get; set; }
        public string ProcessorArchitecture { get; set; }
        public string DisplayInInches { get; set; }
        public int SupportedProtocol { get; set; }
        public Team Team { get; set; }
        public string Resolution { get; set; }

  

    }
}
