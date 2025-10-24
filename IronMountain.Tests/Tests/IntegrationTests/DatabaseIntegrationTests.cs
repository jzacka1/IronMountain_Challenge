using Effort;
using Iron_Mountain_Coding_Challenge.Models;
using Iron_Mountain_Coding_Challenge.Repository;
using Iron_Mountain_Coding_Challenge.Utilities;
using Iron_Mountain_Coding_Challenge.Utilities.DTO;
using NUnit.Framework;
using System.Linq;

namespace IronMountain.Tests.IntegrationTests
{
    [TestFixture]
    public class DatabaseIntegrationTests
    {
        private EmployeeContext _context;
        private EmployeeRepository _repository;

        [SetUp]
        public void Setup()
        {
            var connection = DbConnectionFactory.CreatePersistent("InMemoryTestDb");
            _context = new EmployeeContext(connection);
            _repository = new EmployeeRepository(_context);
        }

        [Test]
        public void InsertEmployee_ShouldAddRecordToDatabase()
        {
            using (var context = new EmployeeContext())
            {
                var emp = new Employee
                {
                    EmployeeID = 1,
                    FirstName = "Alice",
                    LastName = "Smith",
                    DOB = new System.DateTime(1988, 2, 12)
                };

                _repository.Add(emp);
                _repository.Save();

                var test = _repository.GetAll();
                var result = _repository.GetAll().FirstOrDefault(e => e.EmployeeID == 2);
                Assert.That(result, Is.Not.Null);
                Assert.That(result.LastName, Is.EqualTo("Smith"));
            }
        }

        [Test]
        public void ExportToText_ShouldCreatePipeDelimitedFile()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeID = 2,
                FirstName = "Alex",
                LastName = "Johnson",
                DOB = new System.DateTime(1989, 3, 10)
            };
            _repository.Add(employee);
            _repository.Save();

            // Act
            TextFileDto textFileDto = TextExporter.ExportEmployeesToTextFile(_repository.GetAll().ToList());

            // Assert
            Assert.That(System.IO.File.Exists(textFileDto.TxtFilePath), Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
            _repository.Dispose();
        }
    }
}
