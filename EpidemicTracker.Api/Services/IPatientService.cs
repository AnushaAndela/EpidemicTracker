using EpidemicTracker.Api.Services.Dtos;
using EpidemicTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services
{
    public interface IPatientService
    {
        Task<PatientDto> GetPatientAsync(int id);
        Task<IEnumerable<PatientDto>> GetAllAsync();
        //TreatmentData GetPatientData(int diseaseId);
        Task PostPatientAsync(PatientDto patientDto);
    }
}
