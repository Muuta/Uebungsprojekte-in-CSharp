using DatenGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace Linq02
{
    internal class Program
    {

        static void TTT()
        {
            string xml = "<Person Id=\"500\" Vorname=\"Sophie\" Nachname=\"Maier\" Geschlecht=\"Weiblich\" />";
            XElement xelem = XElement.Parse(xml);
            Console.WriteLine("ID:" + xelem.Attribute("Id").Value);
            Console.WriteLine("Vorname:" + xelem.Attribute("Vorname").Value);
            Console.WriteLine("Nachname:" + xelem.Attribute("Nachname").Value);
            Person p = new Person()
            {
                Vorname = xelem.Attribute("Vorname").Value
            };
        }

        static string ToXml<T>(T obj)
        {
            // Reflection
            Type t = typeof(T);
            string ret = $"<{t.Name}";
            // Iteration über Eigenschaften von T
            foreach (PropertyInfo pi in t.GetRuntimeProperties())
            {
                // Vorname        =  "Hans"
                if (pi.PropertyType == typeof(DateTime))
                {
                    //    ret += $" {pi.Name}=\"{((DateTime)pi.GetValue(obj)).ToString("yyyy-MM-dd")}\"";
                    ret += $" {pi.Name}=\"{pi.GetValue(obj):yyyy-MM-dd}\"";
                }
                else
                {
                    ret += $" {pi.Name}=\"{pi.GetValue(obj)}\"";
                }
            }
            ret += "/>";
            return ret;
        }

        static void Write<T>(IEnumerable<T> l, string header = "")
        {
            Console.WriteLine("****" + header + "****");
            foreach (var elem in l)
            {
                Console.WriteLine(ToXml(elem));
            }
            Console.WriteLine("*************");
        }

        static PersonenVerwaltung pv = new PersonenVerwaltung();

        static void Test01()
        {
            // Write(pv.GetPersonen());
            var a1 = from p in pv.GetPersonen()
                     where p.Einkommen >= 140_000
                     select p;
            // Write(a1, " Einkommen > 140_000");

            var a2 = from p in pv.GetPersonen()
                     where p.Geschlecht == Geschlecht.Weiblich &&
                           p.Geburt.Year == 1980
                     select p;
            Write(a2, " Weiblich 1980");
            
            var a3 = from p in pv.GetPersonen()
                     where p.Geschlecht == Geschlecht.Weiblich &&
                           p.Geburt.Year == 1980
                     select p.Nachname;   // IEnumerable<string>
            Console.WriteLine(string.Join(", ",a3));
             
            
            var a4 = from p in pv.GetPersonen()
                     where p.Geschlecht == Geschlecht.Weiblich &&
                           p.Geburt.Year == 1980
                     select p.Nachname + ", " + p.Vorname;   // IEnumerable<string>
            Console.WriteLine(string.Join("; ", a4));

            var a5 = from p in pv.GetPersonen()
                     where p.Geschlecht == Geschlecht.Weiblich &&
                           p.Geburt.Year == 1980
                     select new { NN = p.Nachname, p.Vorname, Dummy = 42, Monatsgehalt = p.Einkommen/12 };   // IEnumerable<ANONYM>
            // Anonymen Klassen
            // Anonymen Objekten

            Write(a5, " ANONYME OBJEKTE");
        }   

        static void Test02()
        {
            // Funktionale Schreibweise
            var a1 = pv.GetPersonen().Where(x => x.Geschlecht == Geschlecht.Divers);
            
            var a1b = from x in pv.GetPersonen()
                      where x.Geschlecht == Geschlecht.Divers
                      select x;
            Write(a1, " DIVERS");

            var a2 = a1.Select(x => x.Nachname);
            Console.WriteLine(string.Join(", ", a2));
            var a3 = a1.OrderByDescending(x=> x.Einkommen).Select(x => new { x.Einkommen, x.Geburt });
            Write(a3, " EINKOMMEN UND GEBURT ");

            // Aggregation

            var count = pv.GetPersonen().Count();
            Console.WriteLine("Count: " + count);
            var min = pv.GetPersonen().Min(x=>x.Einkommen);
            Console.WriteLine("Min: " + min);
            var max = pv.GetPersonen().Max(x => x.Einkommen);
            Console.WriteLine("Max: " + max);
            var maxP = pv.GetPersonen().FirstOrDefault(x => x.Einkommen == max);
            Console.WriteLine("Höchstverdiener: " + ToXml(maxP));

            // Alle Männer aus Hamburg, die mehr als der Durchschnitt verdienen
            var avg = pv.GetPersonen().Average(x=>x.Einkommen);
            var alleStuttgart = pv.GetPersonen().Where(x=>
            x.Wohnort == "Stuttgart" && 
            x.Geschlecht == Geschlecht.Männlich &&
            x.Einkommen >= avg);
            Write(alleStuttgart, " alle Stuttgarter über dem Durchschnittsverdienst ");
            Console.WriteLine("#" + alleStuttgart.Count());
        }

        static void Test03()
        {
            var erste10 = pv.GetPersonen().Take(10);
            
            Write(erste10);
             
            
            int pProSeite = 10;
            int seite = 33;
            var x = pv.GetPersonen().Skip((seite-1)*pProSeite).Take(pProSeite);
            Write(x);

            var x2 = pv.GetPersonen().Take(10).Skip(5);
            Write(x2);

            var x3 = pv.GetPersonen().TakeWhile(x => x.Id <= 20);
            Write(x3);

        }

        static void Test04()
        {
            var x4  = pv.GetPersonen().First(x => x.Geschlecht == Geschlecht.Divers);
            var x4b = pv.GetPersonen().FirstOrDefault(x => x.Geschlecht == Geschlecht.Divers);
            Console.WriteLine("x4 " + ToXml(x4));
            Console.WriteLine("x4b " + ToXml(x4b));

            var x5 = pv.GetPersonen().Single(x => x.Id == 245);
            Console.WriteLine("x5 " + ToXml(x5));

        }

        static void Test05()
        {
            // Gruppieren
            var gruppe1b = from p in pv.GetPersonen()
                           group p by p.Wohnort 
                           into grp
                           select grp; 

            var gruppe1 = pv.GetPersonen().GroupBy(p => p.Wohnort);

            foreach(var g in gruppe1)
            {
                Console.WriteLine("Wohnort:" + g.Key);
                foreach(var p in g.Where(x=>x.Geschlecht == Geschlecht.Männlich))
                {
                    Console.WriteLine(ToXml(p));
                }
            }

            var städte_count = from p in pv.GetPersonen()
                               group p by p.Wohnort into grp
                               select new { Name = grp.Key, Anzahl = grp.Count() };
            Write(städte_count, " Städte und Anzahl EW");

        }

        static void Save()
        {
            pv.Generate(500);
            pv.Save(@"c:\temp\personen.json");
            Console.WriteLine("Daten gespeichert");
        }

        static void Main(string[] args)
        {
           pv.Load(@"c:\temp\personen.json");
           Test05();

           // "ABCD".Write("HEADER");
            
            // Save();
        }
    }
}
