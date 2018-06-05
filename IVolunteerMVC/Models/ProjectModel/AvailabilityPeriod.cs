using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IVolunteerMVC.Models.ProjectModel
{
    public class AvailabilityPeriod
    {
        public int AvailabilityPeriodId { get; set; }

        [Required]
        [Display(Name = "Current Location")]
        public string CurrentLocation { get; set; }

        [Required]
        [Display(Name = "Field Of Interest")]
        public string FieldOfInterest { get; set; }

        [Required]
        [Display(Name = "From")]
        public DateTime DateFrom { get; set; }

        [Required]
        [Display(Name = "To")]
        public DateTime DateTo { get; set; }


    }
}
