using System;

namespace GameSharpApi.ViewModels
{
    public class GameViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
    }
}