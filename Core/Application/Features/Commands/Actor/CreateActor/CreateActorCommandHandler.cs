using Application.Repositories.Actor;
using Application.Repositories.Movie;
using MediatR;
namespace Application.Features.Commands.Actor.CreateActor
{
    public class CreateActorCommandHandler : IRequestHandler<CreateActorCommandRequest, CreateActorCommandResponse>
    {
        private readonly IActorWriteRepository _actorWriteRepository;
        private readonly IMovieWriteRepository _movieWriteRepository;

        public CreateActorCommandHandler(IActorWriteRepository actorWriteRepository, IMovieWriteRepository movieWriteRepository)
        {
            _actorWriteRepository = actorWriteRepository;
            _movieWriteRepository = movieWriteRepository;
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

            return new CreateActorCommandResponse()
            {
                IsSuccess = true
            };
        }

    }
}