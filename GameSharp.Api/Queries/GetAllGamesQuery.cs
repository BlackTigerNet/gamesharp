using GameSharpApi.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace GameSharpApi.Queries
{
    public class GetAllGamesQuery : IRequest<IEnumerable<GameViewModel>>
    {
    }
}