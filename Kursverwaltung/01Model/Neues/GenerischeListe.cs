using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Model.Neues
{
    //class List
    //{
    //    private int[] array;

    //    public List(int capacity = 0)
    //    {
    //        array = new int[capacity];
    //    }

    //    public void Add(int element)
    //    {
    //        if (array.Length == 0)
    //        {
    //            array = new int[4];
    //        }

    //        bool istVoll = true;
    //        if (istVoll)
    //        {
    //            array = new int[array.Length * 2];
    //        }
    //    }

    //}


    class GenerischeListe
    {
        internal static void VglCollections()
        {
            int[] zahlen = new int[5] { 1,2,3,4,5};
            for (int i = 0; i < zahlen.Length; i++)
            {
                Console.WriteLine(zahlen[i]);
            }

            Array.Resize(ref zahlen, zahlen.Length * 2); // {1,2,3,4,5,0,0,0,0,0}

            //List von T  (T steht für Type und ist ein Platzhalter)
            // Liste wächst dynamisch (nach Bedarf: wenn voll, dann wird Kapazität verdoppelt)
            List<int> zahlenListe = new List<int>();
            List<string> worte = new List<string>(capacity: 10_000);
            Console.WriteLine("Kapazität der liste: " + zahlenListe.Capacity);

            zahlenListe.Add(1); 
            Console.WriteLine("Kapazität der liste: " + zahlenListe.Capacity);
            zahlenListe.Add(2);
            Console.WriteLine("Kapazität der liste: " + zahlenListe.Capacity);
            zahlenListe.Add(3);
            Console.WriteLine("Kapazität der liste: " + zahlenListe.Capacity);
            zahlenListe.Add(4);
            Console.WriteLine("Kapazität der liste: " + zahlenListe.Capacity);
            zahlenListe.Add(5);
            Console.WriteLine("Kapazität der liste: " + zahlenListe.Capacity);

            Console.WriteLine(zahlenListe[0]);
            zahlenListe[1] = 42;
            


            Console.WriteLine(zahlenListe[1]);
            int anzahlVonElementenListe = zahlenListe.Count;
            int letzterIndexListe = zahlenListe.Count - 1;

           
            Console.WriteLine(nameof(anzahlVonElementenListe) +": " + anzahlVonElementenListe);

            Console.WriteLine(nameof(letzterIndexListe) + ": " + letzterIndexListe);

            Console.WriteLine("Ausgabe per foreach-Schleife");
            foreach (var item in zahlenListe)
            {
                Console.WriteLine(item);
            }
            zahlenListe.Remove(42);
            //alternativ: lösche mit RemoveAt
            //int indexOf42 = zahlenListe.IndexOf(42);
            //zahlenListe.RemoveAt(indexOf42);

            Console.WriteLine("Ausgabe per For-Schleife");
            for (int i = 0; i < zahlenListe.Count; i++)
            {
                Console.WriteLine(  zahlenListe[i] + " (" + i + ")");
            }

            Console.WriteLine("Anzahl der Elemente ingesamt: " + zahlenListe.Count);
            



            List<object> objekte = new List<object>();
           
            //ArrayList: obsolet
            System.Collections.ArrayList arrayList = new System.Collections.ArrayList();
            arrayList.Add(2);
            arrayList.Add("string");
            arrayList.Add(DateTime.Now);
           
        }
    }
}
