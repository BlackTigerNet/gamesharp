using System;
using GameSharpApi;
using GameSharpApi.Commands;
using GameSharpBackend.Repositories;
using MediatR;

namespace GameSharpBackend.CommandHandlers
{
    public class EditGameHandler : IRequestHandler<EditGameCmd>
    {
        private readonly IGameRepository GameRepository;
        public EditGameHandler(IGameRepository gameRepository)
        {
            this.GameRepository = gameRepository;
        }

        public void Handle(EditGameCmd cmd)
        {
            var game = GameRepository.GetById(cmd.ID);
            game.Name = cmd.Name;
            game.Description = cmd.Description;
            game.Publisher = cmd.Publisher;
            game.PublishDate = cmd.PublishDate;

            GameRepository.Update(game);

        }
    }
}