using System.Threading;
using System.Threading.Tasks;
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

        public CreateOrderCommandHandler(IMovieReadRepository movieReadRepository, IOrderWriteRepository orderWriteRepository, UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            _movieReadRepository = movieReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _userManager = userManager;
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
                Price = movie.Price
            };

            await _orderWriteRepository.AddAsync(order);
            await _orderWriteRepository.SaveAsync();

            return new CreateOrderCommandResponse
            {
                IsSuccess = true
            };
        }

    }

}