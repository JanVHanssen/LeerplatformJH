using LeerplatformJH.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LeerplatformJH.Models;

namespace LeerplatformJH.Test
{
    [TestClass]
    public class StudentModelTest
    {
        [TestMethod]
        public void StudentId_ShouldHaveKeyAttribute()
        {
            // Arrange
            var studentIdProperty = typeof(Student).GetProperty("StudentId");

            // Act
            var keyAttribute = studentIdProperty.GetCustomAttributes(typeof(KeyAttribute), true);

            // Assert
            Assert.IsTrue(keyAttribute.Length > 0);
        }

        [TestMethod]
        public void Achternaam_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var achternaamProperty = typeof(Student).GetProperty("Achternaam");

            // Act
            var requiredAttribute = achternaamProperty.GetCustomAttributes(typeof(RequiredAttribute), true);

            // Assert
            Assert.IsTrue(requiredAttribute.Length > 0);
        }

        [TestMethod]
        public void Achternaam_ShouldHaveDisplayAttributeWithName()
        {
            // Arrange
            var achternaamProperty = typeof(Student).GetProperty("Achternaam");

            // Act
            var displayAttribute = achternaamProperty.GetCustomAttributes(typeof(DisplayAttribute), true);

            // Assert
            Assert.IsTrue(displayAttribute.Length > 0);
            var displayName = ((DisplayAttribute)displayAttribute[0]).Name;
            Assert.AreEqual("Achternaam", displayName);
        }
    }
}
