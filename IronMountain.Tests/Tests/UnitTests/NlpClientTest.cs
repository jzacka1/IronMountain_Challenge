using Iron_Mountain_Coding_Challenge.Services;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IronMountain.Tests.Tests.UnitTests
{
    [TestFixture]
    public class NlpClientTest
    {
        [Test]
        public async Task ParseQuery_Should_Return_Parsed_Values()
        {
            string fakeResponse = @"{ ""filters"": { ""AgeMin"": 50 } }";

            var handler = new Mock<HttpMessageHandler>();
            handler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent(fakeResponse)
                });

            var client = new HttpClient(handler.Object);
            var nlp = new NlpClient(client);

            dynamic filters = await nlp.ParseQuery("Show employees older than 50");

            Assert.That(50, Is.EqualTo((int)filters.AgeMin));
        }
    }
}
