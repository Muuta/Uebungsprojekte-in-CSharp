using System;
using System.Collections.Generic;

namespace Übung_Delegaten
{

    internal class Program
    {
        static void Main(string[] args)
        {
            List<IRun> list = new List<IRun>()
            {
                new Aufgabe1(),
                new Aufgabe2(),
                new Aufgabe3(),
                new Aufgabe4(),
                new Aufgabe5()
            };

            // Type t = typeof(Aufgabe1);
            
            foreach(IRun r in list)
            {
                Console.WriteLine("*********");
                Type t = r.GetType();
                Console.WriteLine(t.Name);
                Console.WriteLine("*********");
                r.Run();
                Console.WriteLine("*********");
            }

        }
    }
}
