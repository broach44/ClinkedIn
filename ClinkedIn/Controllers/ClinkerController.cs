using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.DataAccessLayer;
using ClinkedIn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/Clinker")]
    [ApiController]
    public class ClinkerController : ControllerBase
    {
        ClinkerRepo _repository = new ClinkerRepo();

        [HttpPost]
        public IActionResult AddClinker(Clinker clinkerToAdd)
        {
            var existingClinker = _repository.GetByFullName(clinkerToAdd);
            if (existingClinker == null)
            {
                _repository.Add(clinkerToAdd);           
                return Created("", clinkerToAdd);
            }
            else
            {
                return BadRequest("User already exists, please try again.");
            }
        }

        [HttpPost("services")]
        public IActionResult CreateService(Services ServiceToAdd)
        {
            var existingService = _repository.CheckForService(ServiceToAdd);
            if (existingService == null)
            {
                _repository.CreateService(ServiceToAdd);
                return Ok(ServiceToAdd);
            }
            else
            {
                return BadRequest("This service already exists");
            }
        }

        [HttpGet]
        public IActionResult GetAllClinkers()
        {
            var allClinkers = _repository.GetAll();

            return Ok(allClinkers);
        }

        // api/ClinkedIn/searchByInterest/{interest}
        // api/ClinkedIn/searchByInterest/origamin
        [HttpGet("searchByInterest/{interest}")]
        public IActionResult GetByInterest(string interest)
        {
            var clinkersWithInterest = _repository.GetClinkerByInterest(interest);
            var isEmpty = !clinkersWithInterest.Any();
            if (!isEmpty)
            {
                return Ok(clinkersWithInterest);
            }
            else
            {
                return Ok("No Clinkers Found With Those Interests");
            }
        }

        [HttpPut("AddInterest/{id}/{interest}")]
        public IActionResult AddInterest(int id, string interest)
        {
            var clinkerExists = _repository.GetClinkerById(id);
            if (clinkerExists == null)
            {
                return BadRequest($"The user id {id} could not be found.");
            }
            else
            {
                var currentInterests = _repository.GetInterestsByClinkerId(id);
                if (currentInterests.Contains(interest))
                {
                    return BadRequest($"{interest} is already on {clinkerExists.FirstName}'s interest list");
                }
                else
                {
                    _repository.CheckMasterInterestsAndUpdate(interest);
                    clinkerExists.AddInterests(interest);
                    return Ok(_repository.GetClinkerById(id));
                }
            }
        }

        [HttpPut("AddService/{clinkerId}")]
        public IActionResult AddService(int clinkerId, Services serviceToAdd)
        {
            var clinkerExists = _repository.GetClinkerById(clinkerId);
            if (clinkerExists == null)
            {
                return BadRequest($"The user id {clinkerId} could not be found.");
            }
            else
            {
                var currentClinkerService = _repository.GetServicesByClinkerId(clinkerId);
                if (currentClinkerService.FirstOrDefault(s => s.Name.ToLower() == serviceToAdd.Name.ToLower()) != null)
                {
                    return BadRequest($"{serviceToAdd.Name} is already on {clinkerExists.FirstName}'s service list");
                }
                else
                {
                    var currentService = _repository.CheckForService(serviceToAdd);
                    if (currentService == null)
                    {
                        _repository.CreateService(serviceToAdd);
                        var newService = _repository.CheckForService(serviceToAdd);
                        clinkerExists.AddService(newService);
                    }
                    else
                    {
                        clinkerExists.AddService(currentService);
                    }
                    return Ok(_repository.GetClinkerById(clinkerId));
                }
            }
        }

    }
}