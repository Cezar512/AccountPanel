using System;

namespace L2AccountPanel.Infrastructure.Commands.Characters
{
    public class CreateCharacter : ICommand
    {
        public Guid UserId {get; set;}
        public string Name {get; set;}
        public int Server {get; set;}
    }
}