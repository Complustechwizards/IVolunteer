using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IVolunteerMVC.Models.ProjectModel
{
    public class JobApplication
    {
        public int JobApplicationId { get; set; }

        [Display(Name = "Cover Letter")]
        [StringLength(500, MinimumLength = 10)]
        public string CoverLetter { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Of Application")]
        public DateTime DateOfApplication { get; set; }

        public virtual Posting Posting { get; set; }
        public int PostingId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public int ApplicationUserId { get; set; }
    }
}
