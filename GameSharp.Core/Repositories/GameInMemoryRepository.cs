using GameSharpBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace GameSharpBackend.Repositories
{
    public class GameInMemoryRepository : IGameRepository
    {
        private readonly List<GameData> games = new List<GameData>{
                new GameData
                {
                ID = Guid.NewGuid(),
                Name = "Uncharted 4",
                Description = @"Several years after his last adventure, retired fortune hunter, 
                Nathan Drake, is forced back into the world of thieves.",
                Publisher = "Naughty Dog",
                PublishDate = DateTime.UtcNow
                }, new GameData
                {
                ID = Guid.NewGuid(),
                Name = "Rise of the Tomb Raider",
                Description = @"In Rise of the Tomb Raider, Lara Croft becomes more than a
                 survivor as she embarks on her first Tomb Raiding expedition to the most treacherous and remote regions of Siberia.",
                Publisher = "Crystal Dynamics",
                PublishDate = DateTime.UtcNow
                }
        };

        public GameInMemoryRepository()
        {
            Console.WriteLine("Creating game repository!!!!!!");
        }

        public void Create(GameData game) 
        {
            games.Add(game);
        }

        public GameData GetById(Guid id)
        {
            return games.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<GameData> GetAll()
        {
            return games;
        }

        public void Remove(Guid id)
        {
            var game = games.FirstOrDefault(x => x.ID == id);

            if (game != null)
            {
                games.Remove(game);
            }
        }
    }
}