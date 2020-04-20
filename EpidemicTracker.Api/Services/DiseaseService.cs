using EpidemicTracker.Api.Services.Dtos;
using EpidemicTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services
{
    public class DiseaseService : IDiseaseService
    {
        private EpidemicTrackerContext _context;

        public DiseaseService(EpidemicTrackerContext context)
        {
            _context = context;

        }
        public async Task<IList<DiseaseDto>> GetAllAsync()
        {
            var diseasesDto = new List<DiseaseDto>();
            var diseases = await _context.Disease.ToListAsync();
            foreach (var item in diseases)
            {
                var diseaseDto = new DiseaseDto();
                diseaseDto.DiseaseDtoId = item.DiseaseId;
                diseaseDto.Name = item.Name;
                //diseaseDto.diseaseTypeDto = item.DiseaseType;


                diseasesDto.Add(diseaseDto);
            }
            return diseasesDto;
        }

        public async Task<DiseaseDto> GetDiseaseAsync(int id)
        {
            var diseaseDto = new DiseaseDto();
            var disease = await _context.Disease.FirstOrDefaultAsync(x => x.DiseaseId == id);
            if (disease != null)
            {
                diseaseDto.DiseaseDtoId = disease.DiseaseId;
                diseaseDto.Name = disease.Name;

                
            }
            return diseaseDto;
        }

        public async Task<DiseaseDto> PostDiseaseAsync(DiseaseDto diseaseDto)
        {
            var disease = new Disease
            {
               // DiseaseId=diseaseDto.DiseaseDtoId,
                Name = diseaseDto.Name
                


            };
            _context.Disease.Add(disease);
            await _context.SaveChangesAsync();

            var value = new DiseaseDto
            {
                DiseaseDtoId=disease.DiseaseId,
                Name = disease.Name
                
            };
            return value;
        }
    }
}
