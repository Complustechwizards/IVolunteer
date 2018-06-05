using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IVolunteerMVC.Models.ProjectModel;
using Microsoft.AspNetCore.Identity;

namespace IVolunteerMVC.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public override string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        
        [Display(Name = "About Me")]
        public string AboutMe { get; set; }

        
        [Display(Name = "Facebook Profile Link")]
        public string FacebookLink { get; set; }

       
        [Display(Name = "Twitter Handle")]
        public string TwitterHandle { get; set; }

        
        [Display(Name = "Instagram Handle")]
        public string InstagramHandle  { get; set; }

        
        [Display(Name = "LinkedIn")]
        public string LinkedIn { get; set; }

        public ICollection<Posting> Postings { get; set; }

        public ICollection<JobApplication> JobApplications { get; set; }

        public ICollection<AvailabilityPeriod> AvailabilityPeriods { get; set; }

    }
}
