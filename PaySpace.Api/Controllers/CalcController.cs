using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaySpace.Domain.Model;
using PaySpaceApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Calc))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCalc(string postalCode, decimal income)
        {
            var calcDto = await this.calcServices.Calc(postalCode, income);

            if (calcDto == null)
            {
                return NotFound();
            }                

            return Ok(calcDto);
        }
    }
}
