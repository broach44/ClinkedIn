using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ClinkedIn.DataAccessLayer
{
    public class ClinkerRepo
    {
        static List<Clinker> _clinkers = new List<Clinker>() { 
            new Clinker { Id = 1, FirstName = "John", LastName = "Doe" }, 
            new Clinker {Id = 2, FirstName = "ButterCup", LastName = "Johnson"},
            new Clinker {Id = 3, FirstName = "Slash", LastName = "MacGruber"},
            new Clinker {Id = 4, FirstName = "Slick", LastName = "Willie"},
            new Clinker {Id = 5, FirstName = "LittleShoe", LastName = "Wilomena" }
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

        public Clinker GetClinkerById(Clinker clinker)
        {
            return _clinkers.FirstOrDefault(c => c.Id == clinker.Id);
        }

        public Clinker UpdateClinker(Clinker clinker)
        {
            //var clinkerToUpdate = GetClinkerById(clinker);
            //return clinkerToUpdate;
            throw new NotImplementedException();
        }

        public List<Clinker> GetInmatesByInterests()
        {
            throw new NotImplementedException();
        }

        public Services GetMyServices()
        {
            throw new NotImplementedException();
        }

        public Clinker AddNewFriend(Clinker ClinkerToAdd)
        {
            return _clinkers.FirstOrDefault(clinker => clinker.Id == ClinkerToAdd.Id);
            
        }

        public Clinker GetMyEnemies()
        {
            throw new NotImplementedException();
        }
    }
}
