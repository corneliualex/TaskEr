using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskEr.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TaskEr.Models;

namespace TaskEr.Controllers.Tests
{
    [TestClass()]
    public class JobCategoriesControllerTests
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        [TestMethod()]
        public void IndexTest()
        {
            JobCategoriesController controller = new JobCategoriesController();
            ViewResult result = controller.Index() as ViewResult;

            var jobCategories = _context.JobCategories.ToList();
            Assert.AreEqual(3, jobCategories.Count);
            
            
        }
    }
}