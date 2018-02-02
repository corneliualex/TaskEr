using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskEr.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEr.Models;

namespace TaskEr.Controllers.Tests
{
    [TestClass()]
    public class JobsControllerTests
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        [TestMethod()]
        public void UpdateTest()
        {
            var jobInDb = _context.Jobs.SingleOrDefault(j => j.Description == "Test");
        }
    }
}