using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sorteringsalgoritmer
{
    class Program
    {
        static void BubbleSort(List<int> minLista) //Bubblesort
        {
            for (int i = 0; i < minLista.Count; i++)
            {
                for (int j = 0; j < minLista.Count - 1 - i; j++)
                {
                    if (minLista[j] > minLista[j + 1])
                    {
                        int temp = minLista[j];
                        minLista[j] = minLista[j + 1];
                        minLista[j + 1] = temp;
                    }
                }
            }
        }

        static void InsertionSort(List<int> minLista) //Insertionsort 
        {
            for (int i = 1; i < minLista.Count; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (minLista[j] < minLista[j - 1])
                    {
                        int temp = minLista[j - 1];
                        minLista[j - 1] = minLista[j];
                        minLista[j] = temp;
                    }
                }
            }
        }

        static void Merge(List<int> minLista, int v, int m, int h) //Mergesort 
        {
            int i, j;

            var n1 = m - v + 1;
            var n2 = h - m;

            var vänster = new int[n1];
            var höger = new int[n2];

            for (i = 0; i < n1; i++)
            {
                vänster[i] = minLista[v + i];
            }

            for (j = 0; j < n2; j++)
            {
                höger[j] = minLista[m + j + 1];
            }

            i = 0;
            j = 0;
            var k = v;

            while (i < n1 && j < n2)
            {
                if (vänster[i] <= höger[j])
                {
                    minLista[k] = vänster[i];
                    i++;
                }
                else
                {
                    minLista[k] = vänster[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                minLista[k] = vänster[i];
                i++;
                k++;
            }

            while (i < n2)
            {
                minLista[k] = höger[j];
                j++;
                k++;
            }
        }

        static void SortMerge(List<int> minLista, int v, int h) //Mergesort 
        {
            if (v < h)
            {
                int m = v + (h - v) / 2;
                SortMerge(minLista, v, m);
                SortMerge(minLista, m + 1, h);

                Merge(minLista, v, m, h);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Skriv antal slumpade tal");
            int tal = Convert.ToInt32(Console.ReadLine());

            var tallista = new List<int>();
            Random slump = new Random();

            for (int i = 0; i < tal; i++)
            {
                tallista.Add(slump.Next(tal));
            }

            var tid0 = Stopwatch.StartNew();

            Console.WriteLine("\nBubbleSort: "); //Bubblesort tid
            var tid = Stopwatch.StartNew();
            BubbleSort(tallista);
            tid.Stop();
            TimeSpan timespan = tid.Elapsed;

            Console.WriteLine("Tid: {0}m {1}s {2}ms", timespan.Minutes, timespan.Seconds, timespan.Milliseconds);


            Console.WriteLine("\nInsertionSort: "); //Insertionsort tid
            var tid2 = Stopwatch.StartNew();
            InsertionSort(tallista);
            tid2.Stop();
            TimeSpan timespan2 = tid2.Elapsed;

            Console.WriteLine("Tid: {0}m {1}s {2}ms", timespan2.Minutes, timespan2.Seconds, timespan2.Milliseconds);


            Console.WriteLine("\nMergeSort: "); // Mergesort tid
            var tid3 = Stopwatch.StartNew();
            SortMerge(tallista, 0, tallista.Count - 1);
            tid3.Stop();
            TimeSpan timespan3 = tid3.Elapsed;

            Console.WriteLine("Tid: {0}m {1}s {2}ms", timespan3.Minutes, timespan3.Seconds, timespan3.Milliseconds);
        }
    }
}