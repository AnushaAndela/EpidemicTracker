using EpidemicTracker.Api.Services.Dtos;
using EpidemicTracker.Data.Models;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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


        public  async Task<IEnumerable<PatientDto>> GetAllAsync()
        {
            var patients = from a in _context.Patient.Include(a => a.Address).Include(a => a.Occupation)
                           select new PatientDto()
                           {
                               Name = a.Name,
                               Age = a.Age,
                               Gender = a.Gender,
                               Phone = a.Phone,
                               AadharId = a.AadharId,
                               Addresses = (from b in a.Address
                                            select new AddressDto()
                                            {
                                                AddressType = b.AddressType,
                                                Hno = b.Hno,
                                                Street = b.Street,
                                                City = b.City,
                                                State = b.State,
                                                Country = b.Country


                                            }).ToList(),
                               Occupations=(from o in a.Occupation
                                            select new OccupationDto()
                                            {
                                                Name=o.Name,
                                                Phone=o.Phone,
                                                StreetNo=o.StreetNo,
                                                Area=o.Area,
                                                City=o.City,
                                                State=o.State,
                                                Country=o.Country,
                                                Pincode=o.Pincode
                                            }).ToList()
                           };

            return patients;

            //var patientsDto = new List<PatientDto>();
            //var addressDto = new List<AddressDto>();


            //var patients = await _context.Patient.Include("Address").ToListAsync();
            //foreach (var item in patients)
            //{
            //    var patientDto = new PatientDto();
            //    patientDto.PatientDtoId = item.PatientId;
            //    patientDto.Name = item.Name;
            //    patientDto.Age = item.Age;
            //    patientDto.Gender = item.Gender;
            //    patientDto.AadharId = item.AadharId;


            //    patientsDto.Add(patientDto);
            //}
            //return patientsDto;


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
       //    AadharId = patient.AadharId,
           
       //};






        public async Task<PatientDto> PostPatientAsync(PatientDto patientdto)
        {

            var patient = new Patient();

            patient.Name = patientdto.Name;
            patient.Age = patientdto.Age;
            patient.Gender = patientdto.Gender;
            patient.Phone = patientdto.Phone;
            patient.AadharId = patientdto.AadharId;
            patient.Address = new List<Address>();

            foreach (var item in patientdto.Addresses)
            {
                var address = new Address();
                address.AddressId = item.AddressDtoId;
                address.AddressType = item.AddressType;
                address.Hno = item.Hno;
                address.Street = item.Street;
                address.City = item.City;
                address.State = item.State;
                address.Country = item.Country;
                address.Pincode = item.Pincode;
                patient.Address.Add(address);

            }
            patient.Occupation = new List<Occupation>();
            foreach (var item in patientdto.Occupations)
            {
                var occupation = new Occupation();
                occupation.Name = item.Name;
                occupation.Phone = item.Phone;
                occupation.StreetNo = item.StreetNo;
                occupation.Area = item.Area;
                occupation.City = item.City;
                occupation.State = item.State;
                occupation.Country = item.Country;
                occupation.Pincode = item.Pincode;
                patient.Occupation.Add(occupation);
            }
                        
                
         

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
