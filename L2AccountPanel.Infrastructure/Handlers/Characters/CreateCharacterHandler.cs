using System.Threading.Tasks;
using L2AccountPanel.Infrastructure.Commands;
using L2AccountPanel.Infrastructure.Commands.Characters;
using L2AccountPanel.Infrastructure.Services;

namespace L2AccountPanel.Infrastructure.Handlers.Characters
{
    public class CreateCharacterHandler : ICommandHandler<CreateCharacter>
    {
        private readonly ICharacterService _characterService;

        public CreateCharacterHandler(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        public async Task HandleAsync(CreateCharacter command)
        {
           await _characterService.AddAsync(command.UserId,command.Name,command.Server);
        }         
    }
}