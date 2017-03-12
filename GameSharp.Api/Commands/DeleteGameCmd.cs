using MediatR;
using System;

namespace GameSharpApi.Commands
{
    public class DeleteGameCmd : IRequest
    {
        public Guid ID { get; set; }
    }
}