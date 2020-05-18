using EpidemicTracker.Api.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services
{
    public interface ITreatmentService
    {
        Task<IEnumerable<TreatementDto>> GetAllAsync(int diseaseId);
        //Task SaveTreatmentAsync(TreatementDto treatementDto);
    }
}
