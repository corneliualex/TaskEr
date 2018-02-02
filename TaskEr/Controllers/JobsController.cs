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

namespace TaskEr.Controllers
{
    [Authorize]
    public class JobsController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        #region GetRequests

        public ActionResult Index()
        {
            var myJobs = _context.Jobs.Include(user => user.ApplicationUser).Include(jobCat => jobCat.JobCategory).ToList();
            return View(myJobs);
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

            job.ApplicationUserId = User.Identity.GetUserId();
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

            _context.SaveChanges();
            return RedirectToAction("Index","Jobs");
        }
        #endregion
    }
}