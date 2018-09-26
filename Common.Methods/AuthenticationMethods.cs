using System.Linq;
using System.Security.Cryptography;
using System.Text;

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
            using (HMACSHA512 hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        /// Verify provided password is match with password hash and salt
        /// </summary>
        /// <param name="password">Encoded Password</param>
        /// <param name="passwordHash">Password Hash</param>
        /// <param name="passwordSalt">Password Salt</param>
        /// <returns>If password matches Password Hash and Password Salt then retuns True</returns>
        public static bool IsPasswordVerified(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            password = DecodeFrom64(password);

            using (HMACSHA512 hmac = new HMACSHA512(passwordSalt))
            {
                byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return !computedHash.Where((cHash, index) => cHash != passwordHash[index]).Any();
            }
        }

        /// <summary>
        /// Encode a string to Base64.
        /// This is equivalent to b-to-a method in Javascript
        /// </summary>
        /// <param name="stringToEncode">String that need to encode</param>
        /// <returns>Encoded string</returns>
        public static string EncodeTo64(string stringToEncode)
        {
            byte[] toEncodeAsBytes = System.Text.Encoding.ASCII.GetBytes(stringToEncode);
            return System.Convert.ToBase64String(toEncodeAsBytes);
        }

        /// <summary>
        /// Decode a string using Base64.
        /// This is equivalent to a-to-b method in Javascript
        /// </summary>
        /// <param name="stringToDecode">String that need to decode</param>
        /// <returns>Decoded string</returns>
        public static string DecodeFrom64(string stringToDecode)
        {
            byte[] encodedDataAsBytes = System.Convert.FromBase64String(stringToDecode);
            return System.Text.Encoding.ASCII.GetString(encodedDataAsBytes);
        }
    }
}
