using System;
using System.Collections.Generic;
using System.Text;
using AudiologyHardwareInventory.BusinessLayer;
using AudiologyHardwareInventory.DataAccessLayer;
using AudiologyHardwareInventory.Interface;
using AudiologyHardwareInventory.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AudiologyHardwareInventory.Test
{
    public  class ContextInstance
    {
        public static HardwareInventoryContext CreateHardwareInventoryContext()
        {
            var contextOptions = new DbContextOptionsBuilder<HardwareInventoryContext>()
                .UseSqlServer(@"Server=MD2VGA1C\LOCAL_MS_SQL;Database=HardWareInventory;Trusted_Connection=True;MultipleActiveResultSets=True;")
                .Options;
            var context = new HardwareInventoryContext(contextOptions);
            return context;
        }

        public static HardwareInventoryContext CreateInMemoryDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<HardwareInventoryContext>()
                .UseInMemoryDatabase(databaseName: "Test Database").Options;
            var dbContext = new HardwareInventoryContext(options);
            return dbContext;
        }
    }
}
