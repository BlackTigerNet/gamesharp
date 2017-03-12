using System;
using GameSharpApi;
using GameSharpApi.Commands;
using GameSharpBackend.Repositories;
using MediatR;

namespace GameSharpBackend.CommandHandlers
{
    public class EditGameHandler : IRequestHandler<EditGameCmd>
    {
        private readonly IGameRepository GameInMemoryRepository;
        public EditGameHandler(IGameRepository gameInMemoryRepository)
        {
            this.GameInMemoryRepository = gameInMemoryRepository;
        }

        public void Handle(EditGameCmd cmd)
        {
            var game = GameInMemoryRepository.GetById(cmd.ID);
            game.Name = cmd.Name;
            game.Description = cmd.Description;
            game.Publisher = cmd.Publisher;
            game.PublishDate = cmd.PublishDate;
        }
    }
}