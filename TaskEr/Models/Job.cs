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
        //Foreign key
        public int JobCategoryId { get; set; }
        //
        //navigation property
        public JobCategory JobCategory { get; set; }
    }
}