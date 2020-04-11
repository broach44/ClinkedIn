using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class Clinker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Interests { get; set; }
        public List<Clinker> Enemies { get; set; }
        public List<Clinker> Friends { get; set; }
        public List<Services> Service { get; set; }

        public Clinker()
        {
            Interests = new List<string>();
            Enemies = new List<Clinker>();
            Friends = new List<Clinker>();
            Service = new List<Services>();
        }

        public void AddInterests(string newInterest)
        {
            Interests.Add(newInterest);
        }

        public void AddService(Services newService)
        {
            Service.Add(newService);
        }
    }
}
