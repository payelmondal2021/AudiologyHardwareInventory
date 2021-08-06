using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AudiologyHardwareInventory.Models
{
    public class HearingAId
    {
        [Key]
        public int HearingAidId { get; set; }
        public string HearingAidName { get; set; }
        public string SerialNumber { get; set; }

        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }

        public string Status { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string FirmwareVersion { get; set; }
        public string Side { get; set; }

        public Team Team { get; set; }
        public Platform Platform { get; set; }
    }

}
