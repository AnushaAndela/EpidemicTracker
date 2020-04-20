using EpidemicTracker.Api.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services
{
    public interface IHospitalService
    {
        Task<HospitalDto> GetHospital(int id);
        Task<IEnumerable<HospitalDto>> GetAll();
        Task<HospitalDto> PostHospital(HospitalDto hospitalDto);
    }
}
