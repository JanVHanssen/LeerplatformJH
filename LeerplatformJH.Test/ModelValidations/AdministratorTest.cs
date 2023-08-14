using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using LeerplatformJH.Models;
using LeerplatformJH.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace LeerplatformJH.Test.ModelValidations
{
    [TestClass]
    public class AdministratorTest
    {
        private ApplicationDbContext _context;
        [TestInitialize]
        public void Initialize()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite(connection)
            .Options;
            _context = new ApplicationDbContext(options);
            _context.Database.EnsureCreated();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
        [TestMethod]
        public void ValidateAdministratorModel_NameIsRequired()
        {
            // Arrange
            var administrator = new Administrator
            {
                AdministratorId = 1,
                Achternaam = null,
                Voornaam = null,
                Email = "test@example.com",
                Indiensttreding = DateTime.Parse("2020-01-01")
            };
            // Act & Assert
            Assert.ThrowsExceptionAsync<ValidationException>(() =>
           _context.SaveChangesAsync());
        }
    }
}
