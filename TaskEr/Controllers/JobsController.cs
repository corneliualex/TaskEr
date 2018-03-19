using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskEr.Models;
using System.Data.Entity;
using TaskEr.ViewModels;
using TaskEr.ApplicationHelpers.LoggedInUserHelper;

namespace TaskEr.Controllers
{
    [Authorize]
    public class JobsController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        private ILoggedInUser<ApplicationUser> _loggedInUser;

        private readonly ApplicationUser currentUser;
        private readonly string currentUserId;

        public JobsController()
        {
            _loggedInUser = new LoggedInUser(System.Web.HttpContext.Current);
        }

        #region GetRequests
        public ActionResult Index(string date)
        {
           
            var jobsByUser = _context.Jobs
                .Include(j => j.JobCategory)
                .Where(j => j.ApplicationUserId.Equals(currentUserId))
                .ToList();

            if (!String.IsNullOrEmpty(date))
            {
                var jobsByUserAndDate = new List<Job>();
                foreach (var item in jobsByUser)
                {
                    if (date.Equals(item.AddedDateTime.ToShortDateString()))
                    {
                        jobsByUserAndDate.Add(item);
                    }
                }
                return View(jobsByUserAndDate);
            }else
            {
                return View(jobsByUser);
            }
            
           
           
        }

        public ActionResult Create()
        {
            var viewModel = new JobByCategoriesViewModel
            {
                Job = new Job(),
                JobCategories = _context.JobCategories.ToList()

            };
            return View("CreateForm", viewModel);
        }

        public ActionResult Read(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "JobsController");

            var job = _context.Jobs.Include(jobCat => jobCat.JobCategory).SingleOrDefault(j => j.Id == id);
            if (job == null)
                return HttpNotFound();

            return View(job);
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Jobs");

            var job = _context.Jobs.SingleOrDefault(j => j.Id == id);
            if (job == null)
                return HttpNotFound();

            var viewModel = new JobByCategoriesViewModel
            {
                Job = job,
                JobCategories = _context.JobCategories.ToList()
            };
            return View("UpdateForm", viewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Jobs");

            var job = _context.Jobs.SingleOrDefault(j => j.Id == id);
            if (job == null)
                return HttpNotFound();

            _context.Jobs.Remove(job);
            _context.SaveChanges();
            return RedirectToAction("Index", "Jobs");
        }
        #endregion

        #region PostRequests

        [HttpPost]
        public ActionResult Create(Job job)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new JobByCategoriesViewModel
                {
                    Job = job,
                    JobCategories = _context.JobCategories.ToList()
                };
                return View("CreateForm", viewModel);
            }

            job.AddedDateTime = DateTime.Now;
            _context.Jobs.Add(job);
            _context.SaveChanges();
            return RedirectToAction("Index", "Jobs");
        }

        [HttpPost]
        public ActionResult Update(Job job)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new JobByCategoriesViewModel
                {
                    Job = job,
                    JobCategories = _context.JobCategories.ToList()
                };
                return View("UpdateForm", viewModel);
            }

            var jobInDb = _context.Jobs.Single(j => j.Id == job.Id);
            jobInDb.Description = job.Description;
            jobInDb.JobCategoryId = job.JobCategoryId;
            jobInDb.ApplicationUserId = job.ApplicationUserId;
            jobInDb.TimeStarted = job.TimeStarted;
            jobInDb.TimeEnded = job.TimeEnded;
            jobInDb.TimeSpent = job.TimeSpent;

            _context.SaveChanges();
            return RedirectToAction("Index", "Jobs");
        }
        #endregion

        #region Helpers
        private string SetDate(DateTime date)
        {
            return date.ToShortDateString();
        }
        #endregion
    }
}