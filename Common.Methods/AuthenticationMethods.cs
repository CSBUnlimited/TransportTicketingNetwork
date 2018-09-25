using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Common.Configurations.Constants;
using Common.Models;
using Microsoft.IdentityModel.Tokens;

namespace Common.Methods
{
    /// <summary>
    /// This class contains security/ Authentication related methods
    /// </summary>
    public static class AuthenticationMethods
    {
        /// <summary>
        /// Create Password Hash And Password Salt
        /// </summary>
        /// <param name="password">Password</param>
        /// <param name="passwordHash">Out - Password Hash</param>
        /// <param name="passwordSalt">Out - Password Salt</param>
        public static void CreatePasswordHashAndSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (HMACSHA512 hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        /// Verify provided password is match with password hash and salt
        /// </summary>
        /// <param name="password">Password</param>
        /// <param name="passwordHash">Password Hash</param>
        /// <param name="passwordSalt">Password Salt</param>
        /// <returns>If password matches Password Hash and Password Salt then retuns True</returns>
        public static bool IsPasswordVerified(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return !computedHash.Where((cHash, index) => cHash != passwordHash[index]).Any();
            }
        }

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
                    new Claim(ClaimTypes.NameIdentifier, username),
                    new Claim(ClaimTypes.Name, $"{ user.FirstName } { user.LastName }"),
                    new Claim(TokenClaimTypes.FirstName, user.FirstName), 
                    new Claim(TokenClaimTypes.LastName, user.LastName),
                    new Claim(TokenClaimTypes.Gender, user.Gender == Gender.Male ? "Male" : "Female"),
                    new Claim(TokenClaimTypes.SessionHash, sessionHash),
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
