using System.Threading.Tasks;
using L2AccountPanel.Infrastructure.Commands;
using L2AccountPanel.Infrastructure.Commands.Characters;
using L2AccountPanel.Infrastructure.Services;

namespace L2AccountPanel.Infrastructure.Handlers.Characters
{
    public class DeleteCharacterHandler : ICommandHandler<DeleteCharacter>
    {
        private readonly ICharacterService _characterService;

        public DeleteCharacterHandler(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        public async Task HandleAsync(DeleteCharacter command)
        {
           await _characterService.DeleteAsync(command.Name,command.Server);
        }         
    }      
}