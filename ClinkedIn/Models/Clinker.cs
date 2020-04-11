﻿using System;
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

        
        public List <Services> Services { get; set; }

        public Clinker()
        {
            Friends = new List<Clinker>();
        }
        public void AddNewFriend(Clinker newClinkerFriend) => Friends.Add(newClinkerFriend);
        public void AddNewEnemy(Clinker newClinkerEnemy) => Enemies.Add(newClinkerEnemy);

    }

}
