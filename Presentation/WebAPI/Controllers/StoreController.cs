using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.Actor;
using Application.Features.Commands.Actor.DeleteActor;
using Application.Features.Commands.Actor.UpdateActor;
using Application.Features.Commands.Director.CreateDirector;
using Application.Features.Commands.Director.DeleteDirector;
using Application.Features.Commands.Director.UpdateDirector;
using Application.Features.Commands.Movie.CreateMovie;
using Application.Features.Commands.Movie.DeleteMovie;
using Application.Features.Queries.Actor.GetAllActor;
using Application.Features.Queries.Director.GetAllDirector;
using Application.Features.Queries.Movie.GetAllMovie;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoreController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        //Oyuncu Endpointleri

        [HttpGet]
        public async Task<IActionResult> GetAllActor()
        {
            var query = new GetAllActorQueryRequest();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> CreateActor(CreateActorCommandRequest createActorCommandRequest)
        {
            return Ok(await _mediator.Send(createActorCommandRequest));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateActor(UpdateActorCommandRequest updateActorCommandRequest)
        {
            return Ok(await _mediator.Send(updateActorCommandRequest));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteActor([FromRoute]DeleteActorCommandRequest deleteActorCommandRequest)
        {
            return Ok(await _mediator.Send(deleteActorCommandRequest));
        }
        
        //Yonetmen Endpointleri
        
        [HttpGet]
        public async Task<IActionResult> GetAllDirector()
        {
            var query = new GetAllDirectorQueriesRequest();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDirector(CreateDirectorCommandRequest createDirectorCommandRequest)
        {
            return Ok(await _mediator.Send(createDirectorCommandRequest));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDirector(UpdateDirectorCommandRequest updateDirectorCommandRequest)
        {
            return Ok(await _mediator.Send(updateDirectorCommandRequest));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteDirector([FromRoute]DeleteDirectorCommandRequest deleteDirectorCommandRequest)
        {
            return Ok(await _mediator.Send(deleteDirectorCommandRequest));
        }
        
        //Film Endpointleri

        [HttpGet]
        public async Task<IActionResult> GetAllMovie()
        {
            var query = new GetAllMovieQueryRequest();
            return Ok(await _mediator.Send(query));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieCommandRequest createMovieCommandRequest)
        {
           return Ok(await _mediator.Send(createMovieCommandRequest));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteMovie([FromRoute]DeleteMovieCommandsRequest deleteMovieCommandsRequest)
        {
            return Ok(await _mediator.Send(deleteMovieCommandsRequest));
        }
    }
}
