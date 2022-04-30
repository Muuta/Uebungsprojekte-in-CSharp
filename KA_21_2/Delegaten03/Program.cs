using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegaten03
{
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

    internal class Program
    {
        static List<Hamster> HListe = new List<Hamster>()
        {
            new Hamster() {Id=1,Name="Horst",Farbe="Blau",Alter=15},
            new Hamster() {Id=2,Name="Donald",Farbe="Rot",Alter=12},
            new Hamster() {Id=3,Name="Joe",Farbe="Gelb",Alter=11},
            new Hamster() {Id=4,Name="Angela",Farbe="Schwarz",Alter=14}
        };

        static void Ausgabe(IEnumerable<Hamster> hl)
        {
            foreach(Hamster h in hl)
            {
                Console.WriteLine(h);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("****** ORIGINAL ******");
            Ausgabe(HListe);
            Console.WriteLine("****** SORTIERT *******");

            // Comparison<T>
            // public delegate int Comparison<in T>(T x, T y);
            // public delegate int Comparison<Hamster>(Hamster x, Hamster y);
            // Compare liefert 0, 1 , oder -1 zurück
            // h1 == h2 => 0
            // h1 > h2  => 1
            // h1 < h2  => -1
            
            HListe.Sort((h1, h2) => 
            {
                if (h1.Alter > h2.Alter) return 1;
                else if (h1.Alter < h2.Alter) return -1;
                else return 0;
            });
            Ausgabe(HListe);

            Console.WriteLine("******** SORTIERT NACH NAME ***************");

            HListe.Sort((h1, h2) => h1.Name.CompareTo(h2.Name));
            Ausgabe(HListe);

            Console.WriteLine("******** SORTIERT NACH Farbe ***************");

            HListe.Sort((h1, h2) => h1.Farbe.CompareTo(h2.Farbe));
            Ausgabe(HListe);
        }
    }
}
