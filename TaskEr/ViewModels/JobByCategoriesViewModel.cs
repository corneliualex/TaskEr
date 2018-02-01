using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskEr.Models;

namespace TaskEr.ViewModels
{
    public class JobByCategoriesViewModel
    {
        public Job Job { get; set; }
        public IEnumerable<JobCategory> JobCategories { get; set; }
    }
}