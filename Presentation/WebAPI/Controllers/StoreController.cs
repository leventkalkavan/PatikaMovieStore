using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.Actor;
using Application.Features.Commands.Actor.DeleteActor;
using Application.Features.Commands.Actor.UpdateActor;
using Application.Features.Queries.Actor.GetAllActor;
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

        [HttpGet]
        public async Task<IActionResult> GetAllActor()
        {
            var query = new GetAllActorQueryRequest();
            var result = await _mediator.Send(query);
            return Ok(result);
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
    }
}
