using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskEr.Models;

namespace TaskEr.Controllers
{
    //[Authorize]
    public class JobCategoriesController : Controller
    {
        //[Authorize(Roles = "Administrator,Developer,Moderator,Worker")]
        #region GetRequests

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
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

        #endregion
    }
}