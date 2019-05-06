using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using L2AccountPanel.Core.Domain;

namespace L2AccountPanel.Core.Repositories
{
    public interface IAccountRepository : IRepository
    {
        Task<Account> GetAsync(Guid id);
        Task<Account> GetAsync(string username);
        Task<IEnumerable<Account>> GetAllAsync(string email);
        Task<IEnumerable<Account>> GetAllAsync();
        Task AddAsync(Account account);
        Task UpdateAsync(Account account);
        Task RemoveAsync(Guid id);
    }
}