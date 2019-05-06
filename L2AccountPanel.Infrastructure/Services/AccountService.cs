using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using L2AccountPanel.Core.Domain;
using L2AccountPanel.Core.Repositories;
using L2AccountPanel.Infrastructure.DTO;

namespace L2AccountPanel.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IJwtHandler _jwtHandler;
        public AccountService(IAccountRepository accountRepository,IEncrypter encrypter, IMapper mapper, 
                                IRefreshTokenRepository refreshTokenRepository, IJwtHandler jwtHandler)
        {
            _accountRepository = accountRepository;
            _encrypter = encrypter; 
            _mapper = mapper;
            _jwtHandler = jwtHandler;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<IEnumerable<AccountDTO>> BrowseAsync()
        {
            var accounts = await _accountRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Account>,IEnumerable<AccountDTO>>(accounts);
        }

        public async Task<IEnumerable<AccountDTO>> GetAllAsync(string email)
        {
            var accounts = await _accountRepository.GetAllAsync(email);
            
            return _mapper.Map<IEnumerable<Account>,IEnumerable<AccountDTO>>(accounts);
        }
        
        public async Task<AccountDTO> GetAsync(string username)
        {
           var account = await _accountRepository.GetAsync(username);

           return _mapper.Map<Account,AccountDTO>(account);
        }

        public async Task<AccountDTO> GetAsync(Guid userId)
        {
           var account = await _accountRepository.GetAsync(userId);

           return _mapper.Map<Account,AccountDTO>(account);
        }

        public async Task<IdentityToken> LoginAsync(string username, string password)
        {
            var account = await _accountRepository.GetAsync(username);
            if(account==null)
            {
                throw new Exception("Invalid credentials");
            }
            var hash = _encrypter.GetHash(password, account.Salt);
            if(account.Password != hash)
            {
                throw new Exception("Invalid credentials");
            }
            var token  = Guid.NewGuid().ToString("N");
            var refreshToken = new RefreshToken(account,token);
            var jwt = _jwtHandler.Create(account.Username, account.Role, account.Id);
            
            await _refreshTokenRepository.CreateAsync(refreshToken);
            
            return new IdentityToken
            {
                AccessToken = jwt.AccessToken,
                Expires = jwt.Expires,
                RefreshToken = token,
                Role = account.Role,
                UserId = account.Id
            };
        }

        public async Task RegisterAsync(Guid userId, string email, string password, string username, string role)
        {
            var account = await _accountRepository.GetAsync(username);
            if(account != null)
            {
                throw new Exception($"User with username: '{username}' already exists.");
            }
            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            account = new Account(userId,email,hash,username,salt, role);
            await _accountRepository.AddAsync(account);
        }
    }
}