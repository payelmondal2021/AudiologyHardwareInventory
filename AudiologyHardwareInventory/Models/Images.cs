using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AudiologyHardwareInventory.Models
{
    public class Images
    {
        [Key]
        public int ImageUrlId { get; set; }
        [ForeignKey("HearingAid")]
        public int HearingAidId { get; set; }
        public HearingAId HearingAId { get; set; }
        public string ImageUrl { get; set; }

    }
}
