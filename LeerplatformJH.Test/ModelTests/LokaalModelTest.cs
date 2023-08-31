using LeerplatformJH.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeerplatformJH.Test
{
    [TestClass]
    public class LokaalModelTest
    {

        [TestMethod]
        public void Titel_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var titelProperty = typeof(Lokaal).GetProperty("Titel");

            // Act
            var requiredAttribute = titelProperty.GetCustomAttributes(typeof(RequiredAttribute), true);

            // Assert
            Assert.IsTrue(requiredAttribute.Length > 0);
        }

        [TestMethod]
        public void Titel_ShouldHaveDisplayAttributeWithName()
        {
            // Arrange
            var titelProperty = typeof(Lokaal).GetProperty("Titel");

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
            var titelProperty = typeof(Lokaal).GetProperty("Titel");

            // Act
            var stringLengthAttribute = titelProperty.GetCustomAttributes(typeof(StringLengthAttribute), true);

            // Assert
            Assert.IsTrue(stringLengthAttribute.Length > 0);
        }

        [TestMethod]
        public void Omschrijving_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var omschrijvingProperty = typeof(Lokaal).GetProperty("Omschrijving");

            // Act
            var requiredAttribute = omschrijvingProperty.GetCustomAttributes(typeof(RequiredAttribute), true);

            // Assert
            Assert.IsTrue(requiredAttribute.Length > 0);
        }

        [TestMethod]
        public void Capaciteit_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var capaciteitProperty = typeof(Lokaal).GetProperty("Capaciteit");

            // Act
            var requiredAttribute = capaciteitProperty.GetCustomAttributes(typeof(RequiredAttribute), true);

            // Assert
            Assert.IsTrue(requiredAttribute.Length > 0);
        }

        [TestMethod]
        public void Capaciteit_ShouldHaveRangeAttribute()
        {
            // Arrange
            var capaciteitProperty = typeof(Lokaal).GetProperty("Capaciteit");

            // Act
            var rangeAttribute = capaciteitProperty.GetCustomAttributes(typeof(RangeAttribute), true);

            // Assert
            Assert.IsTrue(rangeAttribute.Length > 0);
        }
    }
}
