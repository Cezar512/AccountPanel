using System;
using System.IdentityModel.Tokens.Jwt;

namespace L2AccountPanel.Infrastructure.Extensions
{
    public static class JWTPayload
    {
       public static bool TokenPayload(string token, Guid userId)
       {
            object obString;

            var splitToken = token.Split(' ');
            var splitToPayload = splitToken[1].Split('.');
            var tokenDeserialized = JwtPayload.Base64UrlDeserialize(splitToPayload[1]).TryGetValue("unique_name", out obString);
            var tokenPayloadGuid = Guid.Parse(obString.ToString());

            if(userId == tokenPayloadGuid)
            {
                return true;
            }
            else
            {
                return false;
            }
       }
        public static bool AdminPayload(string token)
       {
            object obString;

            var splitToken = token.Split(' ');
            var splitToPayload = splitToken[1].Split('.');
            var tokenDeserialized = JwtPayload.Base64UrlDeserialize(splitToPayload[1]).TryGetValue("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", out obString);
            var role = obString.ToString();

            if(role == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }
       } 
    }
}