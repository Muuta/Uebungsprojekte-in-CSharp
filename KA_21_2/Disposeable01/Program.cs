using System;
using System.IO;

namespace Disposeable01
{
    class A
    {
        private static int counter = 0;
        public int Id { get; set; }
        private long[] arr;
        // Konstruktor
        public A()
        {
            Id = ++counter;
            arr = new long[10_000];
            Console.WriteLine($"CONSTRUCT A {Id}");
        }
        //Destruktor
        ~A()
        {
            Console.WriteLine($"DESTRUCT A {Id}");
        }
    }

    class B : IDisposable
    {
        private static int counter = 0;
        public int Id { get; set; }
        private long[] arr;
        // Konstruktor
        public B()
        {
            Id = ++counter;
            arr = new long[10_000];
            Console.WriteLine($"CONSTRUCT B {Id}");
        }
        public void Dispose()
        {
            Console.WriteLine($"DISPOSE B {Id}");
            GC.SuppressFinalize(this);
            // Für dieses Objekt beim Löschen nicht den Destruktor ausführen
        }
    }


    internal class Program
    {
        static void Test02()
        {
            for (int i = 0; i < 2000; i++)
            {
                Console.WriteLine($"LOOP {i}");
                // using wird bei IO, DB, oder Net-Objekten verwendet
                using (B b = new B())
                {
                    Console.WriteLine("WORK");
                } // b.Dispose();
                
                //using(FileStream fs = File.Open("abc.txt",FileMode.Create))
                //{

                //} // fs.Dispose() => fs.Close() => fs.Flush()
            }
        }
        static void Test01()
        {
            for (int i = 0; i < 2000; i++)
            {
                Console.WriteLine($"LOOP {i}");
                A a = new A();
                // GC.Collect();
                // Console.ReadKey();
            }
        }

        static void Main(string[] args)
        {
            Test02();
            Console.ReadKey();
        }
    }
}
