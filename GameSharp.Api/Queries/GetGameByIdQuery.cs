using GameSharpApi.ViewModels;
using MediatR;
using System;

namespace GameSharpApi.Queries
{
    public class GetGameByIdQuery : IRequest<GameViewModel>
    {
        public GetGameByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
