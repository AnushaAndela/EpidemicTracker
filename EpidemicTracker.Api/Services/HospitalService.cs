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
        public async Task<IEnumerable<HospitalDto>> GetAll()
        {

            return await _context.Hospital
            .Select(x => HospitalToDTO(x))
            .ToListAsync();
        }
        public async Task<HospitalDto> GetHospital(int id)
        {
            var hospital = await _context.Hospital.FindAsync(id);
            return HospitalToDTO(hospital);

        }

        private static HospitalDto HospitalToDTO(Hospital hospital) =>
       new HospitalDto
       {
           HospitalDtoId=hospital.HospitalId,
           Name=hospital.Name,
           Phone=hospital.Phone,
           StreetNo=hospital.StreetNo,
           Area=hospital.Area,
           City=hospital.City,
           State=hospital.State,
           Country=hospital.Country,
           Pincode=hospital.Pincode
       };

        public async Task<HospitalDto> PostHospital(HospitalDto hospitalDto)
        {
            var hospital = new Hospital
            {
                
                Name = hospitalDto.Name,
                Phone = hospitalDto.Phone,
                StreetNo = hospitalDto.StreetNo,
                Area = hospitalDto.Area,
                City = hospitalDto.City,
                State = hospitalDto.State,
                Country = hospitalDto.Country,
                Pincode = hospitalDto.Pincode

            };
            _context.Hospital.Add(hospital);
            await _context.SaveChangesAsync();

            var value = new HospitalDto
            {
                HospitalDtoId = hospital.HospitalId,
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
