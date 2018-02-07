using Microsoft.AspNet.Identity;
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

        public TimeSpan TimeStarted { get; set; }

        public TimeSpan? TimeEnded { get; set; }

        public DateTime AddedDateTime { get; set; }

        private TimeSpan? _timeSpent;
        public TimeSpan? TimeSpent
        {
            get
            {
                return _timeSpent;
            }
            set
            {
                if (TimeEnded.HasValue == true)
                {
                    _timeSpent = TimeEnded.Value - TimeStarted;
                }

            }
        }

        //
        //Foreign keys
        public int JobCategoryId { get; set; }

        private string _applicationUserId;
        public string ApplicationUserId
        {
            get { return _applicationUserId; }
            set { _applicationUserId = HttpContext.Current.User.Identity.GetUserId(); }
        }
        //
        //navigation properties
        public JobCategory JobCategory { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}