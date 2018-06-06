using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IVolunteerMVC.Models.ProjectModel
{
    public class Profile
    {
        [Display(Name = "First Name")]
        public String FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }

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
        public string InstagramHandle { get; set; }


        [Display(Name = "LinkedIn")]
        public string LinkedIn { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }


    }
}
