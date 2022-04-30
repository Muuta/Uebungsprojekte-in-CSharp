using System;

namespace Lotto {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");


            Lotto();
        }




        private static void Lotto() {
            //9 Lotto
            //A : User soll 6 Zahlen zwischen 1 - 49 eingeben: a) prüfe ob die Zahlen valide b) die eingegeben Zahlen müssen eindeutig sein...
            //B: 6 Zufallszahlen => Eindeutigkeit und zwischen 1 und 49
            //erzeuge zufallsObjekt. Rufe die Next-Methode auf. Übergebe die inklusive, untere Grenze und die exklusive obere Grenze
            //C: Zähle Anzahl Richtige: nutze einen Counter...


            //B
            int[] zufallsArray = new int[6];
            Random zufall = new Random();

            /*WIEDERHOLE  6 Mal
                    TUE
                         würfel und prüfe  auf Einmaligkeit
                    SOLANGE ESEineDoppelungGibt
                    Speicher (eindeutigen) Wurf in Zufallsarray   
              ENDE WIEDERHOLE
             */
            for (int i = 0; i < 6; i++) {
                bool istDoppelung;
                int wurf;
                do {
                    //prüfe, ob die Zufallswahl (Wurf) bereits vorhanden ist
                    istDoppelung = false;
                    wurf = zufall.Next(1, 50); // 1 - 49
                    for (int j = 0; j < zufallsArray.Length; j++) {
                        if (wurf == zufallsArray[j]) {
                            istDoppelung = true;
                            break;
                        }
                    }
                } while (istDoppelung == true); //Schleife wird wiederholt, wenn es eine Doppelung gibt

                zufallsArray[i] = wurf;
            }

            //testausgabe
            for (int i = 0; i < zufallsArray.Length; i++) {
                Console.WriteLine(zufallsArray[i]);
            }



            //A
            //USerArray
            /*
            WIEDERHOLE 6 mal
                    TUE
                        User Eingabe: eindeutige Zahl zwischen 1 - 49 
                    SOLANGE Eingabe nicht eindeutig oder zwischen 1 und 49
                    Fülle Userarray mit Eingabe
            ENDE WIEDERHOLE
             */

            int[] lotto = new int[6];
            for (int i = 0; i < 6; i++) //6 Runden
            {
                //user gibt 6 mal Zahl ein (zwischen 1-49)
                Console.WriteLine($"Gib Zahl {i + 1} ein (zwischen 1-49)");

                bool istZahlImBereich, istZahlEindeutig;
                int zahl = Convert.ToInt32(Console.ReadLine());
                do {

                    //a Zahlen müssen im rechten Bereich sein (1 -49)...
                    istZahlImBereich = true;
                    if (zahl < 1 || zahl > 49) {
                        istZahlImBereich = false;
                    }
                    //User soll Eingabe wiederholen SOLANGE die zahl nicht im Ok-Bereich ist
                    while (istZahlImBereich == false) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zahl muss zwischen 1 und 49 sein. Wiederhole Eingabe!");
                        zahl = Convert.ToInt32(Console.ReadLine());
                        if (zahl >= 1 && zahl <= 49) {
                            istZahlImBereich = true;
                        }
                        Console.ResetColor();
                    }
                    //b Zahlen müssen Eindeutig sein (keine Duplikate)
                    istZahlEindeutig = true;
                    for (int j = 0; j < lotto.Length; j++) {
                        if (lotto[j] == zahl) {
                            istZahlEindeutig = false;
                            break;
                        }
                    }
                    //User soll Eingabe wiederholen SOLANGE die zahl nicht eindeutig ist
                    while (istZahlEindeutig == false) {
                        istZahlEindeutig = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zahl muss eindeutig sein.");
                        zahl = Convert.ToInt32(Console.ReadLine());
                        for (int j = 0; j < lotto.Length; j++) {
                            if (lotto[j] == zahl) {
                                istZahlEindeutig = false;
                                break;
                            }
                        }
                        Console.ResetColor();
                    }

                    //nochmal auf den grünen Bereich testen
                    if (zahl < 1 || zahl > 49) {
                        istZahlImBereich = false;
                    }

                } while (istZahlEindeutig == false || istZahlImBereich == false);  // oder !(istZahlImBereich == true && istZahlImBereich == true)

                //zuweisung findet nur statt, wenn alles gültig geprüft
                lotto[i] = zahl;
            }
            //Testausgabe
            Console.WriteLine(String.Join(", ", lotto));



            //C: Zähle die Richtigen...
            int anzahlRichtige = 0;
            string dieRichtigen = "";
            //int[] dieRichtigenArray = new int[6];
            for (int outer = 0; outer < 6; outer++) {
                for (int inner = 0; inner < 6; inner++) {
                    if (zufallsArray[outer] == lotto[inner]) {
                        //dieRichtigenArray[anzahlRichtige] = lotto[inner];
                        anzahlRichtige++;
                        dieRichtigen += lotto[inner] + " ";
                        break;
                    }
                }
            }

            Console.WriteLine("Anzahl Treffer: " + anzahlRichtige);
            Console.WriteLine("\t" + dieRichtigen);

            //for (int i = 0; i < dieRichtigenArray.Length; i++)
            //{
            //    if (dieRichtigenArray[i] != 0)
            //    {
            //        Console.WriteLine(dieRichtigenArray[i]);
            //    }
            //}
        }

    }

}
