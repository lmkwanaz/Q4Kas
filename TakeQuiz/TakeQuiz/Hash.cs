using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TakeQuiz
{
    class Hash
    {
        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        internal string ComputeSha256Hash1(string password)
        {
            return ComputeSha256Hash(password);
        }
    }
}
