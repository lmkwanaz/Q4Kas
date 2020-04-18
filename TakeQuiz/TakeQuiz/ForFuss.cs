using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TakeQuiz
{
    class ForFuss
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

            foreach (string index in info.Keys)
            {
                Console.WriteLine(index);
                string answer = Console.ReadLine();
                checkAnanswer.Add(index, answer);
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

            if (NoofQuestions > 0)
            {
                for (int index = 0; index < NoofQuestions; index++)
                {
                    Console.WriteLine("what is the question?");
                    string first = Console.ReadLine();
                    Console.WriteLine("what is an answer?");
                    string second = Console.ReadLine();

                    TakeasList.Add(first);
                    TakeasList.Add(second);

                    question = TakeasList.ToDictionary(x => x);
                }
            }
            else if (NoofQuestions == 0)
            {
                ForFuss pro = new ForFuss();
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

    }
}
