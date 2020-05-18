using EpidemicTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services.Dtos
{
    public class TreatementDto
    {
        public int TreatmentDtoId { get; set; }
        public DateTime AdmittedDate { get; set; }
        public decimal PercentageCure { get; set; }
        public DateTime? RelievingDate { get; set; }
        public string Isfatility { get; set; }
        public int? PatientId { get; set; }
        public int? DiseaseId { get; set; }
        public int? HospitalId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual DiseaseDto Disease { get; set; }
        public virtual HospitalDto Hospital { get; set; }
        public virtual PatientDto Patient { get; set; }
    }
}
