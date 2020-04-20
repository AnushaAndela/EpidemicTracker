using System.Threading.Tasks;
using EpidemicTracker.Api.Services;
using EpidemicTracker.Api.Services.Dtos;
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
            return Ok(await _patientService.GetAll());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientAsync(int id)
        {
            return Ok(await _patientService.GetPatient(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostPatientAsync(PatientDto patientdto)
        {

            return Ok(await _patientService.PostPatient(patientdto));
        }
    }
}
