using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using  Moq;

using Klarna;
using Klarna.Requests;
using Klarna.Responses;

namespace Klarna.Tests
{
    [TestClass]
    public class OrderManagementTests
    {
        private readonly Mock<KlarnaClient> _cut;   // class under test
        private Mock<IKlarnaSession> _klarnaSessionMock = new Mock<IKlarnaSession>();

        public OrderManagementTests()
        {
            _klarnaSessionMock.SetupGet(p => p.Credentials).Returns(new KlarnaCredentials { Username = "", Password = "" });
            _klarnaSessionMock.SetupGet(p => p.BaseUrl).Returns("https://api.playground.klarna.com/");

            _cut = new Mock<KlarnaClient>(_klarnaSessionMock.Object);
        }

        [TestMethod]
        public void Klarna_AcknowledgeOrder_Returns_Success()
        {
            // Arrange
            AcknowledgeOrderResponse response = new AcknowledgeOrderResponse
            {
                StatusCode = 201
            };

            _cut.Setup(x => x.AcknowledgeOrder(It.IsAny<string>())).Returns(response);

            // Act
            var res = _cut.Object.AcknowledgeOrder("");

            // Assert
            Assert.AreEqual(res.StatusCode, response.StatusCode);
        }

        [TestMethod]
        public async Task Klarna_AcknowledgeOrderAsync_Returns_Success()
        {
            // Arrange
            AcknowledgeOrderResponse response = new AcknowledgeOrderResponse
            {
                StatusCode = 201
            };

            _cut.Setup(x => x.AcknowledgeOrderAsync(It.IsAny<string>())).ReturnsAsync(response);

            // Act
            var res = await _cut.Object.AcknowledgeOrderAsync("");

            // Assert
            Assert.AreEqual(res.StatusCode, response.StatusCode);
        }

        [TestMethod]
        public void Klarna_CreateCaptureOrder_Returns_Success()
        {
            // Arrange
            var req = new Mock<ICreateCaptureOrderRequest>();

            CreateCaptureOrderResponse response = new CreateCaptureOrderResponse
            {
                StatusCode = 200
            };

            _cut.Setup(x => x.CreateCaptureOrder(It.IsAny<ICreateCaptureOrderRequest>())).Returns(response);

            // Act
            var res = _cut.Object.CreateCaptureOrder(req.Object);

            // Assert
            Assert.AreEqual(res.StatusCode, response.StatusCode);
        }

        [TestMethod]
        public async Task Klarna_CreateCaptureOrderAsync_Returns_Success()
        {
            // Arrange
            var req = new Mock<ICreateCaptureOrderRequest>();

            CreateCaptureOrderResponse response = new CreateCaptureOrderResponse
            {
                StatusCode = 200
            };

            _cut.Setup(x => x.CreateCaptureOrderAsync(It.IsAny<ICreateCaptureOrderRequest>())).ReturnsAsync(response);

            // Act
            var res = await _cut.Object.CreateCaptureOrderAsync(req.Object);

            // Assert
            Assert.AreEqual(res.StatusCode, response.StatusCode);
        }
    }
}
