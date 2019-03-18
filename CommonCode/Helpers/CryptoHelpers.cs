using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CommonCode.Helpers
{
    public static class CryptoHelpers
    {

        public static byte[] GetSalt()
        {
            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        public static byte[] HashPassword(string password, byte[] salt)
        {
            return KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8);
        }

        public static SymmetricSecurityKey GetSymmetricSecurityKey(IConfiguration configs)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configs.GetSection("AppSettings:token").Value));
        }
    }
}