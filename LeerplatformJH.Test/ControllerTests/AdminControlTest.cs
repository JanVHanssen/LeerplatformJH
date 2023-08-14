using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeerplatformJH.Models;
using LeerplatformJH.Data;
using LeerplatformJH.Controllers;
using LeerplatformJH.Services;
using LeerplatformJH.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeerPlatformJH.Services;

namespace LeerplatformJH.Test.ControllerTests
{
    [TestClass]
    public class AdminControlTest
    {
        ApplicationDbContext context;
        AdministratorsController acontrol;

        [TestInitialize]
        public void Init()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase("GIP");
            context = new ApplicationDbContext(builder.Options);
            IAdminsService svc = new AdminsService(context);
            acontrol = new AdministratorsController(svc);
        }

        [TestMethod]
        public void testIndex()
        {
            //ACT
            IActionResult result = (IActionResult)acontrol.Index();

            //ASSERT
            Assert.IsNotNull(result);
            Assert.IsTrue(result is ViewResult);
            ViewResult viewResult = (ViewResult)result;
            Assert.IsTrue(viewResult.Model is IEnumerable<Administrator>);
        }



        [TestMethod]
        public void testCreate()
        {
            //ARRANGE
            Administrator testAdmin = new Administrator();
            testAdmin.Achternaam = "Vandenbroek";

            //ACT
            acontrol.Create(testAdmin);
            var isCreated = context.Administratoren.Count();

            //ASSERT
            Assert.AreEqual(isCreated, 1);
            Assert.IsNotNull(isCreated);
            Assert.IsInstanceOfType(isCreated, typeof(int));
            Assert.IsInstanceOfType(testAdmin, typeof(Administrator));
        }

        

        [TestMethod]
        public void testEdit()
        {
            //ARRANGE
            Administrator testAdmin = new Administrator();
            testAdmin.Achternaam = "Ronaldo";
            testAdmin.Voornaam = "Cristiano";
            context.Entry(testAdmin).State = EntityState.Modified;
            testAdmin.Email = "Ronaldo@voetbal.com";
            testAdmin.Indiensttreding = DateTime.Parse("2020-10-10");

            //ACT
            acontrol.Create(testAdmin);
          
            //ASSERT          
            Assert.IsNotNull(testAdmin);
            Assert.IsInstanceOfType(testAdmin, typeof(Administrator));

        }


        [TestMethod]
        public void testDelete()
        {
            //ARRANGE
            Administrator testAdmin = new Administrator();
            testAdmin.AdministratorId = 3;

            //ACT
            acontrol.Create(testAdmin);
            var isCreated = context.Administratoren.Count();
            acontrol.DeleteConfirmed(3);
            var isDeleted = context.Administratoren.Count();

            //ASSERT
            Assert.AreEqual(isCreated, 1);
            Assert.AreEqual(isDeleted, 0);
        }
    }
}
