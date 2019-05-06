using System;
using System.Threading.Tasks;
using L2AccountPanel.Core.Domain;
using L2AccountPanel.Core.Repositories;
using L2AccountPanel.Infrastructure.DTO;

namespace L2AccountPanel.Infrastructure.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IJwtHandler _jwtHandler;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository, IAccountRepository accountRepository, IJwtHandler jwtHandler)
        {
            _accountRepository = accountRepository;
            _jwtHandler = jwtHandler;
            _refreshTokenRepository = refreshTokenRepository;
        }

        
        public async Task CreateAsync(Guid userId)
        {
            var account = await _accountRepository.GetAsync(userId);
            if (account == null)
            {
                throw new Exception($"Account was not found.");
            }
            var token = Guid.NewGuid().ToString("N");
            await _refreshTokenRepository.CreateAsync(new RefreshToken(account, token));
        }
        public async Task<IdentityToken> CreateAccessTokenAsync(string token)
        {
            var refreshToken = await _refreshTokenRepository.GetAsync(token);
            if(refreshToken == null)
            {
                throw new Exception("Refresh token was not found.");
            }
            if(refreshToken.Revoked)
            {
                throw new Exception($"Refresh token was revoked");
            }
            var account = await _accountRepository.GetAsync(refreshToken.UserId);
            if(account == null)
            {
                throw new Exception($"Account was not found.");
            }
            var jwt = _jwtHandler.Create(account.Username, account.Role, account.Id);
            
            

            return new IdentityToken
            {
                AccessToken = jwt.AccessToken,
                Expires = jwt.Expires,
                RefreshToken = refreshToken.Token,
                Role = account.Role,
                UserId = account.Id
            };
        }

        public async Task RevokeAsync(string token)
        {
            var refreshToken = await _refreshTokenRepository.GetAsync(token);
            var account = _accountRepository.GetAsync(refreshToken.UserId);
            if(refreshToken == null || account == null)
            {
                throw new Exception("Refresh token was not found.");
            }
            refreshToken.Revoke();
            await _refreshTokenRepository.UpdateAsycn(refreshToken);
        }
    }
}