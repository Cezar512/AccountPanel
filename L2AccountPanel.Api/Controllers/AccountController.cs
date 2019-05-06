using System;
using System.Threading.Tasks;
using L2AccountPanel.Infrastructure.Commands;
using L2AccountPanel.Infrastructure.Commands.Accounts;
using L2AccountPanel.Infrastructure.Commands.Characters;
using L2AccountPanel.Infrastructure.Extensions;
using L2AccountPanel.Infrastructure.Services;
using L2AccountPanel.Infrastructure.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L2AccountPanel.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ICommandDispatcher _commandDispatcher;

        public AccountController(IAccountService accountService, ICommandDispatcher commandDispatcher, GeneralSettings generalSettings)
                                :base(commandDispatcher)
        {
            _accountService = accountService;
            _commandDispatcher = commandDispatcher;
            
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("accounts/{email}")]
        public async Task<IActionResult> GetAll(string email)
        {
            var accounts = await _accountService.GetAllAsync(email);
            if(accounts == null)
            {
                return NotFound();
            }
            return Json(accounts);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("username/{username}")]
        public async Task<IActionResult> Get(string username)
        {
            var account = await _accountService.GetAsync(username);
            if(account == null)
            {
                return NotFound();
            }
            return Json(account);
        }
        [Authorize]
        [HttpGet]
        [Route("userid/{userId}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var tokenPayload = HttpContext.Request.Headers["authorization"];
            
            if(JWTPayload.TokenPayload(tokenPayload,userId))
            {
            var account = await _accountService.GetAsync(userId);
            if(account == null)
            {
                return NotFound();
            }
            return Json(account);
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("accounts")]
        public async Task<IActionResult> Browse()
        {
            var accounts = await _accountService.BrowseAsync();
            if(accounts == null)
            {
                return NotFound();
            }
            return Json(accounts);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Post([FromBody]CreateAccount command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Created($"Created {command.Username}",null);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Post([FromBody]Login command)
         => Ok(await _accountService.LoginAsync(command.Username, command.Password));
    }
}