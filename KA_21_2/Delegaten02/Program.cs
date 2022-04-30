using System;

namespace Delegaten02
{   
    class A
    {
        private int dummy;
        public int MyProperty { get; set; }
        public void Run()
        {

        }
    }
    struct B
    {
        private int dummy;
        public int MyProperty { get; set; }
        public void Run()
        {

        }
    }
    class ProzAlsClass
    {
        public void Run()
        {

        }
    }
    enum Farbe { Rot,Grün,Blau }

    internal class Program
    {
        // class A { }
        // struct B { }
        // enum C { }


        // Funktionstyp
       
        delegate void Proz();
        delegate void ProzB(string s, int i, double d);
        delegate void ProzC(long l, int i);

        delegate int F1(int a);
        delegate string F2(double d);

        // Funktionstypen aus System
        // Action sind Prozeduren (immer void)
        // Action     => delegate void Action();
        // Action<T1> => delegate void Action<T1>(T1 p1);
        // Action<T1,T2> => delegate void Action<T1,T2>(T1 p1, T2 p2);
        // Action<T1,T2,T3> => delegate void Action<T1,T2,T3>(T1 p1, T2 p2, T3 p3);
        // Action<T1,T2,T3,T4> => delegate void Action<T1,T2,T3,T4>(T1 p1, T2 p2, T3 p3, T4 p4);
        // ....
        // Action<T1,T2,T3,T4,T5, ... ,T16> => delegate void Action<T1,T2,T3,T4,T5,...,T16>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, ..., T16 p16);

        // Func sind immer Funktionen (immer eine Rückgabe)
        // Func<out T1>               => delegate T1 Func();
        // Func<in T1, out T2>        => delegate T2 Func(T1 p1); 
        // Func<in T1, in T2, out T3> => delegate T3 Func(T1 p1, T2 p2);
        // ...

        // Predicate ist ein Funktionstyp, Rückgabe ist immer ein bool
        // Predicate<T1>              => delegate bool Predicate(T1 p1);


        static void Test(string s1)
        {
            Console.WriteLine("TEST: " + s1);
        }
        static void Main(string[] args)
        {
            // Delegate d = (Action)(() => Console.WriteLine());

            // Datentyp Variable
            int i;
            i = 10; // 10 ist ein Int-Objekt (Int-Literal)
            i = (int)10L;
            string s;
            s = "ABC"; //"ABC" String-Literal

            // Funktions-Datentyp(delegate) Funktions-Variable
            // Funktions-Datentypen sind Referenz-Typen
            System.Action<string> a;
            Action<string> b = null;
            ProzB c;
             
            a = (s) => Console.WriteLine(s); // (s) => Console.WriteLine(s) => Lambda-Ausdruck
            a("ABC");
            a = (s) =>
            {
                Console.WriteLine("LEN:" + s.Length);
                Console.WriteLine("ToLower:" + s?.ToLower());
                Console.WriteLine("ToUpper:" + s?.ToUpper());
            };
            a("ABC");
            a.Invoke("ABC");

            b = Test; // b zeigt/refernziert auf die Methode Test
            b("a");
            Test("a");
            System.Action<string> d = (s) => Console.WriteLine(s);


            Func<int> f1 = () => 42;
            f1 = () => { return 42; };
            Func<int, bool> f2 = (i) => i >= 10;
            if (f2(10))
            {
                Console.WriteLine(">=10");
            }
            Func<int, int, bool> eq = (a, b) => a == b;
            if (eq(10, 11))
            {
                Console.WriteLine("10==11");
            }
            // Events, Ereignisse

        }
    }
}
