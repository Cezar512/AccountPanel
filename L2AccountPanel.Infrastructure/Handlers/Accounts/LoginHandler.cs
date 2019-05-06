using System.Threading.Tasks;
using L2AccountPanel.Infrastructure.Commands;
using L2AccountPanel.Infrastructure.Commands.Accounts;
using L2AccountPanel.Infrastructure.Services;

namespace L2AccountPanel.Infrastructure.Handlers.Accounts
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IAccountService _accountService;

        public LoginHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task HandleAsync(Login command)
         => await _accountService.LoginAsync(command.Username, command.Password);        
    }
}