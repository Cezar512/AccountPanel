using System.Threading.Tasks;
using L2AccountPanel.Core.Domain;
using L2AccountPanel.Core.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace L2AccountPanel.Infrastructure.Repositories
{
    public class MongoRefreshTokenRepository : IRefreshTokenRepository, IMongoRepository
    {
        private readonly IMongoDatabase _database;

        public MongoRefreshTokenRepository(IMongoDatabase database)
        {
            _database = database;
        }
        public async Task CreateAsync(RefreshToken token)
            =>await RefreshTokens.InsertOneAsync(token);

        public async Task<RefreshToken> GetAsync(string token)
            =>await RefreshTokens.AsQueryable().FirstOrDefaultAsync(x=>x.Token == token);

        public async Task UpdateAsycn(RefreshToken token)
            =>await RefreshTokens.ReplaceOneAsync(x=>x.Id==token.Id, token);

        private IMongoCollection<RefreshToken> RefreshTokens => _database.GetCollection<RefreshToken>("RefreshTokens");
    }
}