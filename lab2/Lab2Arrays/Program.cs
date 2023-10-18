using System;
using static System.Math;
using System.Linq;           //For min element
class Class2
{

    static int SumNegArraySegments(ArraySegment<int>[] value)    //Method that calculates sum of negative elements of Array segment
    {
        int sum = 0;
        foreach (var s in value)
        {
            for (int i = s.Offset; i < s.Offset + s.Count; i++)
            {
                if (s.Array[i] < 0)
                {
                    sum += s.Array[i];

                }
            }
        }
        return sum;
    }

    static int MultMaxbetwMainArrayEl(ArraySegment<int>[] value)    //for multiplying between min_value and max_value
   {
        int mult = 1;
        foreach (var s in value)
        {   
            for (int i = s.Offset; i < s.Offset + s.Count; i++)
                                mult *= s.Array[i];
        }
        return mult;
    }
    public static void Main()
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine("Welcome to OOP lab2!");
        Console.WriteLine("Here we start with ArraySegments task1:");

        //In binary array that contains N number of elements
        // 1. Calculate sum of negative elements
        
        int[] arr1 = { -1, -2, -3, 4, 5, 6, -3, -5, -9, 2, 1 };  //declaring simple array
        // Will throw if the array is empty.
        // Requires two passes over the array. 
        int minIndex = Array.IndexOf(arr1, arr1.Min());        //for multiplying between min_value and max_value
        int maxIndex = Array.IndexOf(arr1, arr1.Max());        //for multiplying between min_value and max_value
        //int diff = minIndex - maxIndex;

        var mySegmentsArray = new ArraySegment<int>[1] {//declaring array segment
                // Declaring array segments step by stepoc
                //new ArraySegment < int > ( arr1,0, arr1.Length) , //for SumNegArraySegments
                new ArraySegment < int > ( arr1, maxIndex-1, minIndex-1) }; //,s  //for multiplying between max_value and min_value           
                //new ArraySegment < int > ( arr1,2, 3 )
           

        Console.WriteLine("Array elements are: ");
        for (int i = 0; i < arr1.Length; i++)
        {
            Console.WriteLine(arr1[i] + " ");
        }
        //Console.WriteLine(" Sum of chosen negative values is : \n " + SumNegArraySegments(mySegmentsArray));
        Console.WriteLine(" Multiplying all elements between min value and max value: \n " + MultMaxbetwMainArrayEl(mySegmentsArray));
        Console.ReadLine();
    }
} 


