using System;
using System.Collections.Generic;
using System.Linq;
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
        public AddressDto Address { get; set; }
        public OccupationDto Occupation { get; set; }
    }
}
