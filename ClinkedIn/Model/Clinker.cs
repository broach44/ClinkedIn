using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Model
{
    public class Clinker
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Clinker> Enemies { get; set; }
        public List<Clinker> Friends { get; set; }

        public Clinker(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
