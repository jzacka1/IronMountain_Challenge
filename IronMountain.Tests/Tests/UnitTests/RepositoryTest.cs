using Iron_Mountain_Coding_Challenge.Models;
using Iron_Mountain_Coding_Challenge.Repository;
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
            _mockRepo.Setup(r => r.GetAll()).Returns(list);
            _mockRepo.Setup(r => r.SearchByNlp(It.IsAny<string>())).Returns(list);
        }

        [Test]
        public void GetAll_ShouldReturnEmployees()
        {
            var employees = _mockRepo.Object.GetAll();
            Assert.That(employees.Count(), Is.EqualTo(3));
            Assert.That(employees.First().FirstName, Is.EqualTo("Jim"));
        }

        [Test]
        public async Task SearchByNlp_Should_Filter_By_MinAge()
        {
            // Act
            var results = _mockRepo.Object.SearchByNlp("older than 25").ToList();

            // Assert
            Assert.That(3, Is.EqualTo(results.Count));
            Assert.That("Jim", Is.EqualTo(results.First().FirstName));
        }
    }
}
