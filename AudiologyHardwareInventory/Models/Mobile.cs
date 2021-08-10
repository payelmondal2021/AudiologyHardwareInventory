using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AudiologyHardwareInventory.Models
{
    public class Mobile
    {
        [Key]
        public int MobileId { get; set; }
        [ForeignKey("MobileModels")]
        public int ModelId { get; set; }
        public MobileModels MobileModels { get; set; }
        public string OSVersion { get; set; }
        [ForeignKey("ChipSet")]
        public int ChipSetId { get; set; }
        public ChipSet ChipSet { get; set; }
        public string ProcessorArchitecture { get; set; }
        public string DisplayInInches { get; set; }
        public int SupportedProtocol { get; set; }
        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public string Resolution { get; set; }

  

    }
}
