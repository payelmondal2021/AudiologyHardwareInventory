using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AudiologyHardwareInventory.Models;
using Microsoft.EntityFrameworkCore;

namespace AudiologyHardwareInventory.DataAccessLayer
{
    public class HardwareInventoryContext:DbContext
    {
        public HardwareInventoryContext(DbContextOptions<HardwareInventoryContext> options) : base(options)
        {

        }

        public DbSet<Team> Team { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Platform> Platform { get; set; }
        public DbSet<HearingAId> HearingAId { get; set; } 
        public DbSet<Images> Images { get; set; }
        public DbSet<ChipSet> ChipsSet { get; set; }
        public DbSet<Mobile> Mobile { get; set; }
        public DbSet<MobileModels> MobileModels { get; set; }
        public DbSet<HardwareType> HardwareType { get; set; }
    }
}
