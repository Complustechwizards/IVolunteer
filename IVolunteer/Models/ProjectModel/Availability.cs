using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVolunteer.Models.ProjectModel
{
    public class Availability
    {
        public int AvailabilityId { get; set; }

        public string CurrentLocation { get; set; }

        public string FieldOfInterest { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}
