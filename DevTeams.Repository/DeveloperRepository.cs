using DevTeams.Data;

//This is just a collection of developers
//I can manipulate this collection any way I see fit

namespace DevTeams.Repository
{
    public class DeveloperRepository
    {
            public DeveloperRepository()
            {
                Seed();
            }

        //_DeveloperDb is the variable container that will hold all of the developer data
        //It's a collection of developers
        //List<T>, a list is a collection that can hold any type
        private List<Developer> _developerDb = new List<Developer>();

        private int _count = 0;

        public bool AddDeveloper(Developer developer)
        {
            if (developer == null)
            {
                return false;
            }
            else
            {
                _count++;

                developer.ID = _count;

                _developerDb.Add(developer);

                return true;
            }
        }

        //Read all, we want to return everything in the database
        public List<Developer> GetDevelopers()
        {
            return _developerDb;
        }

        //Read by ID (helper method)
        public Developer GetDeveloper(int developerId)
        {
            //we need to loop through the entire database
            foreach (Developer? dev in _developerDb)
            {
                //We need to find a developer with a matching ID that the user passes in (developer ID)
                if (dev.ID == developerId)
                {
                    //if this is true, let's return that developer's data
                    return dev;
                }
            }
            return null;
        }

        //Update
        public bool UpdateExistingDeveloper(int developerId, string fullName, bool hasPluralsight)
        {
            Developer developerToUpdate = GetDeveloper(developerId);

            if (developerToUpdate == null)
            {
                return false;
            }
            developerToUpdate.FullName = fullName;
            developerToUpdate.HasPluralsight = hasPluralsight;

            return true;

        }

        // private Developer GetDeveloperById(int developerId)
        //  {
        //      return _developerDb.FirstOrDefault(dev => dev.ID == developerId);
        //  }

        //Delete

        public bool DeleteExistingDeveloper(int developerId)
        {
            Developer developerToDelete = GetDeveloper(developerId);
            if (developerToDelete == null)
            {
                return false;
            }

            _developerDb.Remove(developerToDelete);

            return true;
        }

        public Developer ShowDeveloperById(int developerId)
        {
            return GetDeveloper(developerId);
        }

        public List<Developer> GetDevelopersWithPluralsightAccounts()
        {
            //L.I.N.Q 
            return _developerDb.Where(d => d.HasPluralsight == true).ToList();
        }

        private List<Developer> GetDevelopersWithoutPluralsight()
        {
            List<Developer> devsWithoutPS = new List<Developer>();
            foreach (var d in _developerDb)
            {
                if (d.HasPluralsight == false)
                {
                    devsWithoutPS.Add(d);
                }
                return devsWithoutPS;
            }
            return null;
        }

        //seed developers
        private void Seed()
        {
            //create developers to add to db
            Developer george = new Developer
            {
                FirstName = "George",
                LastName = "Carlin",
                HasPluralsight = true
            };

            Developer richard = new Developer
            {
                FirstName = "Richard",
                LastName = "Pryor",
                HasPluralsight = false
            };

            Developer damon = new Developer
            {
                FirstName = "Damon",
                LastName = "Wayans",
                HasPluralsight = true
            };

            AddDeveloper(george);
            AddDeveloper(richard);
            AddDeveloper(damon);
        }

    }
}