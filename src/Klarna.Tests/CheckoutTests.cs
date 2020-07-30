using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using Klarna;
using Klarna.Requests;
using Klarna.Responses;

namespace Klarna.Tests
{
    [TestClass]
    public class CheckoutTests
    {
        private readonly Mock<KlarnaClient> _cut;   // class under test
        private Mock<IKlarnaSession> _klarnaSessionMock = new Mock<IKlarnaSession>();

        public CheckoutTests()
        {
            _klarnaSessionMock.SetupGet(p => p.Credentials).Returns(new KlarnaCredentials { Username = "", Password = "" });
            _klarnaSessionMock.SetupGet(p => p.BaseUrl).Returns("https://api.playground.klarna.com/");

            _cut = new Mock<KlarnaClient>(_klarnaSessionMock.Object);
        }

        [TestMethod]
        public void Klarna_CreateCheckoutOrder_Returns_Success()
        {
            // Arrange
            var req = new Mock<ICheckoutOrderRequest>();

            CheckoutOrderResponse response = new CheckoutOrderResponse
            {
                StatusCode = 200
            };

            _cut.Setup(x => x.CreateCheckoutOrder(It.IsAny<ICheckoutOrderRequest>())).Returns(response);

            // Act
            var res = _cut.Object.CreateCheckoutOrder(req.Object);

            // Assert
            Assert.AreEqual(res.StatusCode, response.StatusCode);
        }

        [TestMethod]
        public async Task Klarna_CreateCheckoutOrderAsync_Returns_Success()
        {
            // Arrange
            var req = new Mock<ICheckoutOrderRequest>();

            CheckoutOrderResponse response = new CheckoutOrderResponse
            {
                StatusCode = 200
            };

            _cut.Setup(x => x.CreateCheckoutOrderAsync(It.IsAny<ICheckoutOrderRequest>())).ReturnsAsync(response);

            // Act
            var res = await _cut.Object.CreateCheckoutOrderAsync(req.Object);

            // Assert
            Assert.AreEqual(res.StatusCode, response.StatusCode);
        }

        [TestMethod]
        public void Klarna_GetCheckoutOrder_Returns_Success()
        {
            // Arrange
            CheckoutOrderResponse response = new CheckoutOrderResponse
            {
                StatusCode = 200
            };


            _cut.Setup(x => x.GetCheckoutOrder(It.IsAny<string>())).Returns(response);

            // Act
            var res = _cut.Object.GetCheckoutOrder("");

            // Assert
            Assert.AreEqual(res.StatusCode, response.StatusCode);
        }

        [TestMethod]
        public async Task Klarna_GetCheckoutOrderAsync_Returns_Success()
        {
            // Arrange
            CheckoutOrderResponse response = new CheckoutOrderResponse
            {
                StatusCode = 200
            };


            _cut.Setup(x => x.GetCheckoutOrderAsync(It.IsAny<string>())).ReturnsAsync(response);

            // Act
            var res = await _cut.Object.GetCheckoutOrderAsync("");

            // Assert
            Assert.AreEqual(res.StatusCode, response.StatusCode);
        }
    }
}
