using Xunit;
using CDBApi.Services;

namespace CDBApi.Tests
{
    public class CdbCalculatorTests
    {
        private readonly CdbCalculator _calculator;

        public CdbCalculatorTests()
        {
            _calculator = new CdbCalculator();
        }

        [Theory]
        [InlineData(1000, 6, 1059.76)]
        [InlineData(1500, 12, 1684.62)]
        [InlineData(2000, 13, 2268.00)]
        public void CalculateGrossValue_ShouldReturnCorrectValues(decimal initialValue, int months, decimal expectedGrossValue)
        {
            var result = _calculator.CalculateGrossValue(initialValue, months);
            Assert.Equal(expectedGrossValue, result);
        }

        [Theory]
        [InlineData(1059.76, 1000, 6, 1046.31)]
        [InlineData(1684.62, 1500, 12, 1647.70)]
        [InlineData(2268.00, 2000, 13, 2221.10)]
        public void CalculateNetValue_ShouldReturnCorrectValues(decimal grossValue, decimal initialValue, int months, decimal expectedNetValue)
        {
            var result = _calculator.CalculateNetValue(grossValue, initialValue, months);
            Assert.Equal(expectedNetValue, result);
        }
    }
}