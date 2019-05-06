using System;

namespace L2AccountPanel.Infrastructure.DTO
{
    public class IdentityToken : JwtTokenDTO
    {
        public string RefreshToken { get; set; }
        public string Role { get; set; }
        public Guid UserId { get; set; } 
    }
}