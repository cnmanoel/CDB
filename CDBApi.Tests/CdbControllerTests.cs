using Xunit;
using Moq;
using System.Web.Http;
using System.Web.Http.Results;
using CDBApi.Controllers;
using CDBApi.Models;
using CDBApi.Services;

namespace CDBApi.Tests
{
    public class CdbControllerTests
    {
        private readonly Mock<ICdbCalculator> _mockCalculator;
        private readonly CdbController _controller;

        public CdbControllerTests()
        {
            _mockCalculator = new Mock<ICdbCalculator>();
            _controller = new CdbController(_mockCalculator.Object);
        }

        [Fact]
        public void Calculate_ShouldReturnBadRequest_ForInvalidInput()
        {
            var request = new InvestmentRequest { InitialValue = -1000, Months = 12 };
            var result = _controller.Calculate(request);
            Assert.IsType<BadRequestErrorMessageResult>(result);
        }

        [Fact]
        public void Calculate_ShouldReturnCorrectValues_ForValidInput()
        {
            var request = new InvestmentRequest { InitialValue = 1000, Months = 6 };
            _mockCalculator.Setup(c => c.CalculateGrossValue(It.IsAny<decimal>(), It.IsAny<int>())).Returns(1059.76m);
            _mockCalculator.Setup(c => c.CalculateNetValue(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<int>())).Returns(1046.31m);

            var result = _controller.Calculate(request) as OkNegotiatedContentResult<InvestmentResult>;

            Assert.NotNull(result);
            Assert.Equal(1059.76m, result.Content.GrossValue);
            Assert.Equal(1046.31m, result.Content.NetValue);
        }
    }
}