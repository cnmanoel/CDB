using System.Web.Http;
using CDBApi.Models;
using CDBApi.Services;

namespace CDBApi.Controllers
{
    [RoutePrefix("api/cdb")]
    public class CdbController : ApiController
    {
        private readonly ICdbCalculator _calculator;

        public CdbController(ICdbCalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpPost]
        [Route("calculate")]
        public IHttpActionResult Calculate([FromBody] InvestmentRequest request)
        {
            if (request.InitialValue <= 0 || request.Months <= 1)
            {
                return BadRequest("Invalid input values.");
            }

            var grossValue = _calculator.CalculateGrossValue(request.InitialValue, request.Months);
            var netValue = _calculator.CalculateNetValue(grossValue, request.InitialValue, request.Months);

            return Ok(new InvestmentResult
            {
                GrossValue = grossValue,
                NetValue = netValue
            });
        }
    }
}