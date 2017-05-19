using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AITDNFour
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Arrays are reference types used to manage collection(s) of variables
            // Arrays are of fixed size so must be set a size when declaring and cannot be resized
            // Arrays in C# are zero bound, so the first item is always indexed by the number 0
            // Arrays can be multidimensional (x), (x, y), (x, y, z), (x, y, z, t)..... 
            // You can also have an array of array (known as a jagged array)

            // Declaing arrays
            // One dimensional
            var arrayOne = new int[10]; // so declared as [10] it has 10 positions 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
            // although the var keyword has now become a c# standard the old way of creating an array was; int[] arrayOne = new int[10]
            // Two dimensional
            var arrayTwo = new int[10, 10]; // so following on from the one dimensional array this 2d array has (10 x 10) 100 positions from [0, 0] to [9, 9]
            // Three dimensional
            var arrayThree = new int[10, 10, 10]; // this array has (10 x 10 x 10) 1000 possible positions from [0, 0, 0] to [9, 9, 9]
            // Normal arrays have a dimensional limit of 32 in .NET (more if they are jagged), this looks like
            try
            {
                var arrayThirtyOne = new int[2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
                    2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2]; // this array has (2 x 10 to the 31) 2,147,483,648 positions (2.1 billion)
                // your computer may not have enough free memory to hold this array. It will need 2.1 Gigabytes of free RAM, minimum (all zeroes and no overhead), hence the error handling
                // also the program has to be x64 (64 bit) in nature and the app.config file has to be amended to allow large objects to be included in the project.
            }
            catch (Exception ex)
            {
                Console.WriteLine("You system does not have enough memory to hold an array of this size." + "\n" + ex.Message);
            }

            try
            {
                var jaggedArray = new int[4][];
                jaggedArray[0] = new int[4];
                jaggedArray[1] = new int[4];
                jaggedArray[2] = new int[4];
                jaggedArray[3] = new int[4];
                // All of the declarations are necessary to define a jagged array. This first one declares an array which holds four arrays [4][].
                // Subsequently each array held in the intial array must be declared [0],[1],[2],[3],[4].
            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex);
            }

            int[,] array = new int[,]{ {1, 2}, {3, 4},{5, 6},{7, 8} }; // You can declare an array without explicit size as long as its contents are assigned with the declaration

            int[,] arrayEasy = {{1, 2}, {3, 4}, {5, 6}, {7, 8}}; // You can declare and assign an array even less verbosely like so

            int[,] arrayNoAssign;
            arrayNoAssign = new int[,] {{3, 2}, {4, 1}}; // You can also declare an array with assigning it, but when you do assign the array the new keyword must be used

            foreach (var number in arrayEasy) // One way of looping through every variable held in an array. It will always work through arrays like so; 0,0 - 0,1 - 1,0 - 1,1 - 2,0 - 2,1 - 3,0 - 3,1
            {
                Console.WriteLine(number);
            }

            // Another type of array in c# is the List<> but a List<> does not need to be declared with a definite size upon assignation
            var numbers = new List<int>(); // declare a new list of ints called numbers
            numbers.Add(10); // adds new number to List<> numbers
            for (int i = 1; i < 11; i++) // a for loop which uses an int i (set to 0 to start), runs until i < (is less than) 11, and adds 1 to i each iteration of the loop
            {
                numbers.Add(i * 10); // adds i * 10 to the List<> numbers so 10 for the first iterarion, 20 for the second and so on up until 100 (the last iteration run is 10 as it is the last true case for < 11)
            }

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            // You can use a plain array to initialise a List<>
            var list = new List<int>(new int[]{2, 3, 7, 11, 13});

            // You can easily clear a List<>
            list.Clear();

            // You can copy an array into a List<>
            var arrayInput = new int[] {1, 2, 5, 7, 9, 11, 13, 17};
            list = new List<int>(arrayInput);

            // You can find the index of a specific value in an array
            int index = list.IndexOf(7); // returns 2 (remember item one is position 0)
            index = list.IndexOf(122);  // returns -1 because no such entry exists

            // Lists also have other methods which plain arrays do not have like Contains, Exists, Find, Capacity and many more, so a List<> is usually preferable to a plain array except in one case
            // overhead, List<> uses more system resources than arrays do. You can mitigate this by using Capacity to set the List<> size and BinarySearch to improve search performance in large lists
            
            // The final type discussed here is the Dictionary<> type. This type is useful if an array is needed with non-ordered ids, for example
            var dict = new Dictionary<int, string>();
            dict.Add(3, "wrench");
            dict.Add(6, "spanner");
            dict.Add(8, "screwdrive");

            // This has created an array with three entries but instead of having keys of 0,1,2 they have keys of 3,6,8 as shown by the following code
            var keyInDict = new List<int>(dict.Keys);
            foreach (int key in keyInDict)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
