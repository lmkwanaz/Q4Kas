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
        static void Main(string[] args)
        {
            FakeMiddleMan pro = new FakeMiddleMan();

            Dictionary<string, int> info = new Dictionary<string, int>();

            Console.WriteLine("Sign Up? Press 1");
            Console.WriteLine("Sign in? Press 2");
            Console.WriteLine("Add admin? press 3");
            Console.WriteLine("want to delete names on file? press 4");
            int choose = Convert.ToInt32(Console.ReadLine());
    
            switch (choose) {

                case 1:
                    pro.MiddleManofSign_Up_In(choose);
                    break;
                case 2:
                    pro.MiddleManofSign_Up_In(choose);
                    break;
                case 3:
                    pro.MiddleManofSign_Up_In(choose);
                    break;
                case 4:
                    pro.MiddleManofSign_Up_In(choose);
                    break;
                default:
                    Console.WriteLine("invalid input");
                    break;
            }
        }
    }
}
