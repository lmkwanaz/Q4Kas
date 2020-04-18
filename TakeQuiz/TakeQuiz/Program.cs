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

        public void Study()
        {

            Dictionary<string, string> info = new Dictionary<string, string>();
            List<string> ch = new List<string>();

            string file_path = @"C:\Users\Neo.mkwanazi\source\repos\TakeQuiz\TakeQuiz\bin\Debug\netcoreapp3.1\Cred\Questions.txt";

            if (File.Exists(file_path))
            {
                var logFile = File.ReadAllLines(file_path);
                var logList = new List<string>(logFile);
                string list0 = null;
                string list1 = null;

                foreach (string f in logList)
                {
                    if (list0 == null)
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
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("there's nothing in a File");
            }

            Dictionary<string, string> checkAnanswer = new Dictionary<string, string>();


            foreach(string index in info.Keys)
            {
                Console.WriteLine(index);
                string answer = Console.ReadLine();
                checkAnanswer.Add(index, answer);
               // if(info.Contains(checkAnanswer)){

            }


            foreach (KeyValuePair<string, string> pair in checkAnanswer)
            {
                if (info.Contains(pair))
                {
                    Console.WriteLine("you are correct: " + pair);
                }
                else
                {
                    info.Clear();
                    Console.WriteLine($"{pair} does not exist!");
                }
            }

        }

        public Dictionary<string, string> Questions()
        {
            Dictionary<string, string> question = new Dictionary<string, string>();
            List<string> TakeasList = new List<string>();

            Console.WriteLine("how many question do you want to write? please provide answers as well..");
            Console.WriteLine("or you want to go Study?... press 0");
            int NoofQuestions = Convert.ToInt32(Console.ReadLine());
           // int gotoQuestion = Convert.ToInt32(Console.ReadLine());
            //string str0 = null;
            //string str1 = null;

            if(NoofQuestions > 0)
            {
                for (int index = 0; index < NoofQuestions; index++)
                {
                    Console.WriteLine("what is the question?");
                    string first = Console.ReadLine();
                    Console.WriteLine("what is an answer?");
                    string second = Console.ReadLine();
                    //str0 = first;
                    //str1 = second;
                    TakeasList.Add(first);
                    TakeasList.Add(second);

                    question = TakeasList.ToDictionary(x => x);

                    
                    //str0 = null;
                    //str1 = null;
                }
            }else if(NoofQuestions == 0)
            {
                Program pro = new Program();
                pro.Study();
            }

            string path = @"C:\Users\Neo.mkwanazi\source\repos\TakeQuiz\TakeQuiz\bin\Debug\netcoreapp3.1\Cred\Questions.txt";

            foreach (string m in question.Keys)
            {
                if (!File.Exists(path))
                {

                    using (StreamWriter writeTofile = File.CreateText(path))
                    {

                        writeTofile.WriteLine(m);
                    }
                }
                else if (File.Exists(path))
                {
                    using (StreamWriter writeAgain = File.AppendText(path))
                    {
                        writeAgain.WriteLine(m);
                    }
                }
                else
                {
                    Console.WriteLine("the file doesn't exists.");
                }
            }
            
            return question;
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
            //List<string> ch = new List<string>();

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
                            accessToChosenNumber.Questions();
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
                    }

                }
                else if (File.Exists(path)) {
                    using (StreamWriter writeAgain = File.AppendText(path))
                    {
                        writeAgain.WriteLine(m);
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
