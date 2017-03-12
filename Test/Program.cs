using GameSharp.Core.Repositories;
using GameSharpBackend.Models;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            MysqlGameRepository repo = new MysqlGameRepository();

            Console.WriteLine("Listing all games");
            foreach (var game in repo.GetAll())
            {
                Console.WriteLine($"{game.ID} {game.Name} {game.Description} {game.PublishDate}");
            }

            Console.WriteLine();

            var g = new GameData()
            {
                ID = Guid.NewGuid(),
                Name = "Pacman",
                Publisher = "Foo",
                Description = "Some description",
                PublishDate = DateTime.Now
            };
            Console.WriteLine($"Creating new game with id: {g.ID}");
            repo.Create(g);

            Console.WriteLine();

            Console.WriteLine("Listing all games");
            foreach (var game in repo.GetAll())
            {
                Console.WriteLine($"{game.ID} {game.Name} {game.Description} {game.PublishDate}");
            }

            var selectedGame = repo.GetById(g.ID);

            selectedGame.Name = "updated";
            repo.Update(selectedGame);

            Console.WriteLine();
            Console.WriteLine("Selected game details");
            Console.WriteLine($"{selectedGame.ID} {selectedGame.Name} {selectedGame.Description} {selectedGame.PublishDate}");

            Console.WriteLine();
            Console.WriteLine($"Removing game with id: ${g.ID}");
            repo.Remove(g.ID);

            Console.WriteLine();
            Console.WriteLine("Listing all games");
            foreach (var game in repo.GetAll())
            {
                Console.WriteLine($"{game.ID} {game.Name} {game.Description} {game.PublishDate}");
            }

            Console.ReadLine();
        }
    }
}