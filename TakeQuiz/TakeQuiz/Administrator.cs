using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TakeQuiz
{
    public class Administrator
    {

        public void Admin()
        {

            Hash hash = new Hash();
            Dictionary<string, string> info = new Dictionary<string, string>();
            List<string> credintials = new List<string>();
            Validation validate = new Validation();

            string path = @"C:\Users\Neo.mkwanazi\source\repos\TakeQuiz\TakeQuiz\bin\Debug\netcoreapp3.1\Cred\Admin.txt";

            if (File.Exists(path))
            {
                var logFile = File.ReadAllLines(path);
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

            var list = validate.Sign_In();
            //Console.WriteLine("Enter username");
            //string username = Console.ReadLine();
            //Console.WriteLine("Enter password");
            //string password = Console.ReadLine();
            
            //string hashedData = hash.ComputeSha256Hash1(password);
            //credintials.Add(username);
            //credintials.Add(hashedData);

            //  info = credintials.ToDictionary(x => x);

            string str0 = null;
            string str1 = null;
            foreach (string f in list) { var check = (str0 == null) ? str0 = f : str1 = f; }

            Dictionary<string, string> newDictioanry = new Dictionary<string, string>();

            newDictioanry.Add(str0, str1);

            Dictionary<string, string> anotherDictionary4Writing = new Dictionary<string, string>();

            anotherDictionary4Writing = list.ToDictionary(x => x);

            foreach (KeyValuePair<string, string> pair in newDictioanry)
            {
                if (!info.Contains(pair))
                {
                    foreach (string m in anotherDictionary4Writing.Keys)
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
                                Console.WriteLine("User has been added");
                            }
                        }
                    } 
                }
                else
                {
                    Console.WriteLine($"{pair} already exist!");
                    info.Clear();
                    newDictioanry.Clear();
                    anotherDictionary4Writing.Clear();
                   
                }
            }

            info.Clear();
            newDictioanry.Clear();
            anotherDictionary4Writing.Clear();

        }

        public void Delete()
        {

            Validation validation = new Validation();
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

            list = validation.Sign_In();
            string str0 = null;
            string str1 = null;
            foreach (string f in list) { var check = (str0 == null) ? str0 = f : str1 = f; }

            Dictionary<string, string> newDictioanry = new Dictionary<string, string>();

            newDictioanry.Add(str0, str1);

            foreach (KeyValuePair<string, string> pair in newDictioanry)
            {
                if (info.Contains(pair))
                {
                    if (File.Exists(file_path))
                    {
                        File.Delete(file_path);
                        Console.WriteLine("File Deleted");
                    }
                    else
                    {
                        Console.WriteLine("the file doesn't exists.");
                    }
                }
                else
                {
                    Console.WriteLine($"{pair} does not exist!");
                    info.Clear();
                }
            }

        }
    }
}
