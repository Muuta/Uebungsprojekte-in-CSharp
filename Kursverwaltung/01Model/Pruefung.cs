using System;

namespace _01Model
{
    //Schreibe zunächst eine Klasse Note ( Ergebnis (int) & Datum, Prüfungsname)
    //Schüler soll eine Liste bekommen ("Prüfungen"), die eben eine unbestimmte Anzahl von Noten speichert
    public class Pruefung
    {
        public string Titel { get; set; }
        public DateTime Datum { get; set; }
        public int Punkte { get; set; } //0 - 100
        public Schueler Schueler { get; private set; }

        public Pruefung(string titel, DateTime datum, int punkte, Schueler schueler)
        {
            Titel = titel;
            Datum = datum;
            Punkte = punkte;
            Schueler = schueler;
        }

        public override string ToString()
        {
            return $"'{Titel}': {Punkte} ({Datum.ToShortDateString()})";
        }

    }
}
