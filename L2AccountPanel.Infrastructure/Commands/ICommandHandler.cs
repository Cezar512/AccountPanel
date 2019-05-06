using System.Threading.Tasks;

namespace L2AccountPanel.Infrastructure.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}