using IdentityModel;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyShops.Authentication
{
    public class TokenManager
    {
        private  readonly IHttpContextAccessor _httpContextAccessor;

        private static string ClientUrl = "http://localhost:4200/";
        private static string Issuer = "self";
        private static int ExpireTimeInMinutes = 120;

        public TokenManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static string GenerateToken(int roleId, int id, string name, string mobNo, string firstName, string lastName)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes("401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1"));
            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(JwtClaimTypes.Id, Convert.ToString(id)),
                new Claim(JwtClaimTypes.Name,name),
                new Claim(JwtClaimTypes.Role,Convert.ToString(roleId)),
                new Claim(JwtClaimTypes.GivenName,String.Concat(firstName, ' '),lastName),
                new Claim(JwtClaimTypes.ClientId, Convert.ToString(roleId)),
            }, "Custom");


            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Audience = ClientUrl,
                Issuer = Issuer,
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddMinutes(ExpireTimeInMinutes),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);

            var res = handler.WriteToken(token);

            res = String.Join("bearer ", res);
            return res;
        }

        private ClaimsPrincipal User => _httpContextAccessor.HttpContext.User;
        private IEnumerable<Claim> Claims => User.Claims;

        public int UserId { get => GetUserId(); }
 
        public int GetUserId()
        {
            if (User.HasClaim(claim => claim.Type == JwtClaimTypes.Id))
            {
                return Convert.ToInt32(Claims.FirstOrDefault(claim => claim.Type == JwtClaimTypes.Id).Value);
            }
            return 0;
        }

        public int GetUserRoleId()
        {
            if (User.HasClaim(claim => claim.Type == JwtClaimTypes.Id))
            {
                return Convert.ToInt32(Claims.FirstOrDefault(claim => claim.Type == JwtClaimTypes.ClientId).Value);
            }
            return 0;
        }

    }

}

