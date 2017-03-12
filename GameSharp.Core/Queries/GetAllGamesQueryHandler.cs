using System.Linq;
using GameSharpApi.ViewModels;
using GameSharpApi.Queries;
using GameSharpBackend.Repositories;
using MediatR;
using System;
using System.Collections.Generic;

namespace GameSharpBackend.QueryHandlers
{
    public class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, IEnumerable<GameViewModel>>
    {
        private readonly IGameRepository GameInMemoryRepository;
        public GetAllGamesQueryHandler(IGameRepository gameInMemoryRepository)
        {
            this.GameInMemoryRepository = gameInMemoryRepository;
        }

        public IEnumerable<GameViewModel> Handle(GetAllGamesQuery qry)
        {
            var results = GameInMemoryRepository.GetAll().ToList();

            var list = results.Select(x => new GameViewModel{
                ID = x.ID,
                Name = x.Name,
                Description = x.Description,
                Publisher = x.Publisher,
                PublishDate = x.PublishDate
            }).ToList();

            return list;
        }
    }
}