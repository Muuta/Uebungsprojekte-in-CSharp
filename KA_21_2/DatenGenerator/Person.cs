using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;


namespace DatenGenerator
{

    public enum Geschlecht { Weiblich, Männlich, Divers }

    public class Person
    {
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public Geschlecht Geschlecht { get; set; }
        public DateTime Geburt { get; set; }
        public string Wohnort { get; set; }
        public decimal Einkommen { get; set; }
    }

    public class PersonenVerwaltung
    {
        private static string[] vornamen_m = { "Maximilian",
"Paul"                                                     ,
"Alexander"                                                ,
"Ben"                                                      ,
"Noah"                                                     ,
"Felix"                                                    ,
"Luca"                                                     ,
"Jakob"                                                    ,
"Anton"                                                    ,
"David"                                                    ,
"Leon"                                                     ,
"Elias"                                                    ,
"Julian"                                                   ,
"Benjamin"                                                 ,
"Emil"                                                     ,
"Jonas"                                                    ,
"Jonathan"                                                 ,
"Max"                                                      ,
"Jan"                                                      ,
"Lukas"                                                    ,
"Tom"                                                      ,
"Philipp"                                                  ,
"Mats"                                                     ,
"Henri"                                                    ,
"Moritz"                                                   ,
"Johannes"
 };
        private static string[] vornamen_w = {"Sophie"   ,
"Maria"    ,
"Anna"     ,
"Mia"      ,
"Sophia"   ,
"Emma"     ,
"Emilia"   ,
"Johanna"  ,
"Charlotte",
"Katharina",
"Luisa"    ,
"Lara"     ,
"Lena"     ,
"Marlene"  ,
"Elisabeth",
"Lina"     ,
"Julia"    ,
"Clara"    ,
"Hannah"   ,
"Laura"    ,
"Leonie"   ,
"Marie"    };
        private static string[] nachnamen = { "Maier", "Müller", "Schmitt", "Schneider",
            "Schafran", "Feistenauer", "Gigler", "Husein", "Kirichenko", "Nosenko", "Omrane","Heinz", "Waltschläger",
            "Christ","Hafner","Beck"  };
        private static string[] wohnorte = { "Stuttgart","Karlsruhe","Nürnberg","Heilbronn","Berlin","Konstanz",
            "Freiburg","Ludwigsburg","Frankfurt","München","Hamm", "Dortmund", "Kiel", "Bremen" };

        private List<Person> PListe { get; set; }

        public PersonenVerwaltung()
        {
            PListe = new List<Person>();
        }

        public void Generate(int count)
        {
            string[] vornamen_d = vornamen_w.Union(vornamen_m).ToArray();
            Random rnd = new Random();
            PListe.Clear();
            for (int i = 1; i <= count; i++)
            {
                Person p = new Person();
                p.Id = i;
                int z = rnd.Next(0, 100);
                if (z <= 48)
                    p.Geschlecht = Geschlecht.Weiblich;
                else if (z <= 98)
                    p.Geschlecht = Geschlecht.Männlich;
                else
                    p.Geschlecht = Geschlecht.Divers;

                switch (p.Geschlecht)
                {
                    case Geschlecht.Weiblich:
                        p.Vorname = vornamen_w[rnd.Next(0, vornamen_w.Length)];
                        break;
                    case Geschlecht.Männlich:
                        p.Vorname = vornamen_m[rnd.Next(0, vornamen_m.Length)];
                        break;
                    case Geschlecht.Divers:
                        p.Vorname = vornamen_d[rnd.Next(0, vornamen_d.Length)];
                        break;
                }
                p.Nachname = nachnamen[rnd.Next(0, nachnamen.Length)];
                p.Wohnort = wohnorte[rnd.Next(0, wohnorte.Length)];
                z = rnd.Next(17 * 365, 90 * 365);
                p.Geburt = DateTime.Today.AddDays(-z);
                p.Einkommen = rnd.Next(1000, 12001) * 12;
                PListe.Add(p);
            }
        }
                                                       
        public void Load(string filename)              
        {
            // Text -> Objekt (Deserialisieren)
            //
            string json = File.ReadAllText(filename);
            List<Person> l = JsonSerializer.Deserialize<List<Person>>(json);
            PListe.Clear();
            PListe.AddRange(l);
        }                                              
                                                       
        public void Save(string filename)              
        {
            // Objekte -> Text (Serialisieren)                                     
            // CSV, Xml, Json, Binär
            // JsonConverter<List<Person>> converter = new JsonConverter<List<Person>>();
            string json = JsonSerializer.Serialize<List<Person>>(PListe);
            File.WriteAllText(filename, json);
        }                                              
                                                       
        public IEnumerable<Person> GetPersonen()       
        {                                              
            //  return PListe;                         
            foreach (Person p in PListe)               
            {                                          
                yield return p;                        
            }                                          
        }                                              

    }

}
