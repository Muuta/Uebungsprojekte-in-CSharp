using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DatenGenerator
{
    /// <summary>
    /// Wetterdaten-Klasse
    /// </summary>
    public class Wetter
    {
        public int Id { get; set; }
        public int Jahr { get; set; }
        public int Monat { get; set; }
        /// <summary>
        /// Maximale Temperatur
        /// </summary>
        public double TemperaturMax { get; set; }
        /// <summary>
        /// Minimale Temperatur
        /// </summary>
        public double TemperaturMin { get; set; }
        /// <summary>
        /// Anzahl Frosttage
        /// </summary>
        public int AnzahlFrosttage { get; set; }
        /// <summary>
        ///  Regen in mm
        /// </summary>
        public double Regen { get; set; }
        /// <summary>
        /// Sonnenstunden
        /// </summary>
        public double? Sonnenstunden { get; set; }

        public Wetter()
        {
             
        }


        /// <summary>
        /// Factory-Methode
        /// Methode zur Erzeugung eines Wetterdaten-Objekts aus 
        /// einem CSV-String
        /// ID;  yyyy;mm;tmax;tmin;af;rain; sun
        /// 1865;2008;5; 18,7;9,5; 0; 106,6;173,2
        /// </summary>
        /// <param name="csv">Kommagetrennte Eingabe</param>
        /// <returns>Wetter-Objekt</returns>
        public static Wetter Create(string csv)
        {
            Wetter w = new Wetter();
            // Split <=> Join
            // Split: String => Array
            // JOIN:  Array  => String
            // Trenner: ; , TAB
            string[] felder = csv.Split(';');
            try
            {
                w.Id = int.Parse(felder[0]);
                w.Jahr = int.Parse(felder[1]);
                w.Monat = int.Parse(felder[2]);
                w.TemperaturMax = double.Parse(felder[3]);
                w.TemperaturMin = double.Parse(felder[4]);
                w.AnzahlFrosttage = int.Parse(felder[5]);
                w.Regen = double.Parse(felder[6]);
                if(string.IsNullOrEmpty(felder[7]))
                {
                    w.Sonnenstunden = null;
                }
                else
                {
                    w.Sonnenstunden = double.Parse(felder[7]);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("******* Parse Error *******");
                Trace.WriteLine(ex.Message);
                Trace.WriteLine(csv);
                Trace.WriteLine("***************************");
            }
            return w;
        }
        public override string ToString()
        {
            return $"{Id};{Jahr};{Monat};{TemperaturMax};{TemperaturMin};{AnzahlFrosttage};{Regen};{(Sonnenstunden.HasValue ? Sonnenstunden.Value : "NICHT ERFASST")}";
        }

    }

    public class Wetterdaten
    {

        private List<Wetter> WListe { get; set; }
        public Wetterdaten()
        {
            WListe = new List<Wetter>();
        }

        public void Load(string filename)
        {
            WListe.Clear();
            using (FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using(StreamReader reader = new StreamReader(stream))
                {
                    string überschrift = reader.ReadLine(); // Überschrift lesen
                    while(!reader.EndOfStream)
                    {
                        string csv = reader.ReadLine();
                        Wetter tmp = Wetter.Create(csv);
                        WListe.Add(tmp);
                    }
                }
            }// stream.Dispose() => stream.Close()
        } 

        public IEnumerable<Wetter> GetWetter()
        {
            foreach(Wetter w in WListe)
            {
                yield return w;
            }
        }

    }



}
