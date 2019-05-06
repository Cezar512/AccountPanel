using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using L2AccountPanel.Core.Domain;
using L2AccountPanel.Infrastructure.DTO;

namespace L2AccountPanel.Infrastructure.Services
{
    public interface IAccountService : IService
    {
         Task<AccountDTO> GetAsync(string username);
         Task<AccountDTO> GetAsync(Guid userId);
         Task<IEnumerable<AccountDTO>> GetAllAsync(string email);
         Task<IEnumerable<AccountDTO>> BrowseAsync();
         Task RegisterAsync(Guid userId, string email, string password, string username, string role);
         Task<IdentityToken> LoginAsync(string username, string password);
    }
}