using Application.Abstraction.Services;
using Application.Repositories.Director;
using Application.Repositories.Movie;
using MediatR;

namespace Application.Features.Commands.Movie.CreateMovie
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommandRequest, CreateMovieCommandResponse>
    {
        private readonly IMovieWriteRepository _movieWriteRepository;
        private readonly ILoggerService _loggerService;

        public CreateMovieCommandHandler(IMovieWriteRepository movieWriteRepository, ILoggerService loggerService)
        {
            _movieWriteRepository = movieWriteRepository;
            _loggerService = loggerService;
        }

        public async Task<CreateMovieCommandResponse> Handle(CreateMovieCommandRequest request, CancellationToken cancellationToken)
        {
            var newMovie = new Domain.Entities.Movie
            {
                Name = request.Name,
                Year = request.Year,
                Type = request.Type,
                Status = request.Status,
                Price = request.Price,
                DirectorId = request.DirectorId
            };
            await _movieWriteRepository.AddAsync(newMovie);
            await _movieWriteRepository.SaveAsync();
            _loggerService.Write($"{request.Name} adli movie eklendi");
            return new CreateMovieCommandResponse
            {
                IsSuccess = true
            };
        }

        
    }
}