using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services.Dtos
{
    //Rename to something meaningfull
    public class View
    {
        public IEnumerable<PatientDto> PatientsWithCorona { get; set; }
        public IEnumerable<PatientDto> PatientsWithoutCorona { get; set; }
    }
}
