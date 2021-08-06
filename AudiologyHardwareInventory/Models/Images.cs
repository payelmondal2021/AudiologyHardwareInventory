using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AudiologyHardwareInventory.Models
{
    public class Images
    {
        //ImageUrlId
        //    HearingAidID
        //ImageUrl

        [Key]
        public int ImageUrlId { get; set; }
        public HearingAId HearingAidNumber { get; set; }
        public string ImageUrl { get; set; }

    }
}
