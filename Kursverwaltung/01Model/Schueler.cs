using System;
using System.Collections.Generic;

namespace _01Model
{
    //Vererbung: IST-Beziehung
    public class Schueler : Person
    {
        public int SchuelerId { get; private set; }

        public static int Schuelerzaehler { get; set; }

        //Komposition => ohne Schüler macht die Prüfung keinen Sinn
        public List<Pruefung> Pruefungen = new List<Pruefung>();

        public Schueler(string vorname, string nachname) : base(vorname, nachname)
        {
            SetzeId();
        }

        private void SetzeId()
        {
            //Nutze die statische Eigenschaft Schuelerzaehler, um bei Erstellung eines Schueler-Objekts automatisch eine (eindeutige) Id zu verleihen (auto-increment). Folglich darf die Id-Vergabe nur intern passieren 

            Schueler.Schuelerzaehler++;
            this.SchuelerId = Schueler.Schuelerzaehler;
        }

        public override string ToString()
        {
            return $"{this.Nachname}, {this.Vorname}";
        }

        //Fabrikmethode: es wird hier das Prüfungsobjekt erzeugt
        public Pruefung AddPruefung(string titel, DateTime datum, int note)
        {
            // validiere Daten (mindestens die Note soll zwischen 0 - 100 liegen)
            bool istValide = true;
            if (note < 0 || note > 100)
            {
                istValide = false;
            }
            if (String.IsNullOrEmpty(titel))
            {
                istValide = false;
            }


            Pruefung pruefung = null;

            if (istValide == true)
            {
                pruefung = new Pruefung(titel, datum, note, schueler: this);
                Pruefungen.Add(pruefung);
            }

            return pruefung;
        }

        //todo:Schreibe AUsgabeMethode für die Prüfungen  >> überschreibe ToString-Methode der Klasse Pruefung 
        public void ZeigePruefungen()
        {
            if (Pruefungen.Count == 0)
            {
                Console.WriteLine($"{Nachname} hat noch keine Prüfungsergebnisse");
            }
            else
            {
                Console.WriteLine($"{Pruefungen.Count} Prüfung(en) von {Nachname}");
                double summe = 0;
                foreach (var p in Pruefungen)
                {
                    Console.WriteLine("\t" + p.ToString());
                    summe  += p.Punkte;
                }
                double durchschnitt = summe / Pruefungen.Count;
                durchschnitt = Math.Round(durchschnitt, 2); //runde auf 2 Nachkommastellen
                Console.WriteLine("\tDurschnitt: " + durchschnitt);
            }
        }
        //Schreibe Methode EntfernePruefung (anhand titel und DateTime)
        public Pruefung EntfernePruefung(string titel, DateTime datum)
        {
            for (int i = 0; i < Pruefungen.Count; i++)
            {
                Pruefung item = Pruefungen[i];

                if (item.Titel == titel && item.Datum.ToShortDateString() == datum.ToShortDateString())
                {
                    Pruefungen.Remove(item);
                    return item;
                }
            }

            return null;
        }

        public override void SagWas()
        {
            Console.WriteLine($"Ich bin ein Schüler namens {Nachname}");
        }
    }
}
