using EpidemicTracker.Api.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services
{
    public interface IHospitalService
    {
        Task<HospitalDto> GetHospitalAsync(int id);
        Task<IList<HospitalDto>> GetAllAsync();
        Task<HospitalDto> PostHospitalAsync(HospitalDto hospitalDto);
    }
}
