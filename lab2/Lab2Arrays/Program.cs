using System; 
using System.Linq;  //For min element and sorting
using static System.Math;
//using Array;
          //For min element
class Class2
{

     
     private static int SumNegArraySegments(ArraySegment<int>[] value)    //Method that calculates sum of negative elements of Array segment
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
    private static int MultMaxbetwMainArrayEl(ArraySegment<int>[] value)    //for multiplying between min_value and max_value
    {
        int mult = 1;
        foreach (var s in value)
        {
            for (int i = s.Offset; i < s.Offset + s.Count; i++)
                mult *= s.Array[i];
        }
        return mult;
    }
    /*private static int SortSegmAscending(ArraySegment<int>[] value)
    {
        int sort = 0;
        ;
        return sort;
    }*/
    private static int countRowsWithoutZero(int[,] value) {
        int withourZeroRows = 4;
        for (int i = 0; i < value.GetLength(0); i++)
        {
            for (int j = 0; j < value.GetLength(1); j++)
            {
                if (value[i,j] == 0) {
                    withourZeroRows = withourZeroRows - 1;
                }
                //value[i, j] = ran.Next(0, 15);
                //Console.Write("{0}\t", rectMatrix[i, j]);
            }
            Console.WriteLine();
        }
        return withourZeroRows;
    }
    private static int defMaxValueThatSpotsMoreThanOnce(int[,] value)
    {
        int defMaxValue = 0;
        for (int i = 0; i < value.GetLength(0); i++)
        {
            for (int j = 0; j < value.GetLength(1); j++)
            {
                if (value[i,j] == Max)
                //value[i, j] = ran.Next(0, 15);
                //Console.Write("{0}\t", rectMatrix[i, j]);
            }
            Console.WriteLine();
        }
        return defMaxValue;
    }
    private static void PrintArraySegment(ArraySegment<int>[] arrSeg) {
        foreach (var s in arrSeg)
        {
            for (int i = s.Offset; i < s.Offset + s.Count; i++)
            {
                Console.WriteLine("   [{0}] : {1}", i, s.Array[i]);
            }
        }
            
        Console.WriteLine();
    }
    private static void PrintArraySegmentAsc(ArraySegment<int>[] arrSeg)
    {
        foreach (var s in arrSeg.Order())
        {
            for (int i = s.Offset; i < s.Offset + s.Count; i++)
            {
                Console.WriteLine("   [{0}] : {1}", i, s.Array[i]);
            }
        }

        Console.WriteLine();
    }

    public static void Main()
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine("Welcome to OOP lab2!");
        Console.WriteLine("Here we start with ArraySegments task1, specifically sum of negative valuse:");

        //In binary array that contains N number of elements
        // 1. Calculate sum of negative elements
        int[] arr1 = { -1, -2, -3, 4, 5, 6, -3, -5, -9, 2, 1 };  //declaring simple array
                                                                 // Will throw if the array is empty.
                                                                 // Requires two passes over the array. 

        // Declaring array segments step by step
        var myFirstSegments = new ArraySegment<int>[1]
        {
            new ArraySegment<int> (arr1, 0, arr1.Length)  //declaring array segment
        };

        int minIndex = Array.IndexOf(arr1, arr1.Min());        //for multiplying between min_value and max_value
        int maxIndex = Array.IndexOf(arr1, arr1.Max());        //for multiplying between min_value and max_value
        var mySegmentsMult = new ArraySegment<int>[1]
        {
           new ArraySegment<int>(arr1, maxIndex - 1, minIndex - 1)
        };


        /**Console.WriteLine("Array elements are: ");
        for (int i = 0; i < arr1.Length; i++) {
            Console.WriteLine(arr1[i]);
        };**/
        Console.WriteLine("Array elements: " + string.Join(", ", arr1));

        Console.WriteLine(" Sum of chosen negative values is : \n " + SumNegArraySegments(myFirstSegments));
        Console.WriteLine(" Going next to multiplication between min and max element: ");
        Console.WriteLine("Min index: " + minIndex);
        Console.WriteLine("Max index: " + maxIndex);
        Console.WriteLine(" Multiplying all elements between min value and max value: \n " + MultMaxbetwMainArrayEl(mySegmentsMult));
        //Console.WriteLine(" Sorting all elements in ascending order: \n " + SortSegmAscending(myFirstSegments));
        Console.WriteLine("The first array segment (with all the array's elements) contains:");
        PrintArraySegment(myFirstSegments);
        Console.WriteLine("Sorted array segment in an ascending order: ");
        Array.Sort(arr1);
        PrintArraySegment(myFirstSegments);
        Console.WriteLine(" input NEXT to move to the next task: ");
        string inputText = Console.ReadLine();
        
        //Console.WriteLine("Enter text for deletions:");
        //string textToRemove = Console.ReadLine();
        //textToRemove.

        //Console.WriteLine(" Sum of chosen negative values is : \n " + SumNegArraySegments(mySegmentsArray));
       //Console.WriteLine(" Multiplying all elements between min value and max value: \n " + MultMaxbetwMainArrayEl(mySegmentsArray1));
        Console.WriteLine("Going next for task2 - rectangular matrix");
        Console.WriteLine("Here it is (2D Array): ");
        int[,] rectMatrix = new int[4, 4];
        Random ran = new Random();
        for (int i = 0; i < rectMatrix.GetLength(0);  i++) 
        {
            for (int j = 0; j < rectMatrix.GetLength(1); j++)
            {
                rectMatrix[i, j] = ran.Next(0, 15);
                Console.Write("{0}\t", rectMatrix[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("Number of rows not containing any zero values : \n " + countRowsWithoutZero(rectMatrix));
        //countRowsWithoutZero(rectMatrix);

        Console.Read();
    }
}




