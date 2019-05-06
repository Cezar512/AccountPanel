using L2AccountPanel.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc;

namespace L2AccountPanel.Api.Controllers
{
    [Route("[controller]")]
    public abstract class ApiControllerBase : Controller
    {
        protected readonly ICommandDispatcher CommandDispatcher;

        protected ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;
        }
    }
}