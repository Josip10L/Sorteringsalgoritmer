using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace Sorteringsalgoritmer
{
    class Program
    {
        static void BubbleSort(List<int> MyList)
        {
            for (int i = 0; i < MyList.Count; i++)
            {
                for (int j = 0; j < MyList.Count - 1; j++)
                {
                    if (MyList[j] > MyList[j + 1])  //Om elementen ligger i fel ordning kollas här
                    {
                        //Byt plats på elementet på plats j med det på plats j+1
                        int temp = MyList[j];
                        MyList[j] = MyList[j + 1];
                        MyList[j + 1] = temp;
                    }
                }
            }
        }

        static void InsertionSort(List<int> MyList2)
        {
            //Gör en loop för varje tal som skall sorteras 
            //Börja på index 1 då vi kommer att titta "bakåt" i vektorn
            for (int i = 1; i < MyList2.Count; i++)
            {
                //Stega bakåt från position i ned till 1 om det behövs
                for (int j = i; j > 0; j--)
                {
                    //Jämför med talet "bakom" och se om det är större
                    if (MyList2[j] < MyList2[j - 1])
                    {
                        //Byt plats på tal
                        int tmp = MyList2[j - 1];
                        MyList2[j - 1] = MyList2[j];
                        MyList2[j] = tmp;
                    }
                    //Annars avsluta innerloopen 
                    else
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            List<int> tallista = new List<int>();

            Random slump = new Random();
            for (int i = 0; i < 100000; i++)
                tallista.Add(slump.Next(100000));

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            InsertionSort(tallista);

            stopWatch.Stop();
            Console.WriteLine("Listan är sorterad");
            Console.WriteLine("Tid: " + stopWatch.Elapsed);


        }
    }
}
