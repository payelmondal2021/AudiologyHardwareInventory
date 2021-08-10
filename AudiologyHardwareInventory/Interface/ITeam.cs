using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.Models;

namespace AudiologyHardwareInventory.Interface
{
    public interface ITeam
    {
        IEnumerable<Team> CheckTeamStatus();
        void InsertNewTeam(Team team);

    }
}
