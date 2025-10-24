using Iron_Mountain_Coding_Challenge.Models;
using Iron_Mountain_Coding_Challenge.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
            _mockRepo = new Mock<IEmployeeRepository>();
            _mockRepo.Setup(r => r.GetAll()).Returns(new List<Employee>
            {
                new Employee { EmployeeID = 4, FirstName = "John", LastName = "Doe" }
            });
        }

        [Test]
        public void GetAll_ShouldReturnEmployees()
        {
            var employees = _mockRepo.Object.GetAll();
            Assert.That(employees.Count(), Is.EqualTo(1));
            Assert.That(employees.First().FirstName, Is.EqualTo("John"));
        }
    }
}
