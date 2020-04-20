using System;
using System.Collections.Generic;

namespace EpidemicTracker.Data.Models
{
    public partial class Disease
    {
        public Disease()
        {
            Treatment = new HashSet<Treatment>();
        }

        public int DiseaseId { get; set; }
        public string Name { get; set; }
        public int? DiseaseTypeId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual DiseaseType DiseaseType { get; set; }
        public virtual ICollection<Treatment> Treatment { get; set; }
    }
}
