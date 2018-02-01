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
    public class JobsController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

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
            return View("CreateForm",viewModel);
        }

        public ActionResult Read()
        {
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
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
        public ActionResult UpdateForm(Job job)
        {
            return View();
        }
        #endregion
    }
}