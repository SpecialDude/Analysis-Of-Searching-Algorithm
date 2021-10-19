using System;
using Utility;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Searching
{
    class Program
    {
        static int p = 30;
        static IDictionary<string, object> ALGORITHMS = new Dictionary<string, object>();

        static string[] NUMBERING = {"I", "II", "III", "IV"};

        static int step = 0;
        

        static void Main(string[] args)
        {
            // Searching Algorithm Implementation & Analysis
            Console.WriteLine("\t\t\tBINARY AND TENARY SEARCHING ALGORITHMS ANALYSIS");

            Console.WriteLine("\n\n");
            
            Console.WriteLine("STEP " + NUMBERING[step]);
            step++;
            Console.WriteLine("Generating Random arrays of sizes 50000, 100000, 250000, 500000 and 750000 with values between 1 and 100");
            Console.WriteLine(Util.Repeat("___", p));
            
            int[] arraySizes = {50000, 100000, 250000, 500000, 750000};
            int[][] randomArrays = new int[arraySizes.Length][];

            for (int i = 0; i < arraySizes.Length; i++)
            {
                Console.WriteLine($"\tGenerating Array: Size = {arraySizes[i]}...");
                randomArrays[i] = Generator.RandomArray(arraySizes[i], 1, 100);
                Console.WriteLine("\tArray Generated!!!\n");                
            }

            Console.WriteLine(Util.Repeat("___", p));
            Console.WriteLine("\n\n ");



            string[] arrayTypes = {"Unsorted","Sorted"};
            int[] searchElement = {70, 120};
            bool sort = true;

            foreach (string arraytype in arrayTypes)
            {
                Console.WriteLine("STEP " + NUMBERING[step]);
                step++;
                Console.WriteLine($"Running the Searching Algorithm on {arraytype} arrays");
                Console.WriteLine(Util.Repeat("___", p));
                foreach(int x in searchElement)
                {
                    Console.WriteLine("\n");

                    string msg = (x == searchElement[0]) ? "Element within the Array" : "Element outside the Array";

                    Console.WriteLine($"Search Element: {x} ({msg})\n");

                    Console.WriteLine(Util.Repeat("---", p - 5));

                    ImplementAlgorithm(randomArrays, arraySizes, arraytype, x, msg, $"test(search_{x}_in_{arraytype}_Array)"); 

                    Console.WriteLine(Util.Repeat("---", p - 5));
        
                }
                Console.WriteLine(Util.Repeat("___", p));
            
                if (sort)
                {
                    Console.WriteLine("\n\n");
                    SortArrays(randomArrays);
                    sort = false;
                    Console.WriteLine("\n\n");
                }               
                
            }

            Console.WriteLine("\nEND OF PROGRAM!!!");
            

        }

        static void ImplementAlgorithm(int[][] arrays, int[] arraySizes, string arrayType,  int x, string msg, string exportFileName)
        {
            // Implementing Binary Search Algorithm
            Console.WriteLine("Implementing Binary Search...");
            double[] binarySearchTime = new double[arrays.Length];

            for (int i = 0; i < arrays.Length; i++)
            {
                binarySearchTime[i] = Run(arrays[i], x, "Binary");
            }

            Console.WriteLine(Util.Repeat("-----", 10));

            // Implementing Tenary Search Algorithm
            Console.WriteLine("Implementing Tenary Search...");
            double[] tenarySearchTime = new double[arrays.Length];

            for (int i = 0; i < arrays.Length; i++)
            {
                tenarySearchTime[i] = Run(arrays[i], x, "Tenary");
            }

            Console.WriteLine("\n");

            double[][] searchTime = {binarySearchTime, tenarySearchTime};

            GiveSummary(searchTime, arraySizes, arrayType, msg);

            ExportData(arraySizes, binarySearchTime, tenarySearchTime, exportFileName);

        }

        static double Run(int[] array, int x, string algorithm)
        {
            string tab = "\t";
            Console.WriteLine(tab + "Implementing Search");
            Console.WriteLine(tab + $"Algorithm: {algorithm}");
            Console.WriteLine(tab + $"Array Size: {array.Length}");
            Console.WriteLine(tab + $"Searching for: {x}");
            Console.WriteLine(tab + "Searching...");

            bool status;
            
            // start stopwatch
            Stopwatch watch = new Stopwatch();
            watch.Start();
            if (algorithm == "Linear")
                status = Search.Linear(array, x);
            else if (algorithm == "Binary")
                status = Search.Binary(array, x);
            else
                status = Search.Tenary(array, x);
            
            watch.Stop();
            double runtime = watch.Elapsed.TotalMilliseconds * 1000000;
            watch.Reset();
            // end stopwatch

            Console.WriteLine(tab + "Searching Completed");
            string msg = (status) ? "Element Found!!!" : "Element Not Found!!!";
            Console.WriteLine(tab + msg);
            Console.WriteLine(tab + $"Runtime: {runtime}ns");

            Console.WriteLine("\n");

            return runtime;

        }

        static void ExportData(int[] arraySizes, double[] binarySearchTime, double[] tenarySearchTime, string filename)
        {
            StreamWriter writer = new StreamWriter(filename + ".csv");

            string line1 = "," + string.Join(",", arraySizes);
            string line2 = "Binary," + string.Join(",", binarySearchTime);
            string line3 = "Tenary," + string.Join(",", tenarySearchTime);

            writer.WriteLine(line1);
            writer.WriteLine(line2);
            writer.WriteLine(line3 + "\n");
            writer.Close();

            Console.WriteLine("Data exported!!! " + filename + ".csv");
        }

        static void GiveSummary(double[][] searchTime, int[] arraySizes, string arrayType, string msg)
        {
            Console.Write("SUMMARY OF TEST: ");
            Console.WriteLine("\tRuntime(ns) of Binary and Tenary Search on " + arrayType + " arrays (for " + msg + ")\n");
            /*
            Console.WriteLine("Array Size\t" + string.Join("\t", arraySizes));
            Console.WriteLine("Binary\t\t" + string.Join("\t", searchTime[0]));
            Console.WriteLine("Tenary\t\t" + string.Join("\t", searchTime[1])); */

            Console.WriteLine("Array Size\tBinary Search Time\tTenary Search Time");

            for (int i = 0; i < arraySizes.Length; i++)
            {
                Console.WriteLine(arraySizes[i] + "\t\t\t" + (int)searchTime[0][i] + "\t\t\t" + (int)searchTime[1][i]);
            }
        }

        static void SortArrays(int[][] randomArrays)
        {
            Console.WriteLine("STEP " + NUMBERING[step]);
            step++;
            Console.WriteLine("Sorting all Arrays");
            Console.WriteLine(Util.Repeat("___", p));
            for (int i = 0; i < randomArrays.Length; i++)
            {
                int[] array = randomArrays[i];
                Array.Sort(array);

                randomArrays[i] = array;
                Console.WriteLine($"Array Size: {array.Length}");
                Console.WriteLine("Array Sorted!!!");
            }
            Console.WriteLine("All Arrays Sorted!!!");
            Console.WriteLine(Util.Repeat("___", p));
        }

        static void Test()
        {
            // arrays

            int[] array = Generator.RandomArray(40, 0, 100);
            int[] copy = new int[array.Length];

            

            array.CopyTo(copy, 0);

            Array.Sort(copy);
            

            Console.Write("Array: ");
            Util.PrintArray(array);

            Console.Write("Sorted: ");
            Util.PrintArray(copy);

            int x = 17;

            // Console.WriteLine("iBinary: " + Search.iBinary(array, x));
            // Console.WriteLine("iTenary: " + Search.iTenary(array, x));

            Console.WriteLine("\nBinary (sorted): " + Search.Binary(copy, x));
            Console.WriteLine("Tenary (sorted): " + Search.Tenary(copy, x));
        }
    }
}
