using System;
using static System.Math;    //Import Math from Framework Class Library
namespace ConsoleApplication1
{
    class Class1
    {
        static double CalculateTask1(double a, double b, double c)
        {
            // Using formula from my variant
            double result = Sin(2 * a) / a - 3 + Atan(b) / c;

            return result;
        }
        public static void Main()
        {
            string name;
            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();
            if (name == "")
                Console.WriteLine("Hello, world!");
            else
                Console.WriteLine("Hello, " + name + "!");


            Console.WriteLine("Moving further to the Lab1 task1...");
            double y = CalculateTask1(2, 4, 5);
            Console.WriteLine(y);
            Console.WriteLine("Moving further to the Lab1 task2...");
            Console.ReadKey();
            
            

        }
    }
}
   