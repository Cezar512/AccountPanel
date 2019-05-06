using System;

namespace L2AccountPanel.Core.Domain
{
    public class RefreshToken
    {
        public Guid UserId {get; protected set;}
        public Guid Id {get; protected set;}
        public string Token {get; protected set;}
        public DateTime CreatedAt { get; protected set; }
        public DateTime? RevokedAt { get; protected set; }
        public bool Revoked => RevokedAt.HasValue;


        public RefreshToken(Account account, string token)
        {
            Id = Guid.NewGuid();
            UserId = account.Id;
            CreatedAt = DateTime.UtcNow;
            Token = token;
        }

                public void Revoke()
        {
            if (Revoked)
            {
                throw new Exception($"Refresh token: '{Id}' was already revoked at '{RevokedAt}'.");
            }
            RevokedAt = DateTime.UtcNow;
}

    }
}