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
    public class DiseaseController : ControllerBase
    {
        private readonly IDiseaseService _diseaseService;


        public DiseaseController(IDiseaseService diseaseService)
        {
            _diseaseService = diseaseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _diseaseService.GetAllAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiseaseAsync(int id)
        {
            return Ok(await _diseaseService.GetDiseaseAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostDiseaseAsync(DiseaseDto diseaseDto)
        {

            return Ok(await _diseaseService.PostDiseaseAsync(diseaseDto));
        }
    }
}