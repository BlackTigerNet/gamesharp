using GameSharpApi.Queries;
using GameSharpApi.ViewModels;
using GameSharpBackend.Models;
using GameSharpBackend.Repositories;
using MediatR;
using System;
using System.Linq;

namespace GameSharpBackend.Queries
{
    public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, GameViewModel>
    {
        private readonly IGameRepository GameInMemoryRepository;

        public GetGameByIdQueryHandler(IGameRepository gameInMemoryRepository)
        {
            this.GameInMemoryRepository = gameInMemoryRepository;
        }

        public GameViewModel Handle(GetGameByIdQuery query)
        {
            GameData game = GameInMemoryRepository.GetAll().ToList().Where(x => x.ID == query.Id).FirstOrDefault();

            if (game == null)
            {
                return null;
            }

            GameViewModel gameViewModel = new GameViewModel();
            gameViewModel.ID = game.ID;
            gameViewModel.Name = game.Name;
            gameViewModel.Description = game.Description;
            gameViewModel.Publisher = game.Publisher;
            gameViewModel.PublishDate = game.PublishDate;

            return gameViewModel;
        }
    }
}
