using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Model.Alt
{
    public class Test
    {
        #region Eigenschaft

        private int _zahl; //Datenfeld

        public int Zahl
        {
            get { return _zahl; }
            set { _zahl = value; }
        }

        //auto-implemented property
        public int Zahl2 { get; set; }

        //public int GetZahl()
        //{
        //    return _zahl;
        //}

        //public void SetZahl(int value)
        //{
        //    _zahl = value;
        //}
        #endregion

        internal static void Referenzvergleich()
        {
            Schueler schueler1 = new Schueler("eins", "einsmann");
            Schueler schueler2 = new Schueler("zwei", "zweimann");
            bool sindGleich = schueler1 == schueler2;

            Console.WriteLine($"{schueler1.SchuelerId} ist identisch mit {schueler2.SchuelerId}: {sindGleich}");

            Schueler schueler3 = schueler1;
            sindGleich = schueler1 == schueler3;

            Console.WriteLine($"{schueler1.SchuelerId} ist identisch mit {schueler3.SchuelerId}: {sindGleich}");

        }

         public  static void DemoNavigationseigenschaften()
        {
            //Demo bidirektionale Navigation (Schüler <==> Prüfung)
            Schueler schueler = new Schueler("Hans", "Mayer");
            Pruefung pruefung = schueler.AddPruefung("Mathe", DateTime.Now.AddDays(-1), 22);

            Console.WriteLine("Navigiere von dem Schüler zur Prüfung: " + schueler.Pruefungen[0].Titel);
            Console.WriteLine("Navigiere von der Prüfung zum Schüler: " + pruefung.Schueler.Nachname);
        }
    }
}
