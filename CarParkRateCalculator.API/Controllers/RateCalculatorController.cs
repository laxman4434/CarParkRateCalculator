using System;
using System.Threading.Tasks;
using CarParkRateCalculator.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarParkRateCalculator.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CarParkRateCalculator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RateCalculatorController : ControllerBase
    {
        private readonly ILogger<RateCalculatorController> _logger;
        private readonly ISetRateType _setRateType;

        public RateCalculatorController(ILogger<RateCalculatorController> logger, ISetRateType setRateType)
        {
            _logger = logger;
            _setRateType = setRateType;
        }

        /// <summary>
        /// Calculate the car park rate based on the entry and exit time
        /// </summary>
        /// <param name="rateRequest"></param>
        /// <returns></returns>
        [HttpGet]
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public IActionResult Get([FromQuery]RateRequest rateRequest)
        {
            try
            {
                if (rateRequest == null)
                {
                    //ModelState.AddModelError("", "Entry time & exit time cannot be empty");
                    return BadRequest("Missing input parameters. Entry time and Exit time");
                }

                if (rateRequest.EntryDateTime == DateTime.MinValue || rateRequest.ExitDateTime == DateTime.MinValue)
                {
                    _logger.LogInformation($"Not valid times. Entry Time = {rateRequest.EntryDateTime} & Exit Time = {rateRequest.ExitDateTime}");
                    //ModelState.AddModelError("","Invalid dates");
                    return BadRequest("Invalid dates");
                }

                //if (rateRequest.EntryDateTime >= DateTime.Now)
                //{
                //    _logger.LogInformation($" Entry Time  {rateRequest.EntryDateTime} cannot be greater than current time  {DateTime.Now}");
                //    //ModelState.AddModelError("EntryDateTime", "Entry Time cannot be greater than Exit Time");
                //    return BadRequest("Car Park Entry Time cannot be greater than current time");
                //}

                if (rateRequest.EntryDateTime >= rateRequest.ExitDateTime)
                {
                    _logger.LogInformation($" Entry Time  {rateRequest.EntryDateTime} cannot be greater than Exit Time  {rateRequest.ExitDateTime}");
                    //ModelState.AddModelError("EntryDateTime", "Entry Time cannot be greater than Exit Time");
                    return BadRequest("Car Park Entry Time cannot be greater than Exit Time");
                }

                var result = _setRateType.RateCalculation(rateRequest.EntryDateTime, rateRequest.ExitDateTime);

                return Ok(result); ;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while calculating the rate", rateRequest);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving the calculations");
            }
        }


    }
}
