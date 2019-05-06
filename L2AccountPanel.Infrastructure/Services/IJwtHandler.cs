
using System;
using L2AccountPanel.Infrastructure.DTO;

namespace L2AccountPanel.Infrastructure.Services
{
    public interface IJwtHandler
    {
         JwtTokenDTO Create(string username, string role, Guid userId);
    }
}