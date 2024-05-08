using Microsoft.IdentityModel.Tokens;
using MoodleBackEnd.Models.Entites;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoodleBackEnd.Models.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;
        private readonly MoodleContext context;

        public TokenService(IConfiguration configuration, MoodleContext context)
        {
            _configuration = configuration;
            this.context = context;
        }

        public (bool IsValid, string Token) GenerateToken(string username, string password)
        {
 
            var userAccount = context.UserAccounts.SingleOrDefault(r => r.Username == username);
            if (userAccount == null)
            {
                return (false, "");
            }

            var validPassword = BCrypt.Net.BCrypt.EnhancedVerify(password, userAccount.Password);
            if (!validPassword)
            {
                return (false, "");

            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // From here
            var claims = new[]
            {
        new Claim(TokenClaimsConstant.Username, username),
        new Claim(TokenClaimsConstant.UserId, userAccount.Id.ToString()),
        new Claim(ClaimTypes.Role, userAccount.AccountType.ToString())
        };

            // To Here
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30), // Expire
                signingCredentials: credentials);
            var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return (true, generatedToken);
        }
    }
}
