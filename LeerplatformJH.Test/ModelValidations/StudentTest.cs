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
    public class StudentTest
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
        public void ValidateStudentModel_NameIsRequired()
        {
            // Arrange
            var student = new Student
            {
                StudentId = 1,
                Achternaam = null,
                Voornaam = null,
                Email = "test@example.com",
                Inschrijvingsdatum = DateTime.Parse("2020-01-01"),
                Vakinschrijvingen = null,
                Lessen = null
            };
            // Act & Assert
            Assert.ThrowsExceptionAsync<ValidationException>(() =>
           _context.SaveChangesAsync());
        }
    }
}
