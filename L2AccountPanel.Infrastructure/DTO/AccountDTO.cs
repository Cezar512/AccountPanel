using System;
using System.Collections.Generic;
using L2AccountPanel.Core.Domain;

namespace L2AccountPanel.Infrastructure.DTO
{
    public class AccountDTO
    {
        public Guid Id {get; set;}
        public string Username {get; set;}
        public string Email {get; set;}
        public DateTime CreatedAt {get; set;}
        
    }
}