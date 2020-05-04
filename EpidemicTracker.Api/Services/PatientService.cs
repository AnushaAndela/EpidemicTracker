using EpidemicTracker.Api.Services.Dtos;
using EpidemicTracker.Data.Models;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services
{
    public class PatientService : IPatientService
    {
        private  EpidemicTrackerContext _context;

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
                               //Occupations = (from o in a.Occupation
                               //               select new OccupationDto()
                               //               {
                               //                   Name = o.Name,
                               //                   Phone = o.Phone,
                               //                   StreetNo = o.StreetNo,
                               //                   Area = o.Area,
                               //                   City = o.City,
                               //                   State = o.State,
                               //                   Country = o.Country,
                               //                   Pincode = o.Pincode
                               //               }).ToList(),
                               //Treatments=(from t in a.Treatment
                               //            select new TreatmentDto()
                               //            {
                               //                AdmittedDate=t.AdmittedDate,
                               //                PercentageCure=t.PercentageCure,
                               //                RelievingDate=t.RelievingDate,
                               //                Isfatility=t.Isfatility

                               //            }).ToList()
                           };

            return patients;

           
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
                patientDto.Addresses = new List<AddressDto>();
                foreach (var item in patient.Address)
                {
                    var address = new AddressDto();
                    address.AddressDtoId = item.AddressId;
                    address.AddressType = item.AddressType;
                    address.Hno = item.Hno;
                    address.Street = item.Street;
                    address.City = item.City;
                    address.State = item.State;
                    address.Country = item.Country;
                    address.Pincode = item.Pincode;

                    patientDto.Addresses.Add(address);
                }
                //patientDto.Occupations = new List<OccupationDto>();
                //foreach (var item in patient.Occupation)
                //{
                //    var occupation = new OccupationDto();
                //    occupation.Name = item.Name;
                //    occupation.Phone = item.Phone;
                //    occupation.StreetNo = item.StreetNo;
                //    occupation.Area = item.Area;
                //    occupation.City = item.City;
                //    occupation.State = item.State;
                //    occupation.Country = item.Country;
                //    occupation.Pincode = item.Pincode;
                //    patientDto.Occupations.Add(occupation);

                //}
                //patientDto.Treatments = new List<TreatmentDto>();
                //foreach (var item in patientDto.Treatments)
                //{
                //    var treatment = new TreatmentDto();
                //    treatment.AdmittedDate = item.AdmittedDate;
                //    treatment.PercentageCure = item.PercentageCure;
                //    treatment.RelievingDate = item.RelievingDate;
                //    treatment.Isfatility = item.Isfatility;
                //}

            }
            return patientDto;
            //var patient = await _context.Patient.FindAsync(id);
            //return PatientToDTO(patient);

        }

     

        public async Task PostPatientAsync(PatientDto patientdto)
        {

            var patient = new Patient();
            patient.PatientId = patientdto.PatientDtoId;
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
            patient.Treatment = new List<Treatment>();
            foreach (var item in patientdto.Treatments)
            {
                var treatment = new Treatment();
                treatment.AdmittedDate = item.AdmittedDate;
                treatment.PercentageCure = item.PercentageCure;
                treatment.RelievingDate = item.RelievingDate;
                treatment.Isfatility = item.Isfatility;

                patient.Treatment.Add(treatment);
            }
            _context.Patient.Add(patient);
            await _context.SaveChangesAsync();

           

        }

    }
}
