using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TakeQuiz
{
    class ForKuss
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
                Console.WriteLine();
                Console.WriteLine("do you want to add questions? ... press 1");
                Console.WriteLine("do you want to exit? ... press 0");

                int choose = Convert.ToInt32(Console.ReadLine());

                if (choose == 1)
                {
                    ForKuss forKus = new ForKuss();
                    forKus.Questions();
                }else if (choose == 0)
                {
                    Console.WriteLine("Byeeee!!!");
                }
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
            ForKuss pro = new ForKuss();

            Console.WriteLine("1.how many question do you want to write?");
            Console.WriteLine("2. Do you want to go Study?... press 0");
            Console.WriteLine("3. Do you want to delete the questions you have already?... -1");
            
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
                pro.Study();
            }else if(NoofQuestions == -1)
            {
                pro.Delete();
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

        public void Delete()
        {
            string path = @"C:\Users\Neo.mkwanazi\source\repos\TakeQuiz\TakeQuiz\bin\Debug\netcoreapp3.1\Cred\Questions.txt";


            if (File.Exists(path))
                {
                    File.Delete(path);
                    Console.WriteLine("File Deleted");
                }
                else
                {
                    Console.WriteLine("the file doesn't exists.");
                }
            
        }

    }
}
