using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services.Dtos
{
    public class TreatmentData
    {
        public List<TreatementDto> CuredList { get; set; }
        public List<TreatementDto> UnCuredList { get; set; }
    }
}
