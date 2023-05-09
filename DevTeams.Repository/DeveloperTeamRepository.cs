using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTeams.Data;

namespace DevTeams.Repository
{
    public class DeveloperTeamRepository
    {
        public DeveloperTeamRepository()
        {
            Seed();
        }

        private void Seed()
        {
             var team1 = new DeveloperTeam{
                TeamName = "Dragon"
            };
            team1.Developers.Add(_dRepo.GetDeveloper(1));
            AddDeveloperTeam(team1);
        }

        private DeveloperRepository _dRepo = new DeveloperRepository();
        private  List<DeveloperTeam> _dTeamRepo = new List<DeveloperTeam>();
        private int _count=0;
        public bool AddDeveloperTeam(DeveloperTeam team)
        {
            if (team == null)
            {
                return false;
            }
            else
            {
                _count++;

                team.ID = _count;

                _dTeamRepo.Add(team);

                return true;
            }
        }

        public List<DeveloperTeam> GetDeveloperTeams()
        {
            return _dTeamRepo;
        }

        public DeveloperTeam GetDeveloperTeam (int teamId)
        {
            foreach (DeveloperTeam? team in _dTeamRepo)
            {
                if (team.ID == teamId)
                {
                    return team;
                }
            }
            return null;
        }

        public bool DeleteTeam(DeveloperTeam team)
        {
            DeveloperTeam teamToDelete = GetAllDeveloperTeams(team);
            if (teamToDelete == null)
            {
                return false;
            }

            _dTeamRepo.Remove(teamToDelete);

            return true;
        }

        private DeveloperTeam GetAllDeveloperTeams(DeveloperTeam team)
        {
            throw new NotImplementedException();
        }

        public List<DeveloperTeam> GetAllDeveloperTeams()
        {
            return _dTeamRepo;
        }

        public DeveloperTeam ShowTeamById(int teamId)
        {
            return _dTeamRepo.FirstOrDefault(x=>x.ID==teamId)!;
        }

        public bool UpdateExistingTeam(DeveloperTeam team)
        {
            DeveloperTeam teamToUpdate = ShowTeamById(team.ID);

            if (teamToUpdate == null)
            {
                return false;
            }
                teamToUpdate.TeamName = team.TeamName;
                teamToUpdate.Developers = team.Developers;

                return true;
            }
        }
       
    }