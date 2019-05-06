using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using L2AccountPanel.Core.Domain;

namespace L2AccountPanel.Core.Repositories
{
    public interface ICharacterRepository : IRepository
    {
        Task<Character> GetCharacterAsync(Guid id);
        Task<Character> GetAsync(string name, int server);
        Task<IEnumerable<Character>> GetAllAsync();
        Task<IEnumerable<Character>> GetAllAsync(int server);
        Task<IEnumerable<Character>> GetAllCharactersForAccountIdAsync(Guid id);
        Task<IEnumerable<Character>> GetAllCharacterForAccountIdAndServerAsync(Guid id, int server);
        Task AddAsync(Character character);
        Task UpdateAsync(Character character);
        Task RemoveAsync(Character character);         
    }
}