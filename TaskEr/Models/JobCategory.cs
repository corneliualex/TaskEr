using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskEr.Models
{
    public class JobCategory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }

        public string AddedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? DateAdded { get; set; }

        public DateTime? DateModified { get; set; }

    }
}