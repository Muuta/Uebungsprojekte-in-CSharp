using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Model
{
    public class Kurs
    {
        public int KursId { get; private set; }
        private static int kurszaehler = 0;

        public string Titel { get; set; } = "unbenannt";
        public DateTime Anfang { get; set; }
        //Assoziation: ein Kurs HAT mehrere Schueler
        //genauer: Aggregation - d.h. die Bestandteile (Schueler) können ohne das Ganze bestehen
        public List<Schueler> Schueler { get; set; } = new List<Schueler>();

        public int Anzahl { get { return Schueler.Count; } }
        private readonly int capacity; //maxanzahl von SChülern

        const int max = 25;
        public Kurs(int capacity = 20)
        {
            //if (capacity < max)
            //{
            //    this.capacity = capacity;
            //}
            //else
            //{
            //    this.capacity = max;
            //}
            //das gleiche mit der Math.Min-Methode
            this.capacity = Math.Min(capacity, max);
            KursId = ++kurszaehler;
        }

        public bool AddSchueler(Schueler schueler)
        {
            if (Anzahl < capacity)
            {
                if (Schueler.Contains(schueler) != true) //Wenn die Liste den Schüler NICHT enthält, dann füge hinzu
                {
                    Schueler.Add(schueler);
                    return true;
                }
                return false; //SChüler gibt es bereits

            }
            return false; // Kurs ist schon voll
        }

        public bool EntferneSchueler(Schueler schueler)
        {
            return Schueler.Remove(schueler);
        }
        public bool EntferneSchueler(int id)
        {
            for (int i = 0; i < Schueler.Count; i++)
            {
                if (Schueler[i].SchuelerId == id)
                {
                    Schueler.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void ShowAll()
        {
            Console.WriteLine($"**********{Titel} ({KursId})**************");
            foreach (Schueler schueler in Schueler)
            {
                Console.WriteLine($"{schueler.ToString()} ({schueler.SchuelerId})");
            }
            Console.WriteLine("********************************");
        }
    }
}
