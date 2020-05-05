using EpidemicTracker.Api.Services.Dtos;
using EpidemicTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services
{
    public class DiseaseTypeService : IDiseaseTypeService
    {
        private EpidemicTrackerContext _context;
        public DiseaseTypeService(EpidemicTrackerContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<DiseaseTypeDto>> GetAllAsync()
        {
            var DiseasesType = from a in _context.DiseaseType.Include(a => a.Disease)
                               select new DiseaseTypeDto()
                               {
                                   TypeOfDisease = a.TypeOfDisease,
                                   Disease= (from b in a.Disease
                                              select new DiseaseDto()
                                              {
                                                  Name=b.Name


                                              }).ToList()
                               };
            return DiseasesType;
         }

        public async Task<DiseaseTypeDto> GetDiseaseAsync(int id)
        {
            var diseaseTypeDto = new DiseaseTypeDto();
            var diseaseType = await _context.DiseaseType.FirstOrDefaultAsync(x => x.DiseaseTypeId == id);
            if(diseaseType!=null)
            {
                diseaseTypeDto.DiseaseTypeId = diseaseType.DiseaseTypeId;
                diseaseTypeDto.TypeOfDisease = diseaseType.TypeOfDisease;
                diseaseTypeDto.Disease = new List<DiseaseDto>();
                foreach (var item in diseaseTypeDto.Disease)
                {
                    var disease = new DiseaseDto();
                    disease.DiseaseDtoId = item.DiseaseDtoId;
                    disease.Name = item.Name;
                    diseaseTypeDto.Disease.Add(disease);
                }
            }
            return diseaseTypeDto;
        }

        public async Task SaveDiseaseAsync(DiseaseTypeDto diseaseTypeDto)
        {
            var diseaseType = new DiseaseType();
            diseaseType.DiseaseTypeId = diseaseTypeDto.DiseaseTypeId;
            diseaseType.TypeOfDisease = diseaseTypeDto.TypeOfDisease;
            diseaseType.Disease = new List<Disease>();
            foreach (var item in diseaseTypeDto.Disease)
            {
                var disease = new Disease();
                disease.DiseaseId = item.DiseaseDtoId;
                disease.Name = item.Name;
                diseaseType.Disease.Add(disease);
            }
            _context.DiseaseType.Add(diseaseType);
            await _context.SaveChangesAsync();

        }
    }
}
