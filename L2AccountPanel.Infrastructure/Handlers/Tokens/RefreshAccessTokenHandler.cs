using System.Threading.Tasks;
using L2AccountPanel.Infrastructure.Commands;
using L2AccountPanel.Infrastructure.Commands.Tokens;
using L2AccountPanel.Infrastructure.Services;

namespace L2AccountPanel.Infrastructure.Handlers.Tokens
{
    public class RefreshAccessTokenHandler : ICommandHandler<RefreshAccessToken>
    {
        private readonly IRefreshTokenService _refreshTokenService;

        public RefreshAccessTokenHandler(IRefreshTokenService refreshTokenService)
        {
            _refreshTokenService = refreshTokenService;
        }

        public async Task HandleAsync(RefreshAccessToken command)
        {
           await _refreshTokenService.CreateAccessTokenAsync(command.Token);
    }   }
}