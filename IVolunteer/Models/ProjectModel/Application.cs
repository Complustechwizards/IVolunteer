using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IVolunteer.Models.ProjectModel
{
  
    public class Application
    {

        public int ApplicationId { get; set; }
        public int PostingId { get; set; }
        public int ApplicationUserId { get; set; }

        [Display(Name = "Cover Letter")]
        [StringLength(500, MinimumLength = 10)]
        public string CoverLetter { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfApplication { get; set; }

        public Posting Posting { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

    }
}
