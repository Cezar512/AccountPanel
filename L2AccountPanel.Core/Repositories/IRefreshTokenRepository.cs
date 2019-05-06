using System.Threading.Tasks;
using L2AccountPanel.Core.Domain;

namespace L2AccountPanel.Core.Repositories
{
    public interface IRefreshTokenRepository : IRepository
    {
         Task<RefreshToken> GetAsync(string token);
         Task CreateAsync(RefreshToken token);
         Task UpdateAsycn(RefreshToken token);
    }
}