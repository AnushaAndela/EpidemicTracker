using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services.Dtos
{
    public class PatientDto
    {
        public int PatientDtoId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public long Phone { get; set; }
        public long? AadharId { get; set; }

        //public bool IsInfected { get; set; }
        
       
        public List<AddressDto> Addresses { get; set; }
        public List<OccupationDto> Occupations { get; set; }
        public List<TreatmentDto> Treatments { get; set; }
    }
}
