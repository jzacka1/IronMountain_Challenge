using Iron_Mountain_Coding_Challenge.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronMountain.Tests.Tests.IntegrationTests
{
    [TestFixture]
    public class NlpIntegrationTests
    {
        [Test]
        public async Task PythonNlpService_Should_ParseQuery_Correctly()
        {
            var nlp = new NlpClient();

            dynamic filters = await nlp.ParseQuery("employees older than 40");

            Assert.That(40, Is.EqualTo((int)filters.AgeMin));
        }
    }
}
