using System;

using System;

namespace Taschenrechner {
    internal class Program {
        static void Main(string[] args) {

            /*
             * 
             * Thanks to David Wormuth for this Code!
             * 
             */
            bool running = true;
            bool running2 = true;
            
            do {
                running = true;
                Console.WriteLine("Wähle Operation:\n\t1) Addition + \n\t2) Subtraktion - \n\t3) Multiplikation * \n\t4) Division / \n\t5) Ganzzahlige Division mit Rest \n\t6) Prozentrechnen \n\t7) Prozentualer Anteil von 2 Zahlen \n\t8) Beenden ");
                int calcOperation = Convert.ToInt32(Console.ReadLine());
                double calcValue1;
                double calcValue2;
                double midStep1;
                double result = 0;
                switch (calcOperation) {
                    case 1:
                        Addieren(out calcValue1, out calcValue2, out result);
                        break;

                    case 2:
                        Subtrahieren(out calcValue1, out calcValue2, out result);
                        break;

                    case 3:
                        Multiplizieren(out calcValue1, out calcValue2, out result);
                        break;

                    case 4:
                        Division(out calcValue1, out calcValue2, out result);
                        break;

                    case 5:
                        do {
                            running2 = true;
                            int resultVoid;
                            Console.WriteLine("Ausgangswert?");
                            calcValue1 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Divisor?");
                            calcValue2 = Convert.ToDouble(Console.ReadLine());
                            if (calcValue2 == 0) {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Zweiter Wert darf nicht 0 sein! \n");
                                Console.ResetColor();
                            } else {
                                resultVoid = (Int32)calcValue1 / (Int32)calcValue2;
                                midStep1 = calcValue1 % calcValue2;
                                Console.WriteLine($"Die Zahl {calcValue2} passt {resultVoid} mal in die Zahl {calcValue1}. Es bleibt ein Rest von {midStep1}");
                                running2 = false;
                            }
                        } while (running2 == true);
                        break;

                    case 6:
                        ProzentRechner(out calcValue1, out calcValue2, out midStep1, out result);
                        break;

                    case 7:
                        ProzentualerAnteil(out calcValue1, out calcValue2, out midStep1, out result);
                        break;

                    case 8:
                        Console.WriteLine("Exiting...");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Bitte Wert 1 - 8 eingeben: \n");
                        break;
                }
            } while (running == true);
        }

        private static void Division(out double calcValue1, out double calcValue2, out double result) {
            Console.WriteLine("Erster Wert?");
            calcValue1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Zweiter Wert?");
            calcValue2 = Convert.ToDouble(Console.ReadLine());
            if (calcValue2 == 0) {
                Console.ForegroundColor = ConsoleColor.Red;
                result = -1;
                Console.WriteLine("Zweiter Wert darf nicht 0 sein!\n");
                Console.ResetColor();
                
                
            } else {
                result = Math.Round(calcValue1 / calcValue2, 2);
                Console.WriteLine("Ergebnis = {0} \n", result);
                bool running2 = false;
            }
        }

        private static void ProzentualerAnteil(out double calcValue1, out double calcValue2, out double midStep1, out double result) {
            Console.WriteLine("Erster Wert?");
            calcValue1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Zweiter Wert?");
            calcValue2 = Convert.ToDouble(Console.ReadLine());
            midStep1 = calcValue2 / calcValue1;
            result = Math.Round(midStep1 * 100, 2);
            Console.WriteLine($"{calcValue2} sind (gerundet auf 2 Nachkommastellen) {result}% von {calcValue1}\n");
        }

        private static void ProzentRechner(out double calcValue1, out double calcValue2, out double midStep1, out double result) {
            string sign1;
            Console.WriteLine("Ausgangswert?");
            calcValue1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Prozentsatz? \t(+ oder -\tohne \"%\")");
            calcValue2 = Convert.ToDouble(Console.ReadLine());
            midStep1 = (100 + calcValue2) / 100;
            result = calcValue1 * midStep1;
            if (calcValue2 > 0) {
                sign1 = "+";
            } else {
                sign1 = " ";
            }
            Console.WriteLine($"\t{calcValue1}\n\t{sign1}{calcValue2}%\n=\t{result}\n");
        }

        private static void Multiplizieren(out double calcValue1, out double calcValue2, out double result) {
            Console.WriteLine("Erster Wert?");
            calcValue1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Zweiter Wert?");
            calcValue2 = Convert.ToDouble(Console.ReadLine());
            result = calcValue1 * calcValue2;
            Console.WriteLine("Ergbnis = {0} \n", result);
        }

        private static void Subtrahieren(out double calcValue1, out double calcValue2, out double result) {
            Console.WriteLine("Erster Wert?");
            calcValue1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Zweiter Wert?");
            calcValue2 = Convert.ToDouble(Console.ReadLine());
            result = calcValue1 - calcValue2;
            Console.WriteLine("Ergbnis = {0} \n", result);
        }

        private static void Addieren(out double calcValue1, out double calcValue2, out double result) {
            Console.WriteLine("Erster Wert?");
            calcValue1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Zweiter Wert?");
            calcValue2 = Convert.ToDouble(Console.ReadLine());
            result = calcValue1 + calcValue2;
            Console.WriteLine("Ergbnis = {0} \n", result);
        }
    }
}
