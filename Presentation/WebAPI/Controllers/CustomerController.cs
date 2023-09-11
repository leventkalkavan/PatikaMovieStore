using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.AppUser.Login;
using Application.Features.Commands.Order.CreateOrder;
using Application.Features.Commands.Order.DeleteOrder;
using Application.Features.Queries.Order.GetAllOrder;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest loginCommandRequest)
        {
            return Ok(await _mediator.Send(loginCommandRequest));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            var query = new GetAllOrderQueryRequest();
            return Ok(await _mediator.Send(query));
        }

        [Authorize(AuthenticationSchemes = "user")]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest createOrderCommandRequest)
        {
            return Ok(await _mediator.Send(createOrderCommandRequest));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] DeleteOrderCommandRequest deleteOrderCommandRequest)
        {
            return Ok(await _mediator.Send(deleteOrderCommandRequest));
        }
    }
}
