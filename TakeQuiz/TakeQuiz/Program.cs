using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Linq.Expressions;

namespace TakeQuiz
{
    class Program
    {

        public string Stay()
        {
            string s = "Hello World";
            Console.WriteLine(s);
            return s;
        }
        public List<string> Sign_Up()
        {
            List<string> inf = new List<string>();

            Console.WriteLine("please Enter your username");

            string username = Console.ReadLine();

            Console.WriteLine("please Enter your password");
           
            string password = Console.ReadLine();

            

            if(password.Length >= 8)
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

        public void MiddleManofSign_Up_In(int chosenNumber) {

            Program accessToChosenNumber = new Program();
            Dictionary<string, string> info = new Dictionary<string, string>();
            List<string> ch = new List<string>();

            string file_path = @"C:\Users\Neo.mkwanazi\source\repos\TakeQuiz\TakeQuiz\bin\Debug\netcoreapp3.1\Cred\Credintial.txt";

            if (File.Exists(file_path))
            {
                var logFile = File.ReadAllLines(file_path);
                var logList = new List<string>(logFile);
                string list0 = null;
                string list1 = null;
              
                foreach(string f in logList)
                {
                    if(list0 == null)
                    {
                        list0 = f;
                    }
                    else
                    {
                        try
                        {
                            list1 = f;
                            info.Add(list0, list1);
                            list0 = null;
                            list1 = null;
                        }catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }
           
            List<string> list = new List<string>();

            int num = chosenNumber;
           
           
            switch (num)
            {
                case 1:
                   list = accessToChosenNumber.Sign_Up();
                   
                    var changeListToDictionary =  list.ToDictionary(x => x);
                   
                    
                    foreach(string i in changeListToDictionary.Keys)
                    {
                        var check = (info.ContainsKey(i)) ? throw new Exception($"{i} already exist") : info = changeListToDictionary;
                        break;
                    }
                    break;
                case 2:
                   list = accessToChosenNumber.Sign_In();
                    string str0 = null;
                    string str1 = null;
                    foreach(string f in list) { var check = (str0 == null) ? str0 = f : str1 = f; }

                    Dictionary<string, string> newDictioanry = new Dictionary<string, string>();

                    newDictioanry.Add(str0, str1);
                  
                    foreach (KeyValuePair<string, string> pair in newDictioanry)
                    {
                        if (info.Contains(pair))
                        {       
                            accessToChosenNumber.Stay();
                            info.Clear();
                        }
                        else
                        {
                            info.Clear();
                            Console.WriteLine($"{pair} does not exist!");
                        }
                    }

                    break;
                default:
                    Console.WriteLine("invalid input");
                    break;
            }

            string path = @"C:\Users\Neo.mkwanazi\source\repos\TakeQuiz\TakeQuiz\bin\Debug\netcoreapp3.1\Cred\Credintial.txt";

            foreach (string m in info.Keys)
            {
                if (!File.Exists(path))
                {
                   
                    using (StreamWriter writeTofile = File.CreateText(path))
                    {
                    
                        writeTofile.WriteLine(m);
                        Console.WriteLine(info[m]);
                    }

                }
                else if (File.Exists(path)) {
                    using (StreamWriter writeAgain = File.AppendText(path))
                    {
                        writeAgain.WriteLine(m);
                        Console.WriteLine(info[m]);
                    }
                }
                 else
                {
                    Console.WriteLine("the file doesn't exists.");
                }
            }
        }
        static void Main(string[] args)
        {

            Program pro = new Program();
            Dictionary<string, int> info = new Dictionary<string, int>();
            Console.WriteLine("Sign Up? Press 1");
            Console.WriteLine("Sign in? Press 2");
            int choose = Convert.ToInt32(Console.ReadLine());
    
            switch (choose) {

                case 1:
                    pro.MiddleManofSign_Up_In(choose);
                    break;
                case 2:
                    pro.MiddleManofSign_Up_In(choose);
                    break;
                default:
                    Console.WriteLine("invalid input");
                    break;
            }
        }
    }
}
