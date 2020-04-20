using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services.Dtos
{
    public class TreatmentDto
    {
        public int TreatmentId { get; set; }
        public DateTime AdmittedDate { get; set; }
        public decimal PercentageCure { get; set; }
        public DateTime? RelievingDate { get; set; }
        public bool Isfatility { get; set; }
        public PatientDto PatientdtoId { get; set; }
        public DiseaseDto DiseasedtoId { get; set; }
        public HospitalDto HospitaldtoId { get; set; }
    }
}
