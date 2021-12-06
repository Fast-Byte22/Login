using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Login.Custom
{
    public class HashPasscs
    {
        public string hash;
        public byte[] salt;
        public HashPasscs HashPass(string pass)
        {

            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }



            byte []hashed =KeyDerivation.Pbkdf2(
                password: pass,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8);

            HashPasscs hashObj = new HashPasscs();

            hashObj.hash = Convert.ToBase64String( hashed);
            hashObj.salt = salt;

            return hashObj;
        }
        public static string CheckHashPass(string pass, byte[] salt)
        {

            




            string hashed = Convert.ToBase64String( KeyDerivation.Pbkdf2(
                password: pass,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));


            return hashed;
        }

    }
}
