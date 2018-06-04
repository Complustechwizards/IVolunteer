using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IVolunteer.Models.ProjectModel
{
    public enum State
    {
        Open,Closed
    }
   
    public class Posting
    {
        public int PostingId { get; set; }

        [Required]
        [Display(Name ="Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [Display(Name = "Job Location")]
        public string JobLocation { get; set; }

        [Required]
        [Display(Name = "Job Category")]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Requirements")]
        public string Requirements { get; set; }

        [Required]
        [Display(Name = "Number Of Volunteers Needed")]
        public int NumberOfVolunteersNeeded { get; set; }

        [Required]
        [Display(Name = "Age Requirement: From")]
        [Range(16,70)]
        public int AgeRequirementFrom { get; set; }

        [Required]
        [Display(Name = "Age Requirement: To")]
        [Range(16,70)]
        public int AgeRequirementTo { get; set; }

        public State State { get; set; }

        public ICollection<Application> Applications { get; set;}

    }
}
