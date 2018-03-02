﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskEr.ApplicationHelpers;
using TaskEr.CustomAttributes;
using TaskEr.Models;

namespace TaskEr.Controllers
{
    [Authorize]
    public class JobCategoriesController : Controller
    {
        #region fields and constructors
        private ILoggedInUser<ApplicationUser, IdentityUserRole> _loggedInUser;
        private ApplicationDbContext _context;

        public JobCategoriesController()
        {
            _loggedInUser = new LoggedInUser(System.Web.HttpContext.Current);
            _context = new ApplicationDbContext();
        }
        #endregion

        #region GetRequests
        public ActionResult Index()
        {
            var jobCategories = _context.JobCategories.ToList();
            return View(jobCategories);
        }

        public ActionResult Create()
        {
            return View("CreateForm", new JobCategory());
        }

        public ActionResult Read(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "JobCategories");

            var jobCategory = _context.JobCategories.SingleOrDefault(j => j.Id == id);

            if (jobCategory == null)
                return HttpNotFound();
            return View(jobCategory);
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "JobCategories");

            var jobCategory = _context.JobCategories.SingleOrDefault(j => j.Id == id);

            if (jobCategory == null)
                return HttpNotFound();
            return View("UpdateForm", jobCategory);
        }

        [JobCategoriesAuthorize(Roles ="Developer,Administrator,Moderator")]
        public ActionResult Delete(int? id)
        {
            var jobCategory = _context.JobCategories.SingleOrDefault(j => j.Id == id);

            if (jobCategory == null)
                return HttpNotFound();

            _context.JobCategories.Remove(jobCategory);
            _context.SaveChanges();
            return RedirectToAction("Index", "JobCategories");
        }
        #endregion

        #region PostRequests
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobCategory jobCategory)
        {
            jobCategory.AddedBy = User.Identity.GetUserName();
            jobCategory.DateAdded = DateTime.Now;
            _context.JobCategories.Add(jobCategory);
            _context.SaveChanges();
            return RedirectToAction("Index", "JobCategories");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(JobCategory jobCategory)
        {
            var jobInDb = _context.JobCategories.Single(j => j.Id == jobCategory.Id);
            jobInDb.Name = jobCategory.Name;
            jobInDb.Description = jobCategory.Description;
            jobInDb.DateModified = DateTime.Now;
            jobInDb.ModifiedBy = User.Identity.GetUserName();

            _context.SaveChanges();
            return RedirectToAction("Index", "JobCategories");
        }
        #endregion
    }
}