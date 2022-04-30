using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Data;

namespace BubbleSort
{
    internal class Program
    {
        static void BubbleSort(int[] arr)
        {
            for (int i = 0; i <= arr.Length-2; i++)
            {
                for (int j = i+1; j <= arr.Length-1; j++)
                {
                    if(arr[i] > arr[j]) // Vergleich / Compare
                    {
                        // tausche arr[i] und arr[j]
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        static int Min(int [] arr)
        {
            //int m = 0;
            int m = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] < m)
                {
                    m = arr[i];
                }
            }
            return m;
        }
        static int Max(int[] arr)
        {
            //int m = 0;
            int m = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > m)
                {
                    m = arr[i];
                }
            }
            return m;
        }
        static int Sum(int[] arr)
        {
            int s = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                s += arr[i]; 
            }
            return s;
        }
        static bool Suche(int[] arr, int suchwert)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == suchwert)
                    return true;
            }
            return false;
        }

        static void Test2()
        {
            int[] a1 = { 5, 3, 4, 8, 7, 2 };
            int min = Min(a1);
            Console.WriteLine("Min: " + min);
            Console.WriteLine("Max: " + Max(a1));
            Console.WriteLine("Sum: " + Sum(a1));
            Console.WriteLine("Suche 8:" + Suche(a1,8));
            Console.WriteLine("Suche 9:" + Suche(a1, 9));
        }

        static void Test1()
        {
            
            // Debug.Listeners.Add(new TextWriterTraceListener(@"c:\temp\test.log"));
            Trace.Listeners.Add(new TextWriterTraceListener(@"c:\temp\test.log"));

            int[] a1 = { 5, 3, 4, 8, 7, 2 };
            Console.WriteLine("Vorher:   " + string.Join(", ", a1));

            Stopwatch w = new Stopwatch();
            w.Start();
            BubbleSort(a1);
            // Array.Sort(a1);
            w.Stop();
            // Console.WriteLine(w.ElapsedMilliseconds);
            Debug.WriteLine("TIME:" + w.ElapsedMilliseconds);
            Trace.WriteLine("TIME (Trace):" + w.ElapsedMilliseconds);
            Console.WriteLine("Sortiert: " + string.Join(", ", a1));

            //List<int> li = new List<int>();
            //li.Sort();  // QuickSort


            //BubbleSort(a1); // n*n
            //QuickSort: 1,4 * log(n)*n
        }

        static void Main(string[] args)
        {
            Test2();
        }
    }
}
