using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Common.Configurations.Constants;
using Common.Models;
using Microsoft.IdentityModel.Tokens;

namespace Common.Methods
{
    /// <summary>
    /// Token related methods 
    /// </summary>
    public static class TokenMethods
    {
        /// <summary>
        /// Generate Token For User
        /// </summary>
        /// <param name="encodingKey"></param>
        /// <param name="sessionHash"></param>
        /// <param name="username"></param>
        /// <param name="user"></param>
        /// <returns>TokenViewModel</returns>
        public static string GenerateTokenViewModelForUser(string encodingKey, string sessionHash, string username, User user)
        {
            // Create Authentication Token
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(encodingKey);

            DateTime issueDateTime = DateTime.UtcNow;
            DateTime expireDateTime = issueDateTime.AddDays(1);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.NameIdentifier, sessionHash),
                    new Claim(TokenClaimTypes.FirstName, user.FirstName),
                    new Claim(TokenClaimTypes.LastName, user.LastName),
                    new Claim(TokenClaimTypes.Gender, Enum.GetName(typeof(GenderEnum), user.GenderEnum)),
                    new Claim(TokenClaimTypes.IssuedAt, issueDateTime.ToString("yyyy-MM-dd HH:mm:ss.ffffzzz")),
                    new Claim(TokenClaimTypes.ExpireAt, expireDateTime.ToString("yyyy-MM-dd HH:mm:ss.ffffzzz"))
                }),
                IssuedAt = issueDateTime,
                NotBefore = issueDateTime,
                Expires = expireDateTime,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
