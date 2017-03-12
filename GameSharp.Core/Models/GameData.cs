using System;

namespace GameSharpBackend.Models
{
    public class GameData
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
    }
}