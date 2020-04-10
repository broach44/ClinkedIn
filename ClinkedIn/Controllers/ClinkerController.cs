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
    [Route("api/[controller]")]
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

        [HttpGet("{interest}")]
        public IActionResult GetClinkerByInterest()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IActionResult UpdateClinker()
        {
            throw new NotImplementedException();
        }

        //[HttpGet("{id}")]
        //public IActionResult GetClinkerById(int id)
        //{
        //    var pickle = _repository.GetById(id);

        //    if (pickle == null) return NotFound("No pickle with that id could be found.");

        //    return Ok(pickle);
        //}
    }
}