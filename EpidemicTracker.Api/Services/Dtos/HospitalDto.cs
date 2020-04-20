using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services.Dtos
{
    public class HospitalDto
    {
        public int HospitalDtoId { get; set; }
        public string Name { get; set; }
        public long Phone { get; set; }
        public string StreetNo { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int? Pincode { get; set; }
    }
}
