using System;
using System.Linq;

namespace _01Model.Alt
{
     class KursMitArray
    {
        public int KursId { get; set; }
        public DateTime Anfang { get; set; }
        //Assoziation: ein Kurs HAT mehrere Schueler
        //genauer: Aggregation - d.h. die Bestandteile (Schueler) können ohne das Ganze bestehen

        private Schueler[] _schueler;
        public Schueler[] Schueler
        {
            get { return _schueler; }
            private set
            {
                int groesse = value.Length;

                //stelle sicher, dass die Kursgröße OK
                if (groesse < min)
                {
                    _schueler = new Schueler[min];
                }
                else if (groesse > max)
                {
                    _schueler = new Schueler[max];
                }
                else //groesse valide
                {
                    _schueler = new Schueler[groesse];
                }
            }
        }// = new Schueler[10];

        //Beim Anlegen eines Kurses soll die Größe des Kurses bestimmt werden (Konstruktorparameter)
        //Kurse sollen eine Mindestgröße haben (3) und eine Maxgröße (10).
        //Setze diesen Validierungsmechanismus mit 2 statischen Feldern (Min & Max)
         const int min = 3, max = 20;
        public KursMitArray(int groesse)
        {
            Schueler = new Schueler[groesse >= 0 ? groesse : 0];
        }

        //Aggregation: Schüler kommt von außen...
        public bool AddSchueler(Schueler schueler)
        {
            //weise den Schüler einer leeren stelle zu (prüfe auf NULL)
            //methode soll true zurück geben, wenn geklappt, sonst falls (wenn voll)
            for (int i = 0; i < Schueler.Length; i++)
            {
                if (Schueler[i] == null)
                {
                    //Schüler dürfen nur einmalig vorkommen
                    for (int j = 0; j < Schueler.Length; j++)
                    {
                        if (Schueler[j] == schueler)
                        {
                            return false; // Schüler kann nicht hinzugefügt werden, weil er schon drin ist
                        }
                    }
                    Schueler[i] = schueler;
                    return true;
                }
            }
            //SCueler-Array ist bereits voll
            return false;
        }

        //todo: Schreibe eine boolean- Methode EntferneSchueler (anhand der Id)
        //Hinweis: entferne Schüler aus dem Array durch Null-Zuweisung
        public bool EntferneSchueler(int id)
        {
            for (int i = 0; i < Schueler.Length; i++)
            {
                if (Schueler[i] != null)
                {
                   if( Schueler[i].SchuelerId == id)
                    {
                        Schueler[i] = null; //überschreibe die Referenz
                        return true;
                    }
                }
            }
            return false; //Schüler mit der id wurde nicht gefunden
        }


        //Schreibe eine Methode, die sämtliche Schüler eines Kurses ausgibt (namentlich)
        public void ZeigeSchueler()
        {
            Console.WriteLine("sämtliche Schüler:");
            for (int i = 0; i < Schueler.Length; i++)
            {
                if (Schueler[i] != null)
                {
                    Console.WriteLine($"\t{Schueler[i].ToString()} ({Schueler[i].SchuelerId})");
                }
            }
        }

    }

}