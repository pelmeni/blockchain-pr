using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    class Program
    {
        public static string HashPassword(string password, string b64Salt = null)
        {
            if (password == null)
                throw new ArgumentNullException("password");

            byte[] salt;
            byte[] bytes;


            var rfc2898DeriveBytes = b64Salt == null
                ? new Rfc2898DeriveBytes(password, 16, 1000)
                : new Rfc2898DeriveBytes(password, Convert.FromBase64String(b64Salt), 1000);

            using (rfc2898DeriveBytes)
            {
                salt = rfc2898DeriveBytes.Salt;
                bytes = rfc2898DeriveBytes.GetBytes(32);
                //Console.WriteLine(Convert.ToBase64String(salt) + "|" + Convert.ToBase64String(bytes));
            }
            byte[] inArray = new byte[49];
            Buffer.BlockCopy((Array)salt, 0, (Array)inArray, 1, 16);
            Buffer.BlockCopy((Array)bytes, 0, (Array)inArray, 17, 32);
            return Convert.ToBase64String(inArray);
        }

        public static bool ValidatePassword(string passwordHash, string password)
        {
            byte[] numArray = Convert.FromBase64String(passwordHash);

            byte marker = numArray[0];

            if (marker == 1)
            {
                byte[] prf = new byte[4];
                Buffer.BlockCopy((Array)numArray, 1, (Array)prf, 0, 4);
                byte[] iter = new byte[4];
                Buffer.BlockCopy((Array)numArray, 5, (Array)iter, 0, 4);
                byte[] len = new byte[4];
                Buffer.BlockCopy((Array)numArray, 9, (Array)len, 0, 4);

                byte[] salt = new byte[16];
                Buffer.BlockCopy((Array)numArray, 13, (Array)salt, 0, 16);

                byte[] a = new byte[32];
                Buffer.BlockCopy((Array)numArray, 29, (Array)a, 0, 32);

                byte[] bytes = null;

                var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);

                bytes = rfc2898DeriveBytes.GetBytes(32);

                Console.WriteLine($"{Convert.ToBase64String(a)}\r\n{ Convert.ToBase64String(bytes)}\r\n{bytes.SequenceEqual(a)}");

                return bytes.SequenceEqual(a);
            }
            return false;
        }

        static void Main(string[] args)
        {

            if (ValidatePassword("AQAAAAEAACcQAAAAEPLWKwQelY0r+AksVRm1+9o9Oxk2SVZknKfgx8mHhUZJnFe7VHgGX1N6Ah3JnMGA/Q==", "Tepte05z$"))
            {
                Console.WriteLine("Passwords match");
            }
            else
            {
                Console.WriteLine("Passwords do not match");
            }
            //
            Console.ReadLine();
        }
    }
}
