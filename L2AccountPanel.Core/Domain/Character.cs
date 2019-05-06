using System;

namespace L2AccountPanel.Core.Domain
{
    public class Character
    {
        public Guid CharacterId {get; protected set;}
        public string Name {get; protected set;}
        public Guid UserId {get; protected set;}
        public int Server {get; protected set;}
        public DateTime CreatedAt {get; protected set;} 
        public Character(Account account, string name, int server)
        {
            CharacterId = Guid.NewGuid();
            UserId = account.Id;
            Name = name;
            Server = server;
            CreatedAt = DateTime.UtcNow;
        }
    }
}