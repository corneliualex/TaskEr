using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskEr.Models;

namespace TaskEr.Controllers
{
    [Authorize]
    public class JobCategoriesController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        //[Authorize(Roles = "Administrator,Developer,Moderator,Worker")]
        #region GetRequests

        public ActionResult Index()
        {
            var jobCategories = _context.JobCategories.ToList();
            if (jobCategories.Count == 0)
            {
                ModelState.AddModelError("", JobCategoriesErrors.EMPTYDB);
                return View();
            }
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
            return View("UpdateForm",jobCategory);
        }

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
        public ActionResult CreateForm(JobCategory jobCategory)
        {
            jobCategory.AddedBy = User.Identity.GetUserName();
            jobCategory.DateAdded = DateTime.Now;
            _context.JobCategories.Add(jobCategory);
            _context.SaveChanges();
            return RedirectToAction("Index", "JobCategories");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateForm(JobCategory jobCategory)
        {
            var jobInDb = _context.JobCategories.Single(j => j.Id == jobCategory.Id);
            jobInDb.Name = jobCategory.Name;
            jobInDb.Description = jobCategory.Description;
            jobInDb.DateModified = DateTime.Now;
            jobInDb.ModifiedBy = User.Identity.GetUserName();

            _context.SaveChanges();
            return RedirectToAction("Index","JobCategories");
        }
        #endregion
    }

    public sealed class JobCategoriesErrors
    {
        public static readonly string EMPTYDB = "0 records found.";
    }
}