using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidemicTracker.Api.Services;
using EpidemicTracker.Api.Services.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EpidemicTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentService _treatmentservice;
        public TreatmentController(ITreatmentService treatmentService)
        {
            _treatmentservice = treatmentService;
        }
        // GET: api/Treatment
        [HttpGet]
         public async Task<IActionResult> GetAllAsync(int diseaseId)
        {
            return Ok(await _treatmentservice.GetAllAsync(diseaseId));
        }

        

        // POST: api/Treatment
        //[HttpPost]
        //public async Task<IActionResult> SaveTreatmentAsync(TreatementDto treatementDto)
        //{
        //    await _treatmentservice.SaveTreatmentAsync(treatementDto);
        //    return Ok();
        //}

        
    }
}
