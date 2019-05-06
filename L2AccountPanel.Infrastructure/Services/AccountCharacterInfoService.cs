using System.Threading.Tasks;
using AutoMapper;
using L2AccountPanel.Core.Repositories;
using L2AccountPanel.Infrastructure.DTO;
using L2AccountPanel.Infrastructure.EF;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace L2AccountPanel.Infrastructure.Services
{
    public class AccountCharacterInfoService : IAccountCharacterInfoService
    {
        private readonly L2AccountPanelContext _context;
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly ICharacterRepository _characterRepository;

        public AccountCharacterInfoService(L2AccountPanelContext context,
        IMapper mapper, IAccountRepository accountRepository,ICharacterRepository characterRepository)
        {
            _context = context;
            _mapper = mapper;
            _accountRepository = accountRepository;
            _characterRepository = characterRepository;
        }

        public async Task<AccountCharacterInfoDTO> GetAsync(Guid userId, string charName, int server)
        {
            var account = await _accountRepository.GetAsync(userId);
            if(account != null)
            {
                var character = await _characterRepository.GetAsync(charName,server);
                if(character != null)
                {
                    var info = await _context.Characters.Join(_context.Accounts,
                    c=>c.AccountName,
                    cm=>cm.Login,
                    (c,cm)=> new AccountCharacterInfoDTO{
                    Login = cm.Login,
                    LastIp = cm.LastIp,
                    CharName = c.CharName,
                    Level = c.Level,
                    MaxHp = c.MaxHp,
                    MaxMp = c.MaxMp,
                    MaxCp = c.MaxCp,
                    Pkkills = c.Pkkills,
                    Pvpkills = c.Pvpkills,
                    Sex = c.Sex,
                    Classid = c.Classid,
                    Title = c.Title   
                    }).FirstOrDefaultAsync(x=>x.CharName == "Noriko"); //ToChange
                    return info;
                }
                else
                {
                    throw new Exception($"Character with name: '{charName}' is not exists.");
                }
            }
            else
            {
                throw new Exception($"User does not exists.");
            }
        }
    }
}