using EpidemicTracker.Api.Services.Dtos;
using EpidemicTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services
{
    public class TreatmentService : ITreatmentService
    {
        private EpidemicTrackerContext _context;

        public TreatmentService(EpidemicTrackerContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<TreatementDto>> GetAllAsync(int diseaseId)
        {
            var treatments = _context.Treatment.Include(x => x.Patient).ThenInclude(x=>x.Occupation).Include(x => x.Disease).Include(x => x.Hospital).Where(x => x.DiseaseId == diseaseId && x.PercentageCure == 100).ToList();
            return treatments;
                
        }

        public async Task SaveTreatmentAsync(TreatementDto treatementDto)
        {
                var treatment = new Treatment();

            //    treatment.Patient = new Patient()
            //    {
            //        Name = treatementDto.patient.Name,
            //        Age = treatementDto.patient.Age,
            //        Gender = treatementDto.patient.Gender,
            //        Phone = treatementDto.patient.Phone,
            //        AadharId = treatementDto.patient.AadharId,
            //        Address = (from b in treatementDto.patient.Addresses
            //                   select new Address
            //                   {
            //                      AddressId=b.AddressDtoId,
            //                      AddressType=b.AddressType,
            //                      Street=b.Street,
            //                      City=b.City,
            //                      State=b.State,
            //                      Country=b.Country,
            //                      Pincode=b.Pincode
            //                   }

            //                 ).ToList(),
            //        Occupation=(from b in treatementDto.patient.Occupations
            //                    select new Occupation
            //                    {
            //                       OccupationId=b.OccupationDtoId,
            //                       Name=b.Name,
            //                       Phone=b.Phone,
            //                       StreetNo=b.StreetNo,
            //                       Area=b.Area,
            //                       City=b.City,
            //                       State=b.State,
            //                       Country=b.Country,
            //                       Pincode=b.Pincode

            //                    }
            //                    ).ToList(),
            //        Treatment=(from t in treatementDto.patient.Treatments
            //                   select new Treatment
            //                   {
            //                       TreatmentId=t.TreatmentDtoId,
            //                       AdmittedDate=t.AdmittedDate,
            //                       PercentageCure=t.PercentageCure,
            //                       RelievingDate=t.RelievingDate,
            //                       Isfatility=t.Isfatility
            //                   }).ToList()


            //    };
        //    treatment.Disease = new Disease()
        //{
        //    DiseaseId = treatementDto.disease.DiseaseDtoId,
        //        Name = treatementDto.disease.Name

        //    };







        //Statusenum status = patientdto.Status;
        //string str = status.ToString();
        //patient.Status = str;



        _context.Treatment.Add(treatment);
        await _context.SaveChangesAsync();


          }
    }
}
