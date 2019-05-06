using System;
using L2AccountPanel.Core.Domain;

namespace L2AccountPanel.Infrastructure.DTO
{
    public class CharacterDTO
    {
        public string Name {get; set;}
        public Guid UserId {get; set;}
        public int Server {get; set;}
    }
}