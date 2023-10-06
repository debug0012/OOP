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
        static void SieveOfEratosphene(int n)
        {
            bool[] prime = new bool[n + 1];
            for (int i = 0; i<=n; i++)
            {
                prime[i] = true;       // Fill prime numbers into array
            }

            for (int pr = 2;  pr*pr <= n; pr++)     // Going through Prime and Sqrt method
            {
                if (prime[pr] == true)                                                
                {
                    for (int i = pr*pr; i <= n; i += pr)   // Update Primes
                        prime[i] = false;
                }
            }                                     //
            for (int i = 2; i <= n; i++)
            {
                if (prime[i] == true)
                    Console.Write(i + " "); // Print all prime numbers
            }
        }
        static double CalcFtask3(double a, double b, double c)
        {
            double y = (2 * a - b - Sin(c)) / 5 + Abs(c);
            return y;
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
            //code to go through all Eratosphene elements
            int n = 30;
            Console.WriteLine(
                "Following are the prime numbers");
            Console.WriteLine("smaller than or equal to " + n);
            SieveOfEratosphene(n);

            Console.WriteLine(" ");
            Console.WriteLine("Moving further to the Lab1 task3...");
            //f(t, -2s, 1.17) - f(2.2, t, s-t)
            // s and t inp
            Console.WriteLine("Enter s: ");
            double s = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(s);
            Console.WriteLine("Enter t: ");
            double t = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(t);

            //f(t, -2s, 1.17)
            double y1 = CalcFtask3(t, (s * -2), 1.17);

            //f(2.2, t, s-t)
            double y2 = CalcFtask3(2.2, t, s - t);

            Console.WriteLine("Y1 result: " + y1);
            Console.WriteLine("Y2 result: " + y2);
            Console.WriteLine("Y1 - Y2 diff: ");
            double diff = y1 - y2;
            Console.WriteLine(diff);
            Console.ReadKey();
        }
    }
}
