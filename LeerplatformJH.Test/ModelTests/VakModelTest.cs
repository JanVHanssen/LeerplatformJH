using System.ComponentModel.DataAnnotations;
using LeerplatformJH.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeerplatformJH.Test
{
    [TestClass]
    public class VakModelTests
    {
        [TestMethod]
        public void VakId_ShouldHaveKeyAttribute()
        {
            // Arrange
            var vakIdProperty = typeof(Vak).GetProperty("VakId");

            // Act
            var keyAttribute = vakIdProperty.GetCustomAttributes(typeof(KeyAttribute), true);

            // Assert
            Assert.IsTrue(keyAttribute.Length > 0);
        }

        [TestMethod]
        public void Titel_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var titelProperty = typeof(Vak).GetProperty("Titel");

            // Act
            var requiredAttribute = titelProperty.GetCustomAttributes(typeof(RequiredAttribute), true);

            // Assert
            Assert.IsTrue(requiredAttribute.Length > 0);
        }

        [TestMethod]
        public void Titel_ShouldHaveDisplayAttributeWithName()
        {
            // Arrange
            var titelProperty = typeof(Vak).GetProperty("Titel");

            // Act
            var displayAttribute = titelProperty.GetCustomAttributes(typeof(DisplayAttribute), true);

            // Assert
            Assert.IsTrue(displayAttribute.Length > 0);
            var displayName = ((DisplayAttribute)displayAttribute[0]).Name;
            Assert.AreEqual("Titel", displayName);
        }

        [TestMethod]
        public void Titel_ShouldHaveStringLengthAttribute()
        {
            // Arrange
            var titelProperty = typeof(Vak).GetProperty("Titel");

            // Act
            var stringLengthAttribute = titelProperty.GetCustomAttributes(typeof(StringLengthAttribute), true);

            // Assert
            Assert.IsTrue(stringLengthAttribute.Length > 0);
        }

        [TestMethod]
        public void Studiepunten_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var studiepuntenProperty = typeof(Vak).GetProperty("Studiepunten");

            // Act
            var requiredAttribute = studiepuntenProperty.GetCustomAttributes(typeof(RequiredAttribute), true);

            // Assert
            Assert.IsTrue(requiredAttribute.Length > 0);
        }

        [TestMethod]
        public void Studiepunten_ShouldHaveRangeAttribute()
        {
            // Arrange
            var studiepuntenProperty = typeof(Vak).GetProperty("Studiepunten");

            // Act
            var rangeAttribute = studiepuntenProperty.GetCustomAttributes(typeof(RangeAttribute), true);

            // Assert
            Assert.IsTrue(rangeAttribute.Length > 0);
        }
    }
}
