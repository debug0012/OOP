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
            Console.WriteLine("But before please enter random int number or string:");

            //But before we implement simple Read solution
            do
            {
                int i = Console.Read();
                if (i != -1)                      
                    Console.WriteLine("{0} {1}", (char)i, i); //Shows up entered values and their codes
                else
                    break;    
            } while (true);

            Console.WriteLine("Then enter random text, enter END to stop this loop: ");

            //And simple ReadLine String solution
            do
            {
                string s = Console.ReadLine();
                if (s != "END")
                    Console.WriteLine("Returned string: " + s);
                else
                    break;
            } while (true) ;

        }
    }
}
   