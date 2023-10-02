using System;
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

        }
    }
}
