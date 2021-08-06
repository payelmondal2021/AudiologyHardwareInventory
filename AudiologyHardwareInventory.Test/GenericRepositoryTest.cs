using NSubstitute;
using NUnit.Framework;
using System;
using AudiologyHardwareInventory;
using AudiologyHardwareInventory.DataAccessLayer;
using AudiologyHardwareInventory.Interface;
using AudiologyHardwareInventory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AudiologyHardwareInventory.Test
{
    [TestFixture]
    public class GenericRepositoryTest
    {
        public IRepository<Hardware> _fakeHardware = null;


        private HardwareInventoryContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<HardwareInventoryContext>()
                .UseInMemoryDatabase(databaseName: "Products Test").Options;
            var dbContext = new HardwareInventoryContext(options);
            return dbContext;
        }
        [Test]
        public void When_Call_Add_Then_Check_Is_It_Called_Once()
        {
           // var dataToAdd = new Hardware { HardwareName = "Hardware5", HardwareStatus = "Available" };
           //// var fakedbSet = Substitute.For<DbSet<Hardware>>();
           ////var fakeDBContext = CreateDbContext();
           // var fakedbContext = Substitute.For<HardwareDbContext>();
           // var genericRepository =new GenericRepository<Hardware>(fakedbContext);
           // genericRepository.Create(dataToAdd);
           // //login.loginDetails(Arg.Any<string>()).Returns(true);
           // fakedbContext.Received(1).Add(dataToAdd);

           // // Assert.AreEqual(true, res);

        }

    }
}
