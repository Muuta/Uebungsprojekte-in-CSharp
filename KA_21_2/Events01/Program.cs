using System;

namespace Events01
{
    internal class Program
    {
        static Uhr uhr;
        static void Main(string[] args)
        {
            uhr = new Uhr();
            uhr.ZeitGeändert += Uhr_ZeitGeändert;
            uhr.Sekunde = 100;
            uhr.Run();

            Console.WriteLine("ENDEEEEEE");
        }

        private static void Uhr_ZeitGeändert(int obj)
        {
            Console.WriteLine("Neue Zeit: " + obj);
            // System.IO.File.AppendAllText(@"test.txt", obj.ToString());
        }
    }
}
