using LeerplatformJH.Controllers;
using LeerplatformJH.Models;
using LeerplatformJH.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeerplatformJH.Test.ControllerTests
{
    [TestClass]
    public class StudentControlTest
    {
        [TestMethod]
        public async Task Index_ReturnsViewResultWithStudenten()
        {
            // Arrange
            var mockService = new Mock<IStudentService>();
            mockService.Setup(s => s.GetAllStudenten())
                       .Returns(new List<Student> { new Student { StudentId = 1, Achternaam = "TestNaam", Voornaam = "NaamTest", Email = "Test@Mail.com", Inschrijvingsdatum = DateTime.Parse("2020-09-01") } });

            var controller = new StudentsController(mockService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.Model, typeof(IEnumerable<Student>));
            var model = (IEnumerable<Student>)viewResult.Model;
            Assert.AreEqual(1, model.Count());
        }

        [TestMethod]
        public async Task Details_ReturnsViewResultWithValidModel()
        {
            // Arrange
            var mockService = new Mock<IStudentService>();
            mockService.Setup(s => s.GetStudent(1))
                       .Returns(new Student { StudentId = 1, Achternaam = "TestNaam", Voornaam = "NaamTest", Email = "Test@Mail.com", Inschrijvingsdatum = DateTime.Parse("2020-09-01") });

            var controller = new StudentsController(mockService.Object);

            // Act
            var result = await controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.Model, typeof(Student));
            var model = (Student)viewResult.Model;
            Assert.AreEqual(1, model.StudentId);
        }

        [TestMethod]
        public async Task Details_ReturnsNotFoundResultForInvalidId()
        {
            // Arrange
            var mockService = new Mock<IStudentService>();
            mockService.Setup(s => s.GetStudent(It.IsAny<int>()))
                       .Returns((Student)null);

            var controller = new StudentsController(mockService.Object);

            // Act
            var result = await controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        [TestMethod]
        public void Create_Get_ReturnsViewResult()
        {
            // Arrange
            var mockService = new Mock<IStudentService>();
            var controller = new StudentsController(mockService.Object);

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task Create_Post_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var mockService = new Mock<IStudentService>();
            mockService.Setup(s => s.CreateStudent(It.IsAny<Student>()));
            var controller = new StudentsController(mockService.Object);
            var validModel = new Student { StudentId = 1, Achternaam = "TestNaam", Voornaam = "NaamTest", Email = "Test@Mail.com", Inschrijvingsdatum = DateTime.Parse("2020-09-01") };

            // Act
            var result = await controller.Create(validModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [TestMethod]
        public async Task Create_Post_InvalidModel_ReturnsViewResultWithModel()
        {
            // Arrange
            var mockService = new Mock<IStudentService>();
            var controller = new StudentsController(mockService.Object);
            controller.ModelState.AddModelError("error", "Sample error message");
            var invalidModel = new Student { StudentId = 1, Achternaam = "TestNaam", Voornaam = "NaamTest", Email = "Test@Mail.com", Inschrijvingsdatum = DateTime.Parse("2020-09-01") };

            // Act
            var result = await controller.Create(invalidModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.AreEqual(invalidModel, viewResult.Model);
        }
        [TestMethod]
        public async Task Edit_Get_ValidId_ReturnsViewResultWithModel()
        {
            // Arrange
            var mockService = new Mock<IStudentService>();
            mockService.Setup(s => s.GetStudent(1))
                       .Returns(new Student { StudentId = 1, Achternaam = "TestNaam", Voornaam = "NaamTest", Email = "Test@Mail.com", Inschrijvingsdatum = DateTime.Parse("2020-09-01") });
            var controller = new StudentsController(mockService.Object);

            // Act
            var result = await controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.Model, typeof(Student));
        }

        [TestMethod]
        public async Task Edit_Get_InvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            var mockService = new Mock<IStudentService>();
            var controller = new StudentsController(mockService.Object);

            // Act
            var result = await controller.Edit(null); // Invalid id

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task Edit_Post_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var mockService = new Mock<IStudentService>();
            mockService.Setup(s => s.EditStudent(It.IsAny<Student>()));
            var controller = new StudentsController(mockService.Object);
            var validModel = new Student { StudentId = 1, Achternaam = "TestNaam", Voornaam = "NaamTest", Email = "Test@Mail.com", Inschrijvingsdatum = DateTime.Parse("2020-09-01") };

            // Act
            var result = await controller.Edit(1, validModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [TestMethod]
        public async Task Edit_Post_InvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            var mockService = new Mock<IStudentService>();
            var controller = new StudentsController(mockService.Object);
            var validModel = new Student { StudentId = 1, Achternaam = "TestNaam", Voornaam = "NaamTest", Email = "Test@Mail.com", Inschrijvingsdatum = DateTime.Parse("2020-09-01") };

            // Act
            var result = await controller.Edit(2, validModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        [TestMethod]
        public async Task Delete_Get_ValidId_ReturnsViewResultWithModel()
        {
            // Arrange
            var mockService = new Mock<IStudentService>();
            mockService.Setup(s => s.GetStudent(1))
                       .Returns(new Student { StudentId = 1, Achternaam = "TestNaam", Voornaam = "NaamTest", Email = "Test@Mail.com", Inschrijvingsdatum = DateTime.Parse("2020-09-01") });
            var controller = new StudentsController(mockService.Object);

            // Act
            var result = await controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.Model, typeof(Student));
        }

        [TestMethod]
        public async Task Delete_Get_InvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            var mockService = new Mock<IStudentService>();
            var controller = new StudentsController(mockService.Object);

            // Act
            var result = await controller.Delete(null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task DeleteConfirmed_Post_ValidId_RedirectsToIndex()
        {
            // Arrange
            var mockService = new Mock<IStudentService>();
            mockService.Setup(s => s.GetStudent(1))
                       .Returns(new Student { StudentId = 1, Achternaam = "TestNaam", Voornaam = "NaamTest", Email = "Test@Mail.com", Inschrijvingsdatum = DateTime.Parse("2020-09-01") });
            var controller = new StudentsController(mockService.Object);

            // Act
            var result = await controller.DeleteConfirmed(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectResult.ActionName);
        }
    }
}
