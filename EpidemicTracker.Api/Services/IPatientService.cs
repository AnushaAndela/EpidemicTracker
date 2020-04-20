using EpidemicTracker.Api.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services
{
    public interface IPatientService
    {
        Task<PatientDto> GetPatient(int id);
        Task<IEnumerable<PatientDto>> GetAll();
        Task<PatientDto> PostPatient(PatientDto patientDto);
    }
}
