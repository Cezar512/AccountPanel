using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using L2AccountPanel.Infrastructure.DTO;
using L2AccountPanel.Infrastructure.Extensions;
using L2AccountPanel.Infrastructure.Settings;
using Microsoft.IdentityModel.Tokens;


namespace L2AccountPanel.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _jwtSettings;

        public JwtHandler(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        public JwtTokenDTO Create(string username, string role, Guid userId)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,now.ToTimestamp().ToString(), ClaimValueTypes.Integer64)
            };
            var expires = now.AddMinutes(_jwtSettings.ExpiryMinutes);
            var singingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)), 
                                    SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Issuer,
                claims:claims,
                notBefore:now,
                expires:expires,
                signingCredentials:singingCredentials  
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new JwtTokenDTO
            {
                AccessToken = token,
                Expires = expires.ToTimestamp()
            };

        }
    }
}