using System.Threading.Tasks;

namespace L2AccountPanel.Infrastructure.Services
{
    public interface ITokenManager
    {
         Task<bool> IsCurrentTokenActive();
         Task DeactivateCurrentTokenAsync();
         Task<bool> IsTokenActive(string token);
         Task DeactivateTokenAsync(string token);
    }
}