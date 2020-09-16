using System.Threading.Tasks;
using Api.Queries.Primes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PrimesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PrimesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Checks if a give number is prime and returns the next prime
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Response object of specific type containing errors or data properties</returns>
        /// <response code="200">Returns Response object of type GetPrimeResponse containing Data object</response>
        /// <response code="400">Returns Response object of type GetPrimeResponse containing error message</response>
        /// <remarks>
        /// Sample request:
        ///     GET /api/v1/primes/1
        /// </remarks>
        [HttpGet("{number}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Res<GetPrimeResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Res<GetPrimeResponse>))]
        public async Task<IActionResult> Get([FromRoute] int number)
        {
            var result = await _mediator.Send(new GetPrimeQuery() { Number = number });

            if (result.WasSuccessful)
                return Ok(Res.Data(result.Value));
            else
                return BadRequest(Res.Error<GetPrimeResponse>(string.Join(", ", result.Errors)));
        }
    }
}
