using MediatR;
using System;

namespace GameSharpApi.Commands
{
    public class EditGameCmd : IRequest
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
    }
}