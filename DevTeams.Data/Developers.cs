using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTeams.Data
{
    
    public class Developer
    {
        public Developer()
        {
            
        }
        
        public Developer(string firstName, string lastName, bool hasPluralsight)
        {
            FirstName = firstName;
            LastName = lastName;
            HasPluralsight = hasPluralsight;
        }

        //we need a primary key
        public int ID { get; set;}

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
            set
            {
                string[] names = value.Split("", StringSplitOptions.RemoveEmptyEntries);

                if (names.Length > 0)
                {
                    FirstName = names[0];
                }
                if (names.Length > 1)
                {
                    LastName = names[1];
                }
            }
        }
    public bool HasPluralsight { get; set; }

    public override string ToString()
    {
        var str = $"ID: {ID}\n"+
        $"Full Name: {FullName}" +
        $"Has Pluralsight Access: {HasPluralsight}\n" +
        "===========================================\n";

        return str;
                
    }
    }
}