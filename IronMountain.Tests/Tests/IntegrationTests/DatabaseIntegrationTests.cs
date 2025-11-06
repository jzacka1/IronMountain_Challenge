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
        public async void InsertEmployee_ShouldAddRecordToDatabase()
        {
            using (var context = new EmployeeContext())
            {
                var emp = new Employee
                {
                    EmployeeID = "00000001",
                    FirstName = "Alice",
                    LastName = "Smith",
                    DOB = new System.DateTime(1988, 2, 12)
                };

                await _repository.AddAsync(emp);
                _repository.Save();

                var result = _repository.GetAllAsync().Result.FirstOrDefault(e => e.EmployeeID == "00000001");
                Assert.That(result, Is.Not.Null);
                Assert.That(result.LastName, Is.EqualTo("Smith"));
            }
        }

        public async void DeleteEmployee_ShouldRemoveRecordToDatabase()
        {
            using (var context = new EmployeeContext())
            {
                var emp = new Employee
                {
                    EmployeeID = "00000006",
                    FirstName = "George",
                    LastName = "Morane",
                    DOB = new System.DateTime(1982, 9, 22)
                };

                await _repository.AddAsync(emp);
                _repository.Save();

                var result = _repository.GetAllAsync().Result.FirstOrDefault(e => e.EmployeeID == "00000006");
                Assert.That(result, Is.Not.Null);
                Assert.That(result.LastName, Is.EqualTo("Morane"));

                await _repository.DeleteAsync(emp.EmployeeID);
                _repository.Save();
                result = _repository.GetAllAsync().Result.FirstOrDefault(e => e.EmployeeID == "00000006");
                Assert.That(result, Is.Null);
            }
        }

        [Test]
        public async void ExportToText_ShouldCreatePipeDelimitedFile()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeID = "00000002",
                FirstName = "Alex",
                LastName = "Johnson",
                DOB = new System.DateTime(1989, 3, 10)
            };
            await _repository.AddAsync(employee);
            _repository.Save();

            // Act
            TextFileDto textFileDto = TextExporter.ExportEmployeesToTextFile(_repository.GetAllAsync().Result.ToList());

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
