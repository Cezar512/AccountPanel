using System.Threading.Tasks;
using L2AccountPanel.Infrastructure.Commands;
using L2AccountPanel.Infrastructure.Commands.Tokens;
using L2AccountPanel.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L2AccountPanel.Api.Controllers
{

    public class TokensController : ApiControllerBase
    {
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly ICommandDispatcher _commandDispatcher;
        

        public TokensController(IRefreshTokenService refreshTokenService, ICommandDispatcher commandDispatcher)
                                :base(commandDispatcher)
        {
            _refreshTokenService = refreshTokenService;
            _commandDispatcher = commandDispatcher;
            
        }

        [HttpPost]
        [Route("{refreshToken}/refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshAccessToken(string refreshToken)
        => Ok(await _refreshTokenService.CreateAccessTokenAsync(refreshToken));

        [HttpPost]
        [Route("{refreshToken}/revoke")]
        [AllowAnonymous]
        public async Task<IActionResult> RevokeAccessToken(string refreshToken)
        {
            await _refreshTokenService.RevokeAsync(refreshToken);
            return Ok();
        }
    }
}