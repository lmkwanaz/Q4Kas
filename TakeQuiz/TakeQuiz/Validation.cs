using System;
using System.Collections.Generic;
using System.Text;

namespace TakeQuiz
{
    class Validation
    {
        public List<string> Sign_Up()
        {
            List<string> inf = new List<string>();

            Console.WriteLine("please Enter your username");

            string username = Console.ReadLine();

            Console.WriteLine("please Enter your password");

            string password = Console.ReadLine();



            if (password.Length >= 8)
            {
                inf.Add(username);
                inf.Add(password);
            }
            else
            {
                throw new Exception("Password must be 8 or more characters");
            }

            return inf;
        }

        public List<string> Sign_In()
        {
            Console.WriteLine("Please sign in");

            List<string> addUser = new List<string>();

            Console.WriteLine("please Enter your username");

            String username = Console.ReadLine();

            Console.WriteLine("please Enter your password");

            string password = Console.ReadLine();


            addUser.Add(username);
            addUser.Add(password);

            return addUser;
        }

    }
}
