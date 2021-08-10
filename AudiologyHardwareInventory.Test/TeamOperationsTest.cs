using NSubstitute;
using NUnit.Framework;
using System;
using AudiologyHardwareInventory;
using AudiologyHardwareInventory.BusinessLayer;
using AudiologyHardwareInventory.DataAccessLayer;
using AudiologyHardwareInventory.Interface;
using AudiologyHardwareInventory.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace AudiologyHardwareInventory.Test
{
    [TestFixture]
    public class TeamOperationsTest
    {
        public ITeam _teamOperationsInstance = null;

        public  ITeam TeamOperationsInstance()
        {
            var context = ContextInstance.CreateHardwareInventoryContext();
            IRepository<Team> teamRepository = new GenericRepository<Team>(context);
            ITeam teamOperations = new TeamOperations(teamRepository, context);
            return teamOperations;
        }
        
        [Test]
        public void When_InsertNewTeam_Called_Then_Data_Inserted()
        {
            var dataToInsert = new Team() { TeamName = "Team2", Description = "Working for AU" };
            _teamOperationsInstance= TeamOperationsInstance();
            _teamOperationsInstance.InsertNewTeam(dataToInsert);
        }

        [Test]
        public void When_InsertNewTeam_Called_Then_Check_Argument_Type()
        {
            var fakeRepository = Substitute.For<IRepository<Team>>();
            var fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            var teamOperations = new TeamOperations(fakeRepository, fakeContext);
            teamOperations.InsertNewTeam(Arg.Any<Team>());
        }
        [Test]
        public void When_InsertNewTeam_Called_Then_Create_Function_Received_Call_Once()
        {
            var team = new Team() { TeamName = "Team2", Description = "Working for AU" };
            var fakeRepository = Substitute.For<IRepository<Team>>();
            var fakeContext = ContextInstance.CreateInMemoryDatabaseContext();
            var teamOperations = new TeamOperations(fakeRepository, fakeContext);
            teamOperations.InsertNewTeam(team);
            fakeRepository.Received().Create(team);
        }

    }
}
