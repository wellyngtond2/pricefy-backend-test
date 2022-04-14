using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PricefyChallenge.Api.Requests;
using PricefyChallenge.Api.Responses;
using PricefyChallenge.Core.Interfaces.Services;
using PricefyChallenge.Core.Shared.DataContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PricefyChallenge.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieServices _movieServices;
        private readonly IMapper _mapper;
        public MoviesController(IMovieServices movieServices, IMapper mapper)
        {
            _movieServices = movieServices;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<OperationResult<ICollection<MovieResponse>>>> Get(DateTime? CreateDate)
        {
            var movies = await _movieServices.GetAsync(CreateDate);

            if (!movies.Any())
            {
                return NoContent();
            }

            var response = _mapper.Map<ICollection<MovieResponse>>(movies);

            return Ok(OperationResult.Success(response));
        }
    }
}
