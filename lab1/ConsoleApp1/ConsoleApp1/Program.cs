using System;
using static System.Math;    //Import Math from Framework Class Library
namespace ConsoleApplication1
{
    class Class1
    {
        static void Main()
        {
            string name;
            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();
            if (name == "")
                System.Console.WriteLine("Hello, world!");
            else
                Console.WriteLine("Hello, " + name + "!");

            //Moving further to the Lab1 task1
            Console.WriteLine("Moving further to the Lab1 task1...");

            //But before we implement simple Read solution
            do
            {
                int i = Console.Read();
                if (i != -1)
                    Console.WriteLine("{0} {1}", (char)i, i); //Shows up entered values and their codes
                else
                    break;
            } while (true);

        }
    }
}
   