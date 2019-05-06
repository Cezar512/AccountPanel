using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using L2AccountPanel.Core.Domain;
using L2AccountPanel.Core.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace L2AccountPanel.Infrastructure.Repositories
{
    public class MongoCharacterRepository : ICharacterRepository, IMongoRepository
    {
        private readonly IMongoDatabase _database;

        public MongoCharacterRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(Character character)
            =>await Characters.InsertOneAsync(character);

        public async Task<IEnumerable<Character>> GetAllAsync()
            => await Characters.AsQueryable().ToListAsync();

        public async Task<IEnumerable<Character>> GetAllAsync(int server)
            => await Characters.Find(x=>x.Server==server).ToListAsync();
        public async Task<Character> GetCharacterAsync(Guid id)
            =>await Characters.AsQueryable().FirstOrDefaultAsync(x => x.UserId == id);
        public async Task<IEnumerable<Character>> GetAllCharactersForAccountIdAsync(Guid id)
            => await Characters.Find(x=>x.UserId == id).ToListAsync();
        public async Task<IEnumerable<Character>> GetAllCharacterForAccountIdAndServerAsync(Guid id, int server)
        {
            var filter = Builders<Character>.Filter.Eq(x=>x.UserId, id) &
                        Builders<Character>.Filter.Eq(x=>x.Server, server);

            return await Characters.Find(filter).ToListAsync();
        }
        public async Task<Character> GetAsync(string name, int server)
        {
            var filter = Builders<Character>.Filter.Eq(x=>x.Server ,server) &
                        Builders<Character>.Filter.Eq(x=>x.Name ,name);

            return await Characters.Find(filter).FirstOrDefaultAsync();            
        }
        public async Task RemoveAsync(Character character)
        {
            var filter = Builders<Character>.Filter.Eq(x=>x.UserId ,character.UserId) & 
                        Builders<Character>.Filter.Eq(x=>x.Server ,character.Server) &
                        Builders<Character>.Filter.Eq(x=>x.Name ,character.Name);
            await Characters.DeleteOneAsync(filter);
        }

        public async Task UpdateAsync(Character character)
        {
            var filter = Builders<Character>.Filter.Eq(x=>x.UserId ,character.UserId) & 
                        Builders<Character>.Filter.Eq(x=>x.Server ,character.Server) &
                        Builders<Character>.Filter.Eq(x=>x.Name ,character.Name);
            await Characters.FindOneAndReplaceAsync(filter,character);
        }

        private IMongoCollection<Character> Characters => _database.GetCollection<Character>("Characters");
    }
}