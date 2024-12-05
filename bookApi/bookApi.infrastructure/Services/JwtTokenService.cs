using bookApi.Domian.Interfaces;
using bookApi.Domian.Models;
using bookApi.infrastructure.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace bookApi.infrastructure.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Key-Value pair that represent user data that can be encoded into the JWT
            //These claims are included in the payload of the token
            var claims = new[]
            {
                //Identifies the principal (User) that is the subject of the JWT
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()), //Sub (subject)

                //User Email
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),


                //Unique identifier of the token, typically a GUID
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //JWT ID
                    new Claim(ClaimTypes.Role, Enum.GetName(typeof(UserRole), user.RoleId))
            };

            var token = new JwtSecurityToken(
             issuer: _configuration["Jwt:Issuer"],  //Specifies entity issuing the token
             audience: _configuration["Jwt:Audience"], //Speficies the recipient of the token
             claims: claims,
             expires: DateTime.Now.AddMinutes(30),
             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
