using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaySpace.Api.Dto;
using PaySpaceApplication.Services;
using System.Threading.Tasks;

namespace PaySpace.Api.Controllers
{
    [Route("api/[controller]")]
    public class CalcController : ControllerBase
    {
        private readonly ICalcServices calcServices;

        public CalcController(ICalcServices calcServices)
        {
            this.calcServices = calcServices;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostCalc([FromBody] CalcRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var calcDto = await this.calcServices.Calc(request.PostalCode.ToUpper(), request.Income);

            if (calcDto == null)
            {
                return NotFound();
            }

            return Created(nameof(PostCalc), calcDto);
        }
    }
}
