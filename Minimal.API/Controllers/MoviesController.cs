using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minimal.Core.DTOs;
using Minimal.Core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minimal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateMovieAsync([FromBody] CreateMovieRequest createMovieRequest)
        {
            BaseResponseDto<bool> createResponse = await _mediator.Send(createMovieRequest);

            if (createResponse.Data)
            {
                return Created("....", null);
            }
            else
            {
                return BadRequest(createResponse.Errors);
            }
        }

        [HttpGet("kids")]
        public async Task<ActionResult<List<MovieDto>>> GetBestMoviesForKidsAsync()
        {
            BaseResponseDto<List<MovieDto>> getBestMoviesForKidsResponse = await _mediator.Send(new GetBestMoviesForKidsRequest());

            if (!getBestMoviesForKidsResponse.HasError)
            {
                return Ok(getBestMoviesForKidsResponse.Data);
            }
            else
            {
                return BadRequest(getBestMoviesForKidsResponse.Errors);
            }
        }
    }
}
