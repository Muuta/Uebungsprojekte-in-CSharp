using System;
using System.Net;
using DatenGenerator;
using System.Linq;

namespace Übung_Wetterdaten
{
    internal class Program
    {
        static Wetterdaten Wetterdaten { get; set; }

        static void Test01()
        {
            Wetterdaten.GetWetter().Write(" ALLE DATEN ");
        }
        static void Afg00()
        {
            // Wieviel Regen gab es im Jahr 2000
            var abfrage01 = from w in Wetterdaten.GetWetter()
                            where w.Jahr == 2000
                            select new { w.Jahr, w.Monat, w.Regen };
            abfrage01.Write("Aufgabe 1");
            
            var abfrage02 = Wetterdaten.GetWetter().
                Where(w => w.Jahr == 2000).
                Select(w => new { w.Jahr, w.Monat, w.Regen });
            abfrage02.Write("Aufgabe 1");

            var sumRegen = Wetterdaten.GetWetter().
                Where(w => w.Jahr == 2000).Sum(w => w.Regen);
            Console.WriteLine("Regen 2000: " + sumRegen);

        }

        static void Afg25()
        {
            // 25.In welchen Jahren gab es Monate mit gleichen Sonnenstunden?

            var abfrage01 = from w in Wetterdaten.GetWetter()
                            where w.Sonnenstunden.HasValue
                            group w by new { w.Jahr, w.Sonnenstunden } into grp
                            select new { Jahr = grp.Key.Jahr, Count = grp.Count() }
                            into grp2
                            where grp2.Count > 1
                            select grp2;

            abfrage01.Write();

            Wetterdaten.GetWetter().Where(x => x.Jahr == 1952 || x.Jahr == 1954).Write();

            var abfrage02 = from w in Wetterdaten.GetWetter()
                            where w.Sonnenstunden.HasValue
                            join x in Wetterdaten.GetWetter() 
                            on w.Jahr equals x.Jahr
                            where w.Sonnenstunden == x.Sonnenstunden &&
                                  w.Monat != x.Monat
                            select w.Jahr;
            abfrage02.Distinct().Write();

            var abfrage03 = from w in Wetterdaten.GetWetter()
                            where w.Sonnenstunden.HasValue
                            join x in Wetterdaten.GetWetter()
                            on new { w.Jahr, w.Sonnenstunden } equals new { x.Jahr, x.Sonnenstunden }
                            where w.Monat != x.Monat
                            select w.Jahr;
            abfrage03.Distinct().Write();

        }

        static void Main(string[] args)
        {
            Wetterdaten = new Wetterdaten();
            Wetterdaten.Load(@"c:\temp\wetterdaten.csv");

            //string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //Console.WriteLine(path);
            //string user = Environment.GetEnvironmentVariable("USERNAME");
            //Console.WriteLine(user);
            Afg25();
        }
    }
}
