using EpidemicTracker.Api.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services
{
    public interface IDiseaseTypeService
    {
        Task<DiseaseTypeDto> GetDiseaseAsync(int id);
        Task<IEnumerable<DiseaseTypeDto>> GetAllAsync();
        Task SaveDiseaseAsync(DiseaseTypeDto diseaseTypeDto);
    }
}
