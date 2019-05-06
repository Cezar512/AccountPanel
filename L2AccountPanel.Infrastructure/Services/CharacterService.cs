using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using L2AccountPanel.Core.Domain;
using L2AccountPanel.Core.Repositories;
using L2AccountPanel.Infrastructure.DTO;

namespace L2AccountPanel.Infrastructure.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        public CharacterService(ICharacterRepository characterRepository, IMapper mapper, IAccountRepository accountRepository)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
            _accountRepository = accountRepository;
        }
        public async Task AddAsync(Guid userId, string name, int server)
        {
            var account = await _accountRepository.GetAsync(userId);
            if(account != null)
            {
                var character = await _characterRepository.GetAsync(name,server);
                if(character == null)
                {
                    character = new Character(account,name,server);
                    await _characterRepository.AddAsync(character);
                }
                else
                {
                    throw new Exception("Character alredy exists");
                }
            }
            else
            {
                throw new Exception("Account doesnt exists");
            }
        }

        public async Task DeleteAsync(string name, int server)
        {
            var character = await _characterRepository.GetAsync(name, server);
            if(character != null)
            {
                await _characterRepository.RemoveAsync(character);
            }
            else
            {
                throw new Exception("Character doesnt exists");
            }
        }

        public async Task<IEnumerable<CharacterDTO>> GetAllAsync()
        {
            var characters = await _characterRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Character>,IEnumerable<CharacterDTO>>(characters);
        }

        public async Task<IEnumerable<CharacterDTO>> GetAllAsync(int server)
        {
            var characters = await _characterRepository.GetAllAsync(server);

            return _mapper.Map<IEnumerable<Character>,IEnumerable<CharacterDTO>>(characters);
        }

        public async Task<IEnumerable<CharacterDTO>> GetAllCharactersForAccountIdAsync(Guid userId)
        {
            var characters = await _characterRepository.GetAllCharactersForAccountIdAsync(userId);

            return _mapper.Map<IEnumerable<Character>,IEnumerable<CharacterDTO>>(characters);
        }
        public async Task<IEnumerable<CharacterDTO>> GetAllCharacterForAccountIdAndServerAsync(Guid userId, int server)
        {
            var characters = await _characterRepository.GetAllCharacterForAccountIdAndServerAsync(userId, server);

            return _mapper.Map<IEnumerable<Character>,IEnumerable<CharacterDTO>>(characters);
        }
        public async Task<CharacterDTO> GetAsync(Guid id)
        {
            var character = await _characterRepository.GetCharacterAsync(id);

            return _mapper.Map<Character,CharacterDTO>(character);
        }

        public async Task<CharacterDTO> GetAsync(string name, int server)
        {
            var character = await _characterRepository.GetAsync(name, server);

            return _mapper.Map<Character,CharacterDTO>(character);
        }
    }
}