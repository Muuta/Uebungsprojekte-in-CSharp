using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace LINQ01
{

    /*
     
     def mylist():
        yield 57
        yield 58

     */
    class MyList : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            yield return 57;
            yield return 58;
            yield return 59;
            yield return 60;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class Range : IEnumerable<int>
    {
        private int start;
        private int ende;
        private int step;
        public Range(int start, int ende, int step = 1)
        {
            this.start = start;
            this.ende = ende;
            this.step = step;
        }

        // def __iter__(self):
        // def __next__
        public IEnumerator<int> GetEnumerator()
        {
            for(int i=start;i<ende; i+=step)
            {
                yield return i;
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    internal class Program
    {
        static void Test05()
        {
            foreach(int i in new Range(0,11))
            {
                Console.WriteLine(i);
            }
        }

        static void Test04()
        {
            MyList l1 = new MyList();
            foreach(int elem in l1)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine("**************");
            IEnumerator<int> enumerator = l1.GetEnumerator();
            enumerator.MoveNext();
            Console.WriteLine(enumerator.Current);
            enumerator.MoveNext();
            Console.WriteLine(enumerator.Current);
            enumerator.MoveNext();
            Console.WriteLine(enumerator.Current);
            enumerator.MoveNext();
            Console.WriteLine(enumerator.Current);


        }

        static void Write<T>(IEnumerable<T> l, string header="")
        {
            Console.WriteLine("****" + header + "****");
            Console.WriteLine(string.Join(", ",l));
            Console.WriteLine("*************");
        }

        static void Test01()
        {
            List<int> l1 = new List<int>() { 10, 30, 20, 40, 50 };
            Write(l1, "Basis");
            // Filter: Alle Zahlen zwischen 20 und 40
            // Speichern in einer neuen Liste
            List<int> r1 = new List<int>();
            for (int i = 0; i < l1.Count; i++)
            {
                if(l1[i] >=20 && l1[i] <=40)
                {
                    r1.Add(l1[i]);
                }
            }
            Write(r1, "Filter V1");
            List<int> r1b = new List<int>();
            foreach(int elem in l1)
            {
                if (elem >= 20 && elem <= 40)
                {
                    r1b.Add(elem);
                }
            }
            Write(r1b, "Filter V2");

            // SQL
            // select spalte1
            // from   tabelle
            // where  spalte1 >= 20 and spalte1 <=40


            // LINQ Language Integrated Query
            // Ausdrucks-Schreibweise
            var r1c = from x in l1
                      where x >= 20 && x <= 40
                      select x;
            // r1c ist keine LISTE!!! Sondern IEnumerable
            Write(r1c, "FILTER MIT LINQ");

            var r2 = from x in l1
                     where x <= 20
                     select x;
            Write(r2, " <=20 ");

            var r3 = from x in l1 
                     select "Wert " + x;
            // r3 : IEnumerable<string> !!!
            Write(r3, " SELECT Wert + x");

            // SORTIEREN

            var r4 = from x in l1
                     orderby x
                     select x;
            Write(r4, " ORDER ");

            var r5 = from x in l1
                     orderby x descending
                     select x;
            Write(r5, " ORDER DESC");
        }


        static void Test02()
        {
            List<string> namen = new List<string>() { "Albert", "Ida", "Cäsar", "Kurt", "Adelheid" };

            var r1 = from x in namen
                     where x.Length == 4
                     select x;
            Write(r1, " Length == 4 ");
            
            var r2 = from x in namen
                     where x.StartsWith('A')
                     //where x[0] == 'A'
                     select x;
            
            Console.WriteLine("*** 1");
            foreach(var elem in r2)
            {
                Console.WriteLine(elem);
            }


            namen.Add("Anton");
            namen.Add("Adrian");
            // Write(r2, " Erster Buchstabe A ");
            Console.WriteLine("*** 2");
            foreach (var elem in r2)
            {
                Console.WriteLine(elem);
            }



        }

        static void Test03()
        {
            List<int> l1 = new List<int>() { 1, 2, 3, 4, 5 };
            IEnumerator<int> enumerator = l1.GetEnumerator();
            while(enumerator.MoveNext())
            {
                Console.WriteLine("Element:" + enumerator.Current);
            }

            //string z = "100";
            // z.GetEnumerator();
            //foreach(var x in z)
            //{

            //}

        }
      


            static void Main(string[] args)
        {
            Test04();
        }
    }
}
