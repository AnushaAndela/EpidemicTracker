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


        public async Task<IEnumerable<PatientDto>> GetAllAsync()
        {
            var patientsDto = new List<PatientDto>();
            var patients = await _context.Patient.ToListAsync();
            foreach (var item in patients)
            {
                var patientDto = new PatientDto();
                patientDto.PatientDtoId = item.PatientId;
                patientDto.Name = item.Name;
                patientDto.Age = item.Age;
                patientDto.Gender = item.Gender;
                patientDto.AadharId = item.AadharId;
                patientsDto.Add(patientDto);
            }
            return patientsDto;
        

        //return await _context.Patient
        //.Select(x => PatientToDTO(x))
        //.ToListAsync();
    }

        public async Task<PatientDto> GetPatientAsync(int id)
        {
            var patientDto = new PatientDto();
            var patient = await _context.Patient.FirstOrDefaultAsync(x => x.PatientId == id);
            if (patient != null)
            {
                patientDto.PatientDtoId = patient.PatientId;
                patientDto.Name = patient.Name;
                patientDto.Age = patient.Age;
                patientDto.Gender = patient.Gender;
                patientDto.AadharId = patient.AadharId;
            }
            return patientDto;
            //var patient = await _context.Patient.FindAsync(id);
            //return PatientToDTO(patient);

        }

       // private static PatientDto PatientToDTO(Patient patient) =>
       //new PatientDto
       //{
       //    PatientDtoId = patient.PatientId,
       //    Name = patient.Name,
       //    Age = patient.Age,
       //    Gender = patient.Gender,
       //    Phone = patient.Phone,
       //    AadharId = patient.AadharId
       //};



        public async Task<PatientDto> PostPatientAsync(PatientDto patientdto)
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
