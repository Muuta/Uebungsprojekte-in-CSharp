using _01Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Kursapp
{
    interface iKursRepository
    {
        void AddKurs(Kurs neu); //create
        void AddKurse(List<Kurs> kurse);

        IEnumerable<Kurs> GetKurse(); //read
        Kurs GetKursById(int id);

    }
     class Kursrepo : iKursRepository //repository >> Depot/Lager
    {
        private static List<Kurs> _liste  = new List<Kurs>();

        //statische Konstruktoren
        public Kursrepo()
        {
            //präprozessor-direktive: bedingte Kompilierung -  #if Debug => code wird nur im Debug-Modus kompiliert
#if DEBUG
            // Console.WriteLine("Debug Modus...");
            Testdaten();
#endif
        }

        public void AddKurs(Kurs neu)
        {
            _liste.Add(neu);
        }
        public void AddKurse(List<Kurs> kurse)
        {
            _liste.AddRange(kurse);
        }

        public Kurs GetKursById(int id)
        {
            throw new NotImplementedException();
        }

        //IEnumerable: eine foreach-fähige Menge (kann ein Array sein oder eine Liste)
        public IEnumerable<Kurs> GetKurse()
        {
            return _liste;
        }

        public void Testdaten()
        {
             AddKurse(
                    new List<Kurs>()
                    {
                         new Kurs(4)
                         {
                             Titel = "Projekt Management",
                             Anfang = DateTime.Now.AddDays(-300),
                             Schueler = new List<Schueler>()
                             {
                             new Schueler("Hans", "Mayer" ),
                             new Schueler("Cindarella", "Grubach"),
                             new Schueler("Michaela", "Schmidt"),
                             new Schueler("Michael", "Maier")
                             }
                         },
                        new Kurs(20)
                        {
                             Titel = "Umschulung FI",
                             Anfang = DateTime.Now.AddDays(-100),
                            Schueler = new List<Schueler>()
                            {
                                new Schueler("Heike", "Bürstner" ),
                                new Schueler("Leopold", "Friedhammer" ),
                                new Schueler("Theresa", "Warstein" ),
                                new Schueler("Methusalem", "Jungbert" ),
                                new Schueler("Martin", "Pött" )
                            }
                        },
                         new Kurs( 15)
                        {
                             Titel = "Orientierung",
                             Anfang = DateTime.Now.AddDays(-10),
                            Schueler = new List<Schueler>()
                            {
                                new Schueler("Sarah", "Wolf" ),
                                new Schueler("Friedhilde", "Hold" ),
                                new Schueler("Toni", "Kroos" ),
                                new Schueler("Sina", "Neu" )
                            }
                        }
                    }
                );
        }

       
    }
}
