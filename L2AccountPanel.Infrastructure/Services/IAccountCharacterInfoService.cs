using System;
using System.Threading.Tasks;
using L2AccountPanel.Infrastructure.DTO;

namespace L2AccountPanel.Infrastructure.Services
{
    public interface IAccountCharacterInfoService : IService
    {
        Task<AccountCharacterInfoDTO> GetAsync(Guid userId, string charName, int server);
    }
}