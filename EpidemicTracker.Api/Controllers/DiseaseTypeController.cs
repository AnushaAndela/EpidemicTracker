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
    public class DiseaseTypeController : ControllerBase
    {
        private readonly IDiseaseTypeService _diseaseTypeService;
        public DiseaseTypeController(IDiseaseTypeService diseaseTypeService)
        {
            _diseaseTypeService = diseaseTypeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _diseaseTypeService.GetAllAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientAsync(int id)
        {
            return Ok(await _diseaseTypeService.GetDiseaseAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> SaveDiseaseAsync(DiseaseTypeDto diseaseTypeDto)
        {

            await _diseaseTypeService.SaveDiseaseAsync(diseaseTypeDto);
            return Ok();
        }

    }
}