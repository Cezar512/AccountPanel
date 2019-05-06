using System;
using System.Threading.Tasks;
using L2AccountPanel.Infrastructure.DTO;

namespace L2AccountPanel.Infrastructure.Services
{
    public interface IRefreshTokenService : IService
    {
        Task CreateAsync(Guid userId);
        Task<IdentityToken> CreateAccessTokenAsync(string refreshToken);
        Task RevokeAsync(string refreshToken); 
    }
}