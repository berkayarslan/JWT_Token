using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web_Api_JWT.Models;

namespace Web_Api_JWT.Security
{
    public static class TokenHandler

    {
        public static Token CreateToken(User user, IConfiguration configuration)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim("user",user.UserName),
            };
            Token token = new Token();

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));

            SigningCredentials credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            token.Expration = DateTime.Now.AddMinutes(Convert.ToInt32(configuration["JWT:Expration"]));

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
                (
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                claims: claims,
                notBefore: DateTime.Now,
                signingCredentials: credentials,
                expires: token.Expration

                );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            token.AccessToken=handler.WriteToken(jwtSecurityToken);
            return token;
        }
    }
}
