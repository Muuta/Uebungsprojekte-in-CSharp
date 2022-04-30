using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Delegaten01
{
    // Funktion, Prozedur, Methode, Unterprogramm


    class Hamster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Farbe { get; set; }
        public int Alter { get; set; }
        public override string ToString()
        {
            return string.Format("Id:{0} Name:{1} Farbe:{2} Alter:{3}", Id, Name, Farbe, Alter);
        }
    }

    // Funktions-Variable
    // Funktions-Datentyp
    // Funktions-Objekt

    // int - Variable
    // Datentyp int
    // int-Objekt (Literal)

    // Datentyp Variable   Literal(Objekt)
    // int      zahl     = 10
    // string   s        = "1000A"

    // Funktions-Datentyp => DELEGATE

    // Signatur => Tupel aus Eingabe-Parameter-Typen und Rückgabe-Typ
    // Signatur void x void
    delegate void Prozedur(); // Funktions-Datentyp mit dem Namen "Prozedur"

    // Signatur int x int x void ODER int x int => void
    delegate void Proz2(int p1, int p2); // Name: Proz2 mit Params int p1 und int p2

    delegate int Op(int p1, int p2);

    internal class Program
    {
        #region NoDelegate
        static void Dummy(Hamster h)
        {
            // h = new Hamster();
            h.Name = "Hansi";
            h.Farbe = "Rot";
            h.Alter = 19;
        }
        static bool TryParse(string s, out int zahl)
        {
            //Console.WriteLine(zahl);

            zahl = int.Parse(s);

            return true;
        }
        static void Tausche(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        // Werte/Value-Parameter
        static void Dummy(int x, int y)
        {
            x = 2;
        }
        static int Min()
        {
            return 42;
        }
        static void Test01()
        {
            int a = 1, b = 2;
            Dummy(a, b);
            Tausche(ref a, ref b);
            Hamster x = new Hamster();
            Dummy(x);

        }
        #endregion
        static void TestDelegate()
        {
            void A()
            {
                // C# in a Nutshell
                // b-ok.cc
            }

            Prozedur xyz;
            Prozedur p = new Prozedur(Test01);
            p(); // Test01 wird ausgeführt
            p = TestDelegate; // Abkürzung für p=new Prozedur(TestDelegate);
            p(); // TestDelegate wird ausgeführt
            // Funktions-Objekt als Literal
            // Lambda-Ausdruck (Funktionsausdruck)
            //   Methode ohne Namen
            xyz = () => Console.WriteLine("XYZ");
            xyz = A;

            p = () => Console.WriteLine("Hallo Welt");
            p(); // Ausführen von p
            p?.Invoke(); // Ausführen von p
            p = () =>
            {
                Console.WriteLine("A");
                Console.WriteLine("B");
            };
        }

        static void TestDelegate02()
        {
            string text = "Das ist Lambda";

            Proz2 p = (a, b) => Console.WriteLine($"{text}: {a} + {b} => {a + b}");
            p(10, 20);
            p(5, 4);

            Op op1 = (a, b) => a + b;
            Op op2 = (a, b) => { return a - b; };

            Console.WriteLine(op1(10, 20));
            Console.WriteLine(op2(20, 10));

            NMal(5, () => Console.WriteLine("TOLL"));
            NMal(6, () => Console.WriteLine());
            FuerAlle(new int[] { 1, 2, 3, 4 }, new int[] { 10, 11, 12, 13 }, (a, b) => a + b - 10);
              FuerAlle(new List<int> { 1, 2, 3, 4 }, new List<int> { 10, 11, 12, 13 }, (a, b) => a + b - 10);
              FuerAlle(new Stack<int>(new int[] { 1, 2, 3, 4 }), new Stack<int>(new int[]{ 10, 11, 12, 13 }), (a, b) => a + b - 10);
              FuerAlle(new Queue<int>(new int[] { 1, 2, 3, 4 }), new Queue<int>(new int[] { 10, 11, 12, 13 }), (a, b) => a + b - 10);
              FuerAlle(new LinkedList<int>(new int[] { 1, 2, 3, 4 }), new LinkedList<int>(new int[] { 10, 11, 12, 13 }), (a, b) => a + b - 10);
        }

        static void FuerAlle(IEnumerable<int> l1, IEnumerable<int> l2, Op op)
        {
            foreach (int a in l1)
            {
                foreach (int b in l2)
                {
                    Console.WriteLine($"{a} op {b} => {op(a, b)}");
                }
            }
        }

        static void NMal(int n, Prozedur p)
        {
            for (int i = 0; i < n; i++)
            {
                p();
            }
        }

        static void TestDelegate03()
        {
            // public delegate void Action();
            //        delegate void Prozedur();
            // public delegate void Action<T1,T2>(T1 p1, T2 p2);

            //        delegate void Proz2(int p1, int p2);
            Prozedur p = () => Console.WriteLine();
            Action a = () => Console.WriteLine();
            Proz2 p2 = (a, b) => Console.WriteLine(a + b);
            Action<int, int> a2 = (a, b) => Console.WriteLine(a + b);
            Action<string, int> a3 = (a, b) => Console.WriteLine(a + b);
            a2(10, 10);
            a3("10", 10);
            ForEach("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", (c) => Console.WriteLine($"{c} => {(int)c}"));
            ForEach("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789",
                (c) =>
                    {
                        if (c >= '0' && c <= '9') Console.WriteLine(c);
                    });

            ForEach(new int[] { 12, 13, 14 }, (x) => Console.WriteLine(x));
            ForEach(new int[] { 12, 13, 14 }, Console.WriteLine);

            List<int> l2 = new List<int>() { 65,66,67}; 
            List<int> li = new List<int>() { 12, 13, 14 };
            li.ForEach((x) => l2.Add(x));

            // delegate bool Predicate(int p1);
            List<int> l3 = li.FindAll((x) => x >= 10 && x <= 13); // Filter
            li.RemoveAll(x => x == 13); // Alle 13 aus der Liste entfernen

            string res1 = string.Join(",", l2);                     // res1 => "65,66,67"
            string res2 = string.Join(",", l2.Select( x => (char)x)); // res2 => "A,B,C"
            string res3 = string.Join(",", l2.Select( x => $"\"{(char)x}\"")); // res2 => " "A","B","C" "
        
        }

        static void ForEach<T>(IEnumerable<T> x, Action<T> a)
        {
            foreach (T c in x)
            {
                a(c);
            }
        }

        static void Main(string[] args)
        {
            TestDelegate03();
        }
    }
}
