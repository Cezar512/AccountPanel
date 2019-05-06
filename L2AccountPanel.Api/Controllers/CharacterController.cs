using System;
using System.Threading.Tasks;
using L2AccountPanel.Infrastructure.Commands;
using L2AccountPanel.Infrastructure.Commands.Characters;
using L2AccountPanel.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using L2AccountPanel.Infrastructure.Extensions;

namespace L2AccountPanel.Api.Controllers
{
    public class CharacterController : ApiControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly ICharacterService _characterService;

        public CharacterController(IAccountService accountService, ICharacterService characterService, ICommandDispatcher commandDispatcher)
                                    :base(commandDispatcher)
        {
            _accountService = accountService;
            _characterService = characterService;
            _commandDispatcher = commandDispatcher;
        }

        [Authorize]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Post([FromBody]CreateCharacter command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Created($"Created {command.Name} on server {command.Server}",null);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody]DeleteCharacter command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return NoContent();
        }
        
        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("characters")]
        public async Task<IActionResult> GetAllAsync()
        {
            var characters = await _characterService.GetAllAsync();
            if(characters == null)
            {
                return NotFound();
            }
            return Json(characters);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("characters/{server}")]
        public async Task<IActionResult> GetAllAsync(int server)
        {
            var characters = await _characterService.GetAllAsync(server);
            if(characters == null)
            {
                return NotFound();
            }
            return Json(characters);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("characters/account/{userId}")]
        public async Task<IActionResult> GetAllCharacterForAccountAsync(Guid userId)
        {
			var characters = await _characterService.GetAllCharactersForAccountIdAsync(userId);
			if(characters == null)
			{
				return NotFound();
			}
			return Json(characters);
        }
        
        [Authorize]
        [HttpGet]
        [Route("characters/account/{userId}/server/{server}")]
        public async Task<IActionResult> GetAllCharacterForAccountIdAndServerAsync(Guid userId, int server)
        {
            
            var tokenPayload = HttpContext.Request.Headers["authorization"];

            if(JWTPayload.AdminPayload(tokenPayload))
            {
                var characters = await _characterService.GetAllCharacterForAccountIdAndServerAsync(userId, server);
                if(characters == null)
                {
                    return NotFound();
                }
                return Json(characters);
            }
            else
            {
                if(JWTPayload.TokenPayload(tokenPayload,userId))
                {
                    var characters = await _characterService.GetAllCharacterForAccountIdAndServerAsync(userId, server);
                    if(characters == null)
                    {
                        return NotFound();
                    }
                    return Json(characters);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var character = await _characterService.GetAsync(id);
            if(character == null)
            {
                return NotFound();
            }
            return Json(character);
        } 
        
        [Authorize]
        [HttpGet]
        [Route("account/{userId}/name/{name}/server/{server}")]
        public async Task<IActionResult> GetAsync(Guid userId, string name, int server)
        {
            var tokenPayload = HttpContext.Request.Headers["authorization"];
            
            if(JWTPayload.TokenPayload(tokenPayload,userId))
            {
                var character = await _characterService.GetAsync(name,server);
                if(character == null)
                {
                    return NotFound();
                }
                return Json(character);
            }
            else
            {
                return NotFound();
            }
        } 
    }
}