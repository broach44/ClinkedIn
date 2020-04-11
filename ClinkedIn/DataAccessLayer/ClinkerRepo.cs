using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ClinkedIn.DataAccessLayer
{
    public class ClinkerRepo
    {
        

        

   
        static List<Clinker> _clinkers = new List<Clinker>()
        {

            new Clinker { Id = 1, FirstName = "John", LastName = "Doe", Interests = new List<string>() { "Killin" }, Friends = new List<Clinker>(), Enemies = new List<Clinker>() },
            new Clinker { Id = 2, FirstName = "Jimmie", LastName = "John", Interests = new List<string>() { "Killin" } },
            new Clinker { Id = 3, FirstName = "Sam", LastName = "Smith", Interests = new List<string>() { "BeatBoxin" } },
            new Clinker { Id = 4, FirstName = "Samson", LastName = "Smith", Interests = new List<string>() { "BeatBoxin" } },
            new Clinker {Id = 5, FirstName = "ButterCup", LastName = "Johnson", Interests = new List<string>() {"BasketWeavin", "Origamin" } },
            new Clinker {Id = 6, FirstName = "Slash", LastName = "MacGruber", Interests = new List<string>() { "Killin", "BasketWeavin" }},
            new Clinker {Id = 7, FirstName = "Slick", LastName = "Willie", Interests = new List<string>() { "Origamin" }},
            new Clinker {Id = 8, FirstName = "LittleShoe", LastName = "Wilomena", Interests = new List<string>() { "Killin", "BeatBoxin", "Origamin" } },

        };
        static List<string> _interests = new List<string>()

        {
            "ShowTunesin",
            "Killin",
            "BeatBoxin",
            "BasketWeavin",
            "Origamin"
        };

        public Clinker GetByFullName(Clinker clinkerToAdd)
        {
            var firstNameMatch = _clinkers.FindAll(c => c.FirstName == clinkerToAdd.FirstName);
            return firstNameMatch.FirstOrDefault(clinker => clinker.LastName == clinkerToAdd.LastName);
        }

        public void Add(Clinker clinker)
        {
            clinker.Id = _clinkers.Max(i => i.Id) + 1;
            _clinkers.Add(clinker);
        }

        public List<Clinker> GetAll()
        {
            return _clinkers;
        }

        public Clinker GetClinkerById(int clinkerId)
        {
            return _clinkers.FirstOrDefault(c => c.Id == clinkerId);
        }

        public Clinker UpdateClinker(Clinker clinker)
        {
            //var clinkerToUpdate = GetClinkerById(clinker);
            //return clinkerToUpdate;
            throw new NotImplementedException();
        }

        public List<Clinker> GetClinkerByInterest(string interest)
        {
            // search through the List of Clinkers and pull in ones that match the interest
            // 1. search each clinker
            // 2. search clinkers interests and see if they match the interest argument
            var clinkerInterestMatch = _clinkers.FindAll(x => x.Interests.Contains(interest));
        
            return clinkerInterestMatch;
        }

        public Services GetMyServices()
        {
            throw new NotImplementedException();
        }
 
        public Clinker UpdateFriend(int clinkerToUpdateId, int clinkerToAddId)
        {
                var newClinkerFriend = GetClinkerById(clinkerToAddId);
                var clinkerToUpdate = GetClinkerById(clinkerToUpdateId);
                clinkerToUpdate.AddNewFriend(newClinkerFriend);
                return clinkerToUpdate;
        
        }

        public Clinker UpdateEnemy(int clinkerToUpdateId, int clinkerToAddId)
        {
            var newClinkerEnemy = GetClinkerById(clinkerToAddId);
            var clinkerToUpdate = GetClinkerById(clinkerToUpdateId);
            clinkerToUpdate.AddNewEnemy(newClinkerEnemy);
            return clinkerToUpdate;
        }
        }
}
