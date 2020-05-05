using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services.Dtos
{
    public class DiseaseTypeDto
    {
        public int DiseaseTypeId { get; set; }
        public string TypeOfDisease { get; set; }
        public List<DiseaseDto> Disease { get; set; }
    }
}
