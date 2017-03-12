using GameSharpApi;
using GameSharpApi.Commands;
using GameSharpBackend.Repositories;
using MediatR;

namespace GameSharpBackend.CommandHandlers
{
    public class DeleteGameHandler : IRequestHandler<DeleteGameCmd>
    {
        private readonly IGameRepository GameInMemoryRepository;

        public DeleteGameHandler(IGameRepository gameInMemoryRepository)
        {
            this.GameInMemoryRepository = gameInMemoryRepository;
        }

        public void Handle(DeleteGameCmd cmd)
        {
            GameInMemoryRepository.Remove(cmd.ID);
        }
    }
}
