using System.Threading;
using System.Threading.Tasks;
using Application.Abstraction.Services;
using Application.Repositories.Movie;
using Application.Repositories.Order;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IMovieReadRepository _movieReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        private readonly ILoggerService _logger;

        public CreateOrderCommandHandler(IMovieReadRepository movieReadRepository, IOrderWriteRepository orderWriteRepository, UserManager<Domain.Entities.Identity.AppUser> userManager, ILoggerService logger)
        {
            _movieReadRepository = movieReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.CustomerId);
            if (user == null)
            {
                return new CreateOrderCommandResponse
                {
                    IsSuccess = false
                };
            }
    
            var movie = await _movieReadRepository.GetByIdAsync(request.MovieId);

            if (movie == null)
            {
                return new CreateOrderCommandResponse
                {
                    IsSuccess = false
                };
            }

            var order = new Domain.Entities.Order()
            {
                MovieId = movie.Id,
                CustomerId = user.Id,
                Price = movie.Price,
                HiringDateTime = DateTime.Now
            };

            await _orderWriteRepository.AddAsync(order);
            await _orderWriteRepository.SaveAsync();
            _logger.Write($"{request.CustomerId}'sine sahip usera, {request.MovieId}'sine sahip movie için order eklendi.");
            return new CreateOrderCommandResponse
            {
                IsSuccess = true
            };
        }

    }

}