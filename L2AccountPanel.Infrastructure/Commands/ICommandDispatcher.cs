using System.Threading.Tasks;

namespace L2AccountPanel.Infrastructure.Commands
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : ICommand;

    }
}