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

        [HttpPut]
        public IActionResult UpdateClinker()
        {
            throw new NotImplementedException();
        }

}
}