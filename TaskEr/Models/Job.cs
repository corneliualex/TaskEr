using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskEr.Models
{
    public class Job
    {
        public int Id { get; set; }

        public string Description { get; set; }

        //
        //Foreign keys
        public int JobCategoryId { get; set; }
        public string ApplicationUserId { get; set; }
        //
        //navigation properties
        public JobCategory JobCategory { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}