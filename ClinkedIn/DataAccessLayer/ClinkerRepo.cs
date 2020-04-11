﻿using ClinkedIn.Models;
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

            new Clinker { Id = 1, FirstName = "John", LastName = "Doe", Interests = new List<string>() { "Killin" }, Enemies = new List<Clinker>() },
            new Clinker { Id = 2, FirstName = "Jimmie", LastName = "John", Interests = new List<string>() { "Killin" } },
            new Clinker { Id = 3, FirstName = "Sam", LastName = "Smith", Interests = new List<string>() { "BeatBoxin" } },
            new Clinker { Id = 4, FirstName = "Samson", LastName = "Smith", Interests = new List<string>() { "BeatBoxin" } },
            new Clinker {Id = 5, FirstName = "ButterCup", LastName = "Johnson", Interests = new List<string>() {"BasketWeavin", "Origamin" } },
            new Clinker {Id = 6, FirstName = "Slash", LastName = "MacGruber", Interests = new List<string>() { "Killin", "BasketWeavin" }},
            new Clinker {Id = 7, FirstName = "Slick", LastName = "Willie", Interests = new List<string>() { "Origamin" }},
            new Clinker {Id = 8, FirstName = "LittleShoe", LastName = "Wilomena", Interests = new List<string>() { "Killin", "BeatBoxin", "Origamin" } },

        };

        static List<Services> _services = new List<Services>()
        {
            new Services { Id = 1, Name= "Hair Cut", Price = 3.00 },
            new Services { Id = 2, Name= "Legal Advice", Price = 5.00 },
            new Services { Id = 3, Name= "Cuddle Buddy", Price = 2.00 }
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

        public List<Clinker> GetAllMyFriends(int clinkerId)
        {
            return GetClinkerById(clinkerId).Friends;
        }

        public List<Clinker> AllFriendsOfFriends(int clinkerId)
        {
            var clinkersFriends = GetAllMyFriends(clinkerId);
            if (clinkersFriends != null)
            {
                foreach (var friend in clinkersFriends)
                {
                    return GetAllMyFriends(friend.Id);
                }
            }
            return clinkersFriends;
        }

        public Clinker GetClinkerById(int clinkerId)
        {
            return _clinkers.FirstOrDefault(c => c.Id == clinkerId);
        }

        public void CheckMasterInterestsAndUpdate(string newInterest)
        {
            var existingInterest = _interests.FirstOrDefault(i => i.ToLower() == newInterest.ToLower());
            if (existingInterest == null)
            {
                _interests.Add(newInterest);
            }
        }

        public List<Clinker> GetClinkerByInterest(string interest)
        {
            var clinkerInterestMatch = _clinkers.FindAll(x => x.Interests.Contains(interest));
        
            return clinkerInterestMatch;
        }

        public List<string> GetInterestsByClinkerId(int id)
        {
            var targetClinker = GetClinkerById(id);
            return targetClinker.Interests;
        }

        public Services CheckForService(Services newService)
        {
            return _services.FirstOrDefault(s => s.Name.ToLower() == newService.Name.ToLower());
        }

        public void CreateService(Services newService)
        {
            newService.Id = _services.Max(i => i.Id) + 1;
            _services.Add(newService);
        }


        public List<Services> GetServicesByClinkerId(int id)
        {
            var targetClinker = GetClinkerById(id);
            return targetClinker.Services;
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
