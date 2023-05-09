using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTeams.Data
{
    //ctrl + b -> hide explorer
public class DeveloperTeam
    {
        public DeveloperTeam()
        {
            
        }

        public DeveloperTeam(string teamName, List<Developer> developers)
        {
            TeamName = teamName;
            Developers = developers;
        }

    public int ID { get; set; }

      public string TeamName { get; set; } = string.Empty;

       public List<Developer> Developers { get; set; } = new List<Developer>();

}

}