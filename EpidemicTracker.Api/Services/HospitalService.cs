using EpidemicTracker.Api.Services.Dtos;
using EpidemicTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services
{
    public class HospitalService : IHospitalService
    {
        private EpidemicTrackerContext _context;

        public HospitalService(EpidemicTrackerContext context)
        {
            _context = context;

        }


        public async Task<IList<HospitalDto>> GetAllAsync()
        {
            var hospitalsDto = new List<HospitalDto>();
            var hospitals = await _context.Hospital.ToListAsync();
            foreach (var item in hospitals)
            {
                var hospitalDto = new HospitalDto();
                hospitalDto.HospitalDtoId = item.HospitalId;
                hospitalDto.Name = item.Name;
                hospitalDto.Phone = item.Phone;
                hospitalDto.StreetNo = item.StreetNo;
                hospitalDto.Area = item.Area;
                hospitalDto.City = item.City;
                hospitalDto.State = item.State;
                hospitalDto.Country = item.Country;
                hospitalDto.Pincode = item.Pincode;

                hospitalsDto.Add(hospitalDto);
            }
            return hospitalsDto;


            //return await _context.Patient
            //.Select(x => PatientToDTO(x))
            //.ToListAsync();
        }

        public async Task<HospitalDto> GetHospitalAsync(int id)
        {
            var hospitalDto = new HospitalDto();
            var hospital = await _context.Hospital.FirstOrDefaultAsync(x => x.HospitalId == id);
            if (hospital != null)
            {
                hospitalDto.HospitalDtoId = hospital.HospitalId;
                hospitalDto.Name = hospital.Name;
                hospitalDto.Phone = hospital.Phone;
                hospitalDto.StreetNo = hospital.StreetNo;
                hospitalDto.Area = hospital.Area;
                hospitalDto.City = hospital.City;
                hospitalDto.State = hospital.State;
                hospitalDto.Country = hospital.Country;
                hospitalDto.Pincode = hospital.Pincode;
            }
            return hospitalDto;
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



        public async Task<HospitalDto> PostHospitalAsync(HospitalDto hospitalDto)
        {
            var hospital = new Hospital
            {

                Name = hospitalDto.Name,
                Phone = hospitalDto.Phone,
                StreetNo=hospitalDto.StreetNo,
                Area=hospitalDto.Area,
                City=hospitalDto.Area,
                State=hospitalDto.State,
                Country=hospitalDto.Country,
                Pincode=hospitalDto.Pincode
               

            };
            _context.Hospital.Add(hospital);
            await _context.SaveChangesAsync();

            var value = new HospitalDto
            {
                HospitalDtoId=hospital.HospitalId,
             Name = hospital.Name,
            Phone = hospital.Phone,
            StreetNo = hospital.StreetNo,
            Area = hospital.Area,
            City = hospital.City,
            State = hospital.State,
            Country = hospital.Country,
            Pincode = hospital.Pincode
        };
            return value;

        }

    }
}
