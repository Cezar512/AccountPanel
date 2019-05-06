using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using L2AccountPanel.Core.Domain;
using L2AccountPanel.Core.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace L2AccountPanel.Infrastructure.Repositories
{
    public class MongoAccountRepository : IAccountRepository, IMongoRepository
    {
        private readonly IMongoDatabase _database;


        public MongoAccountRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(Account account)
            =>await Accounts.InsertOneAsync(account);

        public async Task<IEnumerable<Account>> GetAllAsync()
            => await Accounts.AsQueryable().ToListAsync();

        public async Task<Account> GetAsync(Guid id)
            =>await Accounts.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
        public async Task<Account> GetAsync(string username)
            =>await Accounts.AsQueryable().FirstOrDefaultAsync(x => x.Username == username);

        public async Task<IEnumerable<Account>> GetAllAsync(string email)
            =>await Accounts.Find(x=>x.Email==email).ToListAsync();

        public async Task RemoveAsync(Guid id)
            =>await Accounts.DeleteOneAsync(x=>x.Id==id);

        public async Task UpdateAsync(Account account)
            =>await Accounts.ReplaceOneAsync(x=>x.Id == account.Id, account);

        private IMongoCollection<Account> Accounts => _database.GetCollection<Account>("Accounts");
    }
}