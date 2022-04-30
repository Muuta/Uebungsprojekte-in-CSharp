using System;
using _01Model.Neues;

namespace _01Model.Alt
{
    class Program
    {
        static void Main()
        {
            Person person = new Lehrer( "Sandra", "Hoffmann"); //{ Nachname = "Hoffmann", Vorname = "Sandra" };//Objektinitialisierer
            Person schueler = new Schueler( "Hans", "Müller");// { Nachname = "Müller", Vorname = "Hans" };
            Person lehrer = new Lehrer("Martin", "Specht");

            Person[] personen = new Person[] { person, schueler, lehrer}; //Auflistungsinitialisierer

            foreach (Person p in personen)
            {
                Console.WriteLine("Nachname: " + p.Nachname);
            }

            Console.WriteLine("Anzahl der Schüler: " + Schueler.Schuelerzaehler );
            Schueler schueler1 = new Schueler("christian", "ypsilon");
            Console.WriteLine("erwartete Ergebnis der Schüleranzahl = 2, das tasächliche: " + Schueler.Schuelerzaehler);

            //instanziiere 10 tausend schüler-objekte
            for (int i = 0; i < 10_000; i++)
            {
                new Schueler("x", "y");
            }

            Console.WriteLine(Schueler.Schuelerzaehler);
            Console.WriteLine(Person.Personenzaehler);


            Kurs kurs1 = new Kurs(capacity: 4);
            

            kurs1.AddSchueler(schueler as Schueler);
            kurs1.AddSchueler(schueler1);
            kurs1.AddSchueler(new Schueler("Michaela", "Schmidt"));
            kurs1.AddSchueler(new Schueler("Michael", "Maier"));

            Console.WriteLine("Anzahl Schüler: " + kurs1.Anzahl);
            kurs1.ShowAll();

            DateTime gestern = DateTime.Now.AddDays(-1);

            Schueler erster = kurs1.Schueler[0];
            erster.AddPruefung("Wordprüfung", gestern, 48);
            erster.AddPruefung("Datenschutzprüfung", gestern, 48);
            erster.AddPruefung("Netzwerkprüfung", DateTime.Now.AddDays(-21), 77);
            erster.ZeigePruefungen();

            erster.EntfernePruefung("Datenschutzprüfung", new DateTime(2022,3,10));
            erster.EntfernePruefung("Netzwerkprüfung", gestern);
            Pruefung geloeschtePruefung =  erster.EntfernePruefung("Datenschutzprüfung", gestern);
            if (geloeschtePruefung != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(geloeschtePruefung.ToString() + " wurde erfolgreich gelöscht");
                Console.ResetColor();
            }
            erster.ZeigePruefungen();

            Console.ReadLine();
            //Console.WriteLine("Schüler mit Id 1 wurde gelöscht :" + kurs1.EntferneSchueler(1));

            //Console.WriteLine("Schüler mit Id 100234 wurde gelöscht :" + kurs1.EntferneSchueler(100234));

        }
    }

}
