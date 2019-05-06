using System;
using System.Threading.Tasks;
using L2AccountPanel.Infrastructure.Commands;
using L2AccountPanel.Infrastructure.Commands.Accounts;
using L2AccountPanel.Infrastructure.Services;

namespace L2AccountPanel.Infrastructure.Handlers.Accounts
{
    public class CreateAccountHandler : ICommandHandler<CreateAccount>
    {
        private readonly IAccountService _accountService;

        public CreateAccountHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task HandleAsync(CreateAccount command)
        {
           await _accountService.RegisterAsync(Guid.NewGuid(),command.Email,command.Password,command.Username, command.Role);
        }
    }
}