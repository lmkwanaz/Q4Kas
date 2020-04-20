using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace TakeQuiz
{
    class Validation
    {
        public List<string> Sign_Up()
        {

            Hash hash = new Hash();
            List<string> inf = new List<string>();

            var regex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";



             Console.WriteLine("please Enter your username");

            string username = Console.ReadLine();

            Console.WriteLine("please Enter your password");

            string password = Console.ReadLine();

            var match = Regex.Match(password, regex, RegexOptions.None);

            string hashedData = hash.ComputeSha256Hash1(password);


            if (match.Success)
            {
                inf.Add(username);
                inf.Add(hashedData);
            }
            else
            {
               Console.WriteLine("Password must be 8 or more characters with 1,upper, lower, number and special character.");
            }

            return inf;
        }

        public List<string> Sign_In()
        {
            Hash hash = new Hash();

            Console.WriteLine("Please sign in");

            List<string> addUser = new List<string>();

            Console.WriteLine("please Enter your username");

            String username = Console.ReadLine();

            Console.WriteLine("please Enter your password");

            string password = Console.ReadLine();

            string hashedData = hash.ComputeSha256Hash1(password);

            addUser.Add(username);
            addUser.Add(hashedData);

            return addUser;
        }

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

    }
}
