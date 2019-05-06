// using System.Linq;
// using System.Threading.Tasks;
// using L2AccountPanel.Infrastructure.Settings;
// using Microsoft.AspNetCore.Http;

// namespace L2AccountPanel.Infrastructure.Services
// {
//     public class TokenManager //: ITokenManager
//     {
//         private readonly IHttpContextAccessor _httpContextAccessor;
//         private readonly JwtSettings _settings;

//         public TokenManager(IHttpContextAccessor httpContextAccessor, JwtSettings settings)
//         {
//             _httpContextAccessor = httpContextAccessor;
//             _settings = settings;
//         }

//         public async Task DeactivateCurrentTokenAsync()
//             =>await IsTokenActive(GetCurrentAsync());

//         public async Task DeactivateTokenAsync(string token)
//             =>await DeactivateTokenAsync(GetCurrentAsync());

//         //public async Task<bool> IsCurrentTokenActive()
//          //   =>await 

//         public async Task<bool> IsTokenActive(string token)
//         {
//             throw new System.NotImplementedException();
//         }

//         private string GetCurrentAsync()
//         {
//             var authorizationHeader = _httpContextAccessor.HttpContext.Request
//                                         .Headers["authorization"];
//             return authorizationHeader == string.Empty ? string.Empty : authorizationHeader.Single().Split(' ').Last();
//         }

//         private static string GetKey(string token)
//             =>$"tokens: {token}:deactivated";
//     }
// }