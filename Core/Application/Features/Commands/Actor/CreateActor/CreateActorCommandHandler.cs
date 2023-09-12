using Application.Abstraction.Services;
using Application.Repositories.Actor;
using Application.Repositories.Movie;
using MediatR;
namespace Application.Features.Commands.Actor.CreateActor
{
    public class CreateActorCommandHandler : IRequestHandler<CreateActorCommandRequest, CreateActorCommandResponse>
    {
        private readonly IActorWriteRepository _actorWriteRepository;
        private readonly IMovieWriteRepository _movieWriteRepository;
        private readonly ILoggerService _logger;

        public CreateActorCommandHandler(IActorWriteRepository actorWriteRepository, IMovieWriteRepository movieWriteRepository, ILoggerService logger)
        {
            _actorWriteRepository = actorWriteRepository;
            _movieWriteRepository = movieWriteRepository;
            _logger = logger;
        }

        public async Task<CreateActorCommandResponse> Handle(CreateActorCommandRequest request, CancellationToken cancellationToken)
        {
            var movie = await _movieWriteRepository.Table.FindAsync(request.MovieId);
            if (movie == null)
            {
                return new CreateActorCommandResponse()
                {
                    IsSuccess = false
                };
            }

            var newActor = new Domain.Entities.Actor()
            {
                Name = request.Name,
                Surname = request.Surname,
                MovieId = request.MovieId
            };

            await _actorWriteRepository.AddAsync(newActor);
            await _actorWriteRepository.SaveAsync();
            _logger.Write($"{request.Name} adli actor eklendi");
            return new CreateActorCommandResponse()
            {
                IsSuccess = true
            };
        }

    }
}