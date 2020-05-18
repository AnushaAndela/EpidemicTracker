using System.Collections.Generic;
using System.Threading.Tasks;
using EpidemicTracker.Api.Services;
using EpidemicTracker.Api.Services.Dtos;
using EpidemicTracker.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace EpidemicTracker.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {


        private readonly IPatientService _patientService;


        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _patientService.GetAllAsync());
        }
        //[HttpGet]
        //[Route("PatientData")]
        //public IActionResult GetPatientData(int diseaseId)
        //{
        //    return Ok(_patientService.GetPatientData(diseaseId));
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientAsync(int id)
        {
            return Ok(await _patientService.GetPatientAsync(id));
        }

        

        [HttpPost]
        public async Task<IActionResult> PostPatientAsync(PatientDto patientdto)
        {
            await _patientService.PostPatientAsync(patientdto);
            return Ok();
        }
    }
}
