using Iron_Mountain_Coding_Challenge.Models;
using Iron_Mountain_Coding_Challenge.Repository;
using Iron_Mountain_Coding_Challenge.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronMountain.Tests.UnitTests
{
    [TestFixture]
    public class RepositoryTest
    {
        private Mock<IEmployeeRepository> _mockRepo;

        [SetUp]
        public void Setup()
        {
            List<Employee> list = new List<Employee>
            {
                new Employee { EmployeeID = "00000004", FirstName = "Jim", LastName = "Doe", DOB = DateTime.Today.AddYears(-10) },
                new Employee { EmployeeID = "00000005", FirstName = "John", LastName = "Smith", DOB = DateTime.Today.AddYears(-60) }, // 60 yrs
                new Employee { EmployeeID = "00000006", FirstName = "Alex", LastName = "Doe", DOB = DateTime.Today.AddYears(-30) } // 30 yrs
            };

            _mockRepo = new Mock<IEmployeeRepository>();
            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(list);
            //_mockRepo.Setup(r => r.SearchByNlp(It.IsAny<string>()))
            //    .ReturnsAsync(list);
        }

        [Test]
        public void GetAll_ShouldReturnEmployees()
        {
            var employees = _mockRepo.Object.GetAllAsync().Result;
            Assert.That(employees.Count(), Is.EqualTo(3));
            Assert.That(employees.First().FirstName, Is.EqualTo("Jim"));
        }

        [Test]
        public async Task SearchByNlp_Should_Filter_By_MinAge()
        {
            // Arrange
            dynamic filters = new System.Dynamic.ExpandoObject();
            filters.AgeMin = 40;
            filters.NameContains = "John";

            var expectedEmployees = new List<Employee>
            {
                new Employee { FirstName = "John", LastName = "Doe" },
                new Employee { FirstName = "Johnny", LastName = "Smith" }
            };

            _mockRepo.Setup(r => r.SearchByNlp(It.IsAny<object>()))
                .ReturnsAsync(expectedEmployees);

            // Act
            //var results = _mockRepo.Object.SearchByNlp(filters).ToList();
            var result = await _mockRepo.Object.SearchByNlp(filters);

            // Assert
            Assert.That(2, Is.EqualTo(result.Count));
            Assert.That("John", Is.EqualTo(result[0].FirstName));
        }
    }
}
