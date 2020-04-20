using System;
using System.Collections.Generic;

namespace EpidemicTracker.Data.Models
{
    public partial class OccupationType
    {
        public int OccupationTypeId { get; set; }
        public string Type { get; set; }
        public int? OccupationId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Occupation Occupation { get; set; }
    }
}
