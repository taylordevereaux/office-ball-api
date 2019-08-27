using System.Collections.Generic;
using MongoDB.Driver;
using OfficeBall.Api.Models;

namespace OfficeBall.Api.Database
{
    public class PlayerService
    {
        private readonly IMongoCollection<Player> _players;

        public PlayerService(IOfficeBallDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _players = database.GetCollection<Player>(settings.PlayersCollectionName);
        }

        public List<Player> Get() =>
            _players.Find(book => true).ToList();
        public Player Get(string id) =>
            _players.Find<Player>(book => book.Id == id).FirstOrDefault();
        public Player Create(Player book)
        {
            _players.InsertOne(book);
            return book;
        }
        public void Update(string id, Player bookIn) =>
            _players.ReplaceOne(book => book.Id == id, bookIn);
        public void Remove(Player bookIn) =>
            _players.DeleteOne(book => book.Id == bookIn.Id);
        public void Remove(string id) =>
            _players.DeleteOne(book => book.Id == id);
    }
}