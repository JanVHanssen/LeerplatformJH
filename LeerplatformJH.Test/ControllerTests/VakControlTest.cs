using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeerplatformJH.Controllers;
using LeerplatformJH.Models;
using LeerplatformJH.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LeerplatformJH.Test.ControllerTests
{


        [TestClass]
        public class VakControlTest
        {
            [TestMethod]
            public async Task Index_ReturnsViewResultWithVakken()
            {
                // Arrange
                var mockService = new Mock<IVakService>();
                mockService.Setup(s => s.GetAllVakken())
                           .Returns(new List<Vak> { new Vak { VakId = 1, Titel = "Test Vak", Studiepunten = 3 } });

                var controller = new VaksController(mockService.Object);

                // Act
                var result = await controller.Index();

                // Assert
                Assert.IsInstanceOfType(result, typeof(ViewResult));
                var viewResult = (ViewResult)result;
                Assert.IsInstanceOfType(viewResult.Model, typeof(IEnumerable<Vak>));
                var model = (IEnumerable<Vak>)viewResult.Model;
                Assert.AreEqual(1, model.Count());
            }

            [TestMethod]
            public async Task Details_ReturnsViewResultWithValidModel()
            {
                // Arrange
                var mockService = new Mock<IVakService>();
                mockService.Setup(s => s.GetVak(1))
                           .Returns(new Vak { VakId = 1, Titel = "Test Vak", Studiepunten = 3 });

                var controller = new VaksController(mockService.Object);

                // Act
                var result = await controller.Details(1);

                // Assert
                Assert.IsInstanceOfType(result, typeof(ViewResult));
                var viewResult = (ViewResult)result;
                Assert.IsInstanceOfType(viewResult.Model, typeof(Vak));
                var model = (Vak)viewResult.Model;
                Assert.AreEqual(1, model.VakId);
            }

            [TestMethod]
            public async Task Details_ReturnsNotFoundResultForInvalidId()
            {
                // Arrange
                var mockService = new Mock<IVakService>();
                mockService.Setup(s => s.GetVak(It.IsAny<int>()))
                           .Returns((Vak)null);

                var controller = new VaksController(mockService.Object);

                // Act
                var result = await controller.Details(1);

                // Assert
                Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            }
        [TestMethod]
        public void Create_Get_ReturnsViewResult()
        {
            // Arrange
            var mockService = new Mock<IVakService>();
            var controller = new VaksController(mockService.Object);

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task Create_Post_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var mockService = new Mock<IVakService>();
            mockService.Setup(s => s.CreateVak(It.IsAny<Vak>()));
            var controller = new VaksController(mockService.Object);
            var validModel = new Vak { VakId = 1, Titel = "Test Vak", Studiepunten = 3 };

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
            var mockService = new Mock<IVakService>();
            var controller = new VaksController(mockService.Object);
            controller.ModelState.AddModelError("error", "Sample error message");
            var invalidModel = new Vak { VakId = 1, Titel = "Test Vak", Studiepunten = 0 }; // Invalid model

            // Act
            var result = await controller.Create(invalidModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.AreEqual(invalidModel, viewResult.Model); // Ensure the same model is returned
        }
        [TestMethod]
        public async Task Edit_Get_ValidId_ReturnsViewResultWithModel()
        {
            // Arrange
            var mockService = new Mock<IVakService>();
            mockService.Setup(s => s.GetVak(1))
                       .Returns(new Vak { VakId = 1, Titel = "Test Vak", Studiepunten = 3 });
            var controller = new VaksController(mockService.Object);

            // Act
            var result = await controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.Model, typeof(Vak));
        }

        [TestMethod]
        public async Task Edit_Get_InvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            var mockService = new Mock<IVakService>();
            var controller = new VaksController(mockService.Object);

            // Act
            var result = await controller.Edit(null); // Invalid id

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task Edit_Post_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var mockService = new Mock<IVakService>();
            mockService.Setup(s => s.EditVak(It.IsAny<Vak>()));
            var controller = new VaksController(mockService.Object);
            var validModel = new Vak { VakId = 1, Titel = "Test Vak", Studiepunten = 3 };

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
            var mockService = new Mock<IVakService>();
            var controller = new VaksController(mockService.Object);
            var validModel = new Vak { VakId = 1, Titel = "Test Vak", Studiepunten = 3 };

            // Act
            var result = await controller.Edit(2, validModel); // Invalid id

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        [TestMethod]
        public async Task Delete_Get_ValidId_ReturnsViewResultWithModel()
        {
            // Arrange
            var mockService = new Mock<IVakService>();
            mockService.Setup(s => s.GetVak(1))
                       .Returns(new Vak { VakId = 1, Titel = "Test Vak", Studiepunten = 3 });
            var controller = new VaksController(mockService.Object);

            // Act
            var result = await controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.Model, typeof(Vak));
        }

        [TestMethod]
        public async Task Delete_Get_InvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            var mockService = new Mock<IVakService>();
            var controller = new VaksController(mockService.Object);

            // Act
            var result = await controller.Delete(null); // Invalid id

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task DeleteConfirmed_Post_ValidId_RedirectsToIndex()
        {
            // Arrange
            var mockService = new Mock<IVakService>();
            mockService.Setup(s => s.GetVak(1))
                       .Returns(new Vak { VakId = 1, Titel = "Test Vak", Studiepunten = 3 });
            var controller = new VaksController(mockService.Object);

            // Act
            var result = await controller.DeleteConfirmed(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

    }
    }