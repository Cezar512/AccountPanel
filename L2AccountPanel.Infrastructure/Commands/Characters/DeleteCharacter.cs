namespace L2AccountPanel.Infrastructure.Commands.Characters
{
    public class DeleteCharacter : ICommand
    {
        public string Name {get; set;}
        public int Server {get; set;}
    }
}