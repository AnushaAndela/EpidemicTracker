using System;
using System.Collections.Generic;

namespace EpidemicTracker.Data.Models
{
    public partial class DiseaseType
    {
        public DiseaseType()
        {
            Disease = new HashSet<Disease>();
        }

        public int DiseaseTypeId { get; set; }
        public string TypeOfDisease { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Disease> Disease { get; set; }
    }
}
