using GST_API_DAL.Models;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GST_API.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private const int ExpirationMinutes = 43205;

        public string CreateToken(User user, string baseAppKey, IList<string>? roles)
        {
            var expiration = DateTime.UtcNow.AddMinutes(ExpirationMinutes);
            var token = CreateJwtToken(
                CreateClaims(user, baseAppKey,roles),
                CreateSigningCredentials(),
                expiration
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        private JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials,
            DateTime expiration) =>
            new(
                _configuration["Jwt:Issuer"],
                 _configuration["Jwt:Audience"],
                claims,
                expires: expiration,
                signingCredentials: credentials
        );

        private List<Claim> CreateClaims(User user, string baseAppKey,IList<string>? roles)
        {
            try
            {
                var claims = new List<Claim>
                {
                    new Claim("Id", user.Id),
                    new Claim("GSTN",user.GSTNNo),
                    new Claim("GSTNUsername",user.GSTINUsername),
                    new Claim("BaseAppKey",baseAppKey)
                };
                if(roles?.Count()>0) { 
                    foreach(string role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }
                }

                return claims;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        private SigningCredentials CreateSigningCredentials()
        {
            return new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                SecurityAlgorithms.HmacSha256
            );
        }
    }
}
