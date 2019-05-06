using System;
using System.Threading.Tasks;
using L2AccountPanel.Infrastructure.Commands;
using L2AccountPanel.Infrastructure.Extensions;
using L2AccountPanel.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L2AccountPanel.Api.Controllers
{
    public class AccCharInfoController : ApiControllerBase
    {
        private readonly IAccountCharacterInfoService _info;
        private readonly ICommandDispatcher _commandDispatcher;

        public AccCharInfoController(IAccountCharacterInfoService info, ICommandDispatcher commandDispatcher)
                :base(commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _info = info;
        }

        [Authorize]
        [HttpGet]
        [Route("{userId}/{charName}/{server}")]
        public async Task<IActionResult> Get(Guid userId,string charName, int server)
        {
            var tokenPayload = HttpContext.Request.Headers["authorization"];
            
            if(JWTPayload.TokenPayload(tokenPayload,userId))
            {
                var info = await _info.GetAsync(userId,charName,server);
                if(info == null)
                {
                    return NotFound();
                }
                return Json(info);
            }
            else
            {
                return NotFound();
            }
        }
    }
}