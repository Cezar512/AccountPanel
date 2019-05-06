using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using L2AccountPanel.Infrastructure.DTO;

namespace L2AccountPanel.Infrastructure.Services
{
    public interface ICharacterService : IService
    {
        
        Task AddAsync(Guid userId,string name, int server);
        Task <IEnumerable<CharacterDTO>> GetAllAsync();
        Task<IEnumerable<CharacterDTO>> GetAllAsync(int server);
        Task<IEnumerable<CharacterDTO>> GetAllCharactersForAccountIdAsync(Guid userId);
        Task<IEnumerable<CharacterDTO>> GetAllCharacterForAccountIdAndServerAsync(Guid userId, int server);
        Task<CharacterDTO> GetAsync(Guid id);
        Task<CharacterDTO> GetAsync(string name, int server);
        Task DeleteAsync(string name, int server);
    }
}