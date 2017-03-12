using GameSharpApi;
using GameSharpApi.Commands;
using GameSharpBackend.Repositories;
using MediatR;

namespace GameSharpBackend.CommandHandlers
{
    public class DeleteGameHandler : IRequestHandler<DeleteGameCmd>
    {
        private readonly IGameRepository GameRepository;

        public DeleteGameHandler(IGameRepository gameRepository)
        {
            this.GameRepository = gameRepository;
        }

        public void Handle(DeleteGameCmd cmd)
        {
            GameRepository.Remove(cmd.ID);
        }
    }
}
