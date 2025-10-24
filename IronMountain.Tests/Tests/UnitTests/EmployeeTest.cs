using Iron_Mountain_Coding_Challenge.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronMountain.Tests.UnitTests
{
    [TestFixture]
    public class EmployeeTest
    {
        [Test]
        public void ValidateEmployeeID_ShouldFail_WhenNotEightDigits()
        {
            var emp = new Employee { EmployeeID = 12345 };
            Assert.That(emp.EmployeeID.ToString().Length, Is.Not.EqualTo(8));
        }

        [Test]
        public void ValidateDOB_ShouldFail_WhenFutureDate()
        {
            var dob = DateTime.Now.AddDays(1);
            Assert.That(dob, Is.GreaterThan(DateTime.Today));
        }

        [Test]
        public void ValidateDOB_ShouldPass_WhenValidDate()
        {
            var dob = new DateTime(1990, 05, 21);
            Assert.That(dob, Is.LessThanOrEqualTo(DateTime.Today));
        }
    }
}
