using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01Model;

namespace _02Kursapp
{
    class Menu
    {
         Kursrepo _repo = new Kursrepo();

        public void Start()
        {
            bool exit = false;
            do
            {
                string ausgabe = $"Lieber Sachbearbeiter, wähle aus\n\t(a) Kurse anzeigen\n\t(b) Kurs anlegen\n\t(c) Suche Schüler\n\t(x) um das Programm zu beenden";

                Console.WriteLine(ausgabe);

                string auswahl = Console.ReadLine().ToLower().Trim(); //Trim: "   a  " => "a"

                switch (auswahl)
                {
                    case "a":
                        ZeigeAlleKurse();
                        break;
                    case "b":
                        LegeKursAn();
                        break;
                    case "x":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Falsche Auswahl");
                        break;
                }

                //Schreibe eine Menufuehrung...
                // >>> Fülle ein paar Testdaten ein in Kursrepo.Initiiere 
                // >>> User soll wählen zwischen Kurs anlegen (a), Kurse anzeigen (b) (nutze ShowAll-Methode)
                if (exit) //Programm wird abbgebrochen
                {
                    goodbye();
                }
                else
                {
                    Console.WriteLine("Drücke beliebige Taste, um fortzufahren...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (!exit); //wenn exit false, dann wiederhole
        }

        private static void goodbye()
        {
            Console.Write("Programm endet");
            int timeout = 500;
            System.Threading.Thread.Sleep(timeout);
            Console.Write(".");
            System.Threading.Thread.Sleep(timeout);
            Console.Write(".");
            System.Threading.Thread.Sleep(timeout);
            Console.Write(".");
            System.Threading.Thread.Sleep(timeout);
        }

        private void LegeKursAn() //regle Userinteraktion: id,Id , Capacity, Anfang
            //todo: user soll den titel des Kurses eingeben...
        {
            Kurs kurs;

            //User (Sachbearbeiter) soll einen Kurs anlegen können
            // Id , Capacity, Anfang
            Console.WriteLine("Es wird ein Kurs angelegt...");

            bool isValidTitel = false;
            string titel = String.Empty; // ""

            do
            {
                Console.WriteLine("Gib Titel ein");
                titel = Console.ReadLine();
                if (titel.Length >= 2 && titel.Length <= 50)
                {
                    isValidTitel = true;
                }

            } while (!isValidTitel);

           
            bool isValidCapacity = false;
            int capacity = -1;
            do
            {
                Console.Clear();
                Console.WriteLine("Gib Größe für den kurs an (mind. 3)");
                isValidCapacity = Int32.TryParse(Console.ReadLine(), out capacity);
                if (capacity < 3)
                {
                    isValidCapacity = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Kapazität muss eine Zahl sein und mindestens die 3! (Drücke beliebige Taste, um fortzufahren...)");
                    Console.ResetColor();
                    Console.ReadKey();
                }

            } while (!isValidCapacity); //wiederhole wenn nicht valide



            //Setze Usereingabe mit TryParse um (+ Schleife)


            //Validiere das Anfangsdatum: darf nicht allzuweit in der Vergangenheit liegen
            bool isValidBegin;
            DateTime begin;
            do
            {
                Console.Clear();
                Console.WriteLine($"Wann beginnt der Kurs. bitte so eingeben YYYY,MM,DD");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Der Beginn muss sich in diesem Jahr befinden!");
                Console.ResetColor();
                isValidBegin = DateTime.TryParse(Console.ReadLine(), out begin);
                if (begin < DateTime.Now.AddMonths(-12))
                {
                    isValidBegin = false;
                }
            } while (isValidBegin == false);

            kurs = new Kurs(capacity)
            {
                Titel = titel,
                Anfang = begin
            };

            _repo.AddKurs(kurs);

            Console.WriteLine("Sie haben erfolgreich einen Kurs angelegt: " + kurs.KursId + " beginnt am " + kurs.Anfang.ToShortDateString());
        }

        private void ZeigeAlleKurse()
        {

            foreach (Kurs kurs in _repo.GetKurse())
            {
                kurs.ShowAll();
            }
        }
    }
}
