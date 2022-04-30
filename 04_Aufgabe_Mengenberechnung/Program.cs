using System;

namespace _04_Aufgabe_Mengenberechnung {
    internal class Program {
        static void Main(string[] args) {



            /*
             * Aufgabe:
             * "Wieviele Äpfel hast du gekauft?" ... Apfel kostet 0.5 Ct.
             * Wieviele Bananen hast du gekauft     Banane kostet 0.43 Ct.
             * 
             * 
             * 
             */
            double Apple;
            double applePrice;
            double Banana;
            double bananaPrice;

            Console.WriteLine("Wieviele Äpfel hast du gekauft?");
            bool isDouble = double.TryParse(Console.ReadLine(), out Apple);
            Console.WriteLine("Wie teuer waren die Äpfel pro Stück?");
            isDouble = double.TryParse(Console.ReadLine(), out applePrice);

            Console.WriteLine("Wieviele Bananen hast du gekauft?");
            isDouble = double.TryParse(Console.ReadLine(), out Banana);
            Console.WriteLine("Wie teuer waren die Bananen pro Stück?");
            isDouble = double.TryParse(Console.ReadLine(), out bananaPrice);

            double sumApples = Apple * applePrice;
            double sumBanana = Banana * bananaPrice;

            double shoppingCosts = sumApples + sumBanana;


            Console.WriteLine("Die Äpfel haben zusammen {0} € gekostet und die Bananen {1} €. Du hast {2} Cent insgesammt gezahlt.", sumApples, sumBanana, shoppingCosts);

        }
    }
}
