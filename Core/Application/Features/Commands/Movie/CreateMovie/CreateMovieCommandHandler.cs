using Application.Repositories.Director;
using Application.Repositories.Movie;
using MediatR;

namespace Application.Features.Commands.Movie.CreateMovie
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommandRequest, CreateMovieCommandResponse>
    {
        private readonly IMovieWriteRepository _movieWriteRepository;
        private readonly IDirectorWriteRepository _directorWriteRepository;

        public CreateMovieCommandHandler(IMovieWriteRepository movieWriteRepository, IDirectorWriteRepository directorWriteRepository)
        {
            _movieWriteRepository = movieWriteRepository;
            _directorWriteRepository = directorWriteRepository;
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

            return new CreateMovieCommandResponse
            {
                IsSuccess = true
            };
        }

        
    }
}