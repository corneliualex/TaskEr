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
            return View("CreateForm",new JobCategory());
        }

        public ActionResult Read(int id)
        {
            var jobCategory = _context.JobCategories.SingleOrDefault(j => j.Id == id);

            if (jobCategory == null)
                return HttpNotFound();
            return View(jobCategory);
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
        public ActionResult CreateForm(JobCategory jobCategory)
        {
            _context.JobCategories.Add(jobCategory);
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