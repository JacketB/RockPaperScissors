using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace game
{
    class Hmac
    {
        private HMACSHA256 hmac;   
        private byte[] GenerateHmacKey(byte[] bytes)
        {
            RandomNumberGenerator.Create().GetBytes(bytes);
            return bytes;
        }

        public void CreateHmac(string move)
        {
            hmac = new HMACSHA256(GenerateHmacKey(new byte[16]));
            var messageBytes = Encoding.UTF8.GetBytes(move);
            var hash = hmac.ComputeHash(messageBytes);
        }

        public void PrintHmac()
        {
            Console.WriteLine("HMAC: " + BitConverter.ToString(hmac.Hash).Replace("-",string.Empty));
        }

        public void PrintKey()
        {
            Console.WriteLine("HMAC key: " + BitConverter.ToString(hmac.Key).Replace("-", string.Empty));
        }
    }
}
