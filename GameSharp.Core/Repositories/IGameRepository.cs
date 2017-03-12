using GameSharpBackend.Models;
using System;
using System.Collections.Generic;

namespace GameSharpBackend.Repositories
{
    public interface IGameRepository
    {
       void Create(GameData game);
       GameData GetById(Guid id);
       IEnumerable<GameData> GetAll();
       void Remove(Guid id);

    }
}