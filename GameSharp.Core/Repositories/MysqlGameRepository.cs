using Dapper;
using GameSharpBackend.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using GameSharpBackend.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameSharp.Core.Repositories
{
    public class MysqlGameRepository : IGameRepository
    {
        private readonly String DbConnectionString = "";

        public void Create(GameData game)
        {
            using (IDbConnection conn = GetConnection())
            {
                conn.Execute(@"insert into game (id, name, description, publisher, publishDate) values (@ID, @Name, @Description, @Publisher, @PublishDate)", game);
            }
        }

        public void Update(GameData game)
        {
            using (IDbConnection conn = GetConnection())
            {
                conn.Execute(@"update game set name=@Name, description=@Description, publisher=@Publisher, publishDate=@PublishDate where id=@ID", game);
            }
        }

        public IEnumerable<GameData> GetAll()
        {
            using (IDbConnection conn = GetConnection())
            {
                return conn.Query<GameData>("select id, name, description, publisher, publishDate from Game");
            }
        }

        public GameData GetById(Guid id)
        {
            using (IDbConnection conn = GetConnection())
            {
                var results = conn.Query<GameData>("select id, name, description, publisher, publishDate from Game where id=@id", new { id = id} );
                return results.First();
            }
        }

        public void Remove(Guid id)
        {
            using (IDbConnection conn = GetConnection())
            {
                conn.Execute("delete from game where id=@id", new { id = id });
            }
        }


        private IDbConnection GetConnection()
        {
            return new MySqlConnection()
            {
                ConnectionString = DbConnectionString
            };
        }

    }
}
