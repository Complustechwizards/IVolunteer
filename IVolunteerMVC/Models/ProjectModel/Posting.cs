using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IVolunteerMVC.Models.ProjectModel
{
    public enum State
    {
        Open, Closed
    }
    public enum Location
    {
        Abia, Rivers, Enugu, Ebonyi, Imo, Lagos, Anambra, Oyo, Abuja
    }
    public enum Category
    {
        Administration,Science,Art,Commercial,Language,Counselling
    }
    public class Posting
    {
        public int PostingId { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [Display(Name = "Job Location")]
        public Location JobLocation { get; set; }

        [Required]
        [Display(Name = "Job Category")]
        public Category Category { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Number Of Volunteers Needed")]
        public int NumberOfVolunteersNeeded { get; set; }

        [Required]
        [Display(Name = "Age Requirement: From")]
        [Range(16, 70)]
        public int AgeRequirementFrom { get; set; }

        [Required]
        [Display(Name = "Age Requirement: To")]
        [Range(16, 70)]
        public int AgeRequirementTo { get; set; }

        public State State { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Of Posting")]
        public DateTime DateOfPosting { get; set; }

        public virtual ICollection<JobApplication> JobApplications { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
