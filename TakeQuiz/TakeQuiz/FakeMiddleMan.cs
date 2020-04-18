using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TakeQuiz
{
    class FakeMiddleMan
    {

        public void MiddleManofSign_Up_In(int chosenNumber)
        {

            Validation accessToChosenNumber = new Validation();
            ForFuss forKuss = new ForFuss();
            Dictionary<string, string> info = new Dictionary<string, string>();

            string file_path = @"C:\Users\Neo.mkwanazi\source\repos\TakeQuiz\TakeQuiz\bin\Debug\netcoreapp3.1\Cred\Credintial.txt";

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

            List<string> list = new List<string>();

            int num = chosenNumber;


            switch (num)
            {
                case 1:
                    list = accessToChosenNumber.Sign_Up();

                    var changeListToDictionary = list.ToDictionary(x => x);


                    foreach (string i in changeListToDictionary.Keys)
                    {
                        var check = (info.ContainsKey(i)) ? throw new Exception($"{i} already exist") : info = changeListToDictionary;
                        break;
                    }
                    break;
                case 2:
                    list = accessToChosenNumber.Sign_In();
                    string str0 = null;
                    string str1 = null;
                    foreach (string f in list) { var check = (str0 == null) ? str0 = f : str1 = f; }

                    Dictionary<string, string> newDictioanry = new Dictionary<string, string>();

                    newDictioanry.Add(str0, str1);

                    foreach (KeyValuePair<string, string> pair in newDictioanry)
                    {
                        if (info.Contains(pair))
                        {
                            forKuss.Questions();
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
        }

    }
}
