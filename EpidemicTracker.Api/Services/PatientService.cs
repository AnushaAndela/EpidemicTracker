using EpidemicTracker.Api.Services.Dtos;
using EpidemicTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services
{
    public class PatientService : IPatientService
    {
        private EpidemicTrackerContext _context;

        public PatientService(EpidemicTrackerContext context)
        {
            _context = context;

        }


        public async Task<IEnumerable<PatientDto>> GetAll()
        {

            return await _context.Patient
            .Select(x => PatientToDTO(x))
            .ToListAsync();
        }

        public async Task<PatientDto> GetPatient(int id)
        {
            var patient = await _context.Patient.FindAsync(id);
            return PatientToDTO(patient);

        }

        private static PatientDto PatientToDTO(Patient patient) =>
       new PatientDto
       {
           PatientDtoId = patient.PatientId,
           Name = patient.Name,
           Age = patient.Age,
           Gender = patient.Gender,
           Phone = patient.Phone,
           AadharId = patient.AadharId
       };



        public async Task<PatientDto> PostPatient(PatientDto patientdto)
        {
            var patient = new Patient
            {
                Name = patientdto.Name,
                Age = patientdto.Age,
                Gender = patientdto.Gender,
                Phone = patientdto.Phone,
                AadharId = patientdto.AadharId

            };
            _context.Patient.Add(patient);
            await _context.SaveChangesAsync();

            var value = new PatientDto
            {
                PatientDtoId = patient.PatientId,
                Name = patient.Name,

                Age = patient.Age,
                Gender = patient.Gender,
                Phone = patient.Phone,
                AadharId = patient.AadharId
            };
            return value;

        }

    }
}
