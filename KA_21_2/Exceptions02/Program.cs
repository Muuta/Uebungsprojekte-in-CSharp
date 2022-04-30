using System;
using System.Runtime.Intrinsics.X86;

namespace Exceptions02
{


    internal class Program
    {
        static void Test01()
        {
            try
            {
                // throw new NullReferenceException("BLUBBBBBBB");

                // Nullable
                Nullable<int> b = null;
                int? a = null; // int ist ein Value-Datentyp!!!

                string s = null;
                // string s = "";
                // if(!string.IsNullOrEmpty(s))
                // if(s != null)
                // ?-Operator
                // ??-Operator
                // ?:-Operator (Ternär-Op)

                int j = 10;
                int i = 10 / j;

                string s2 = s.ToUpper(); // NullReference-Fehler!!!
                // throw new NullReferenceException("NullFehler");

                // string s2 = s?.ToUpper(); // ?-Op prüft auf NULL 
                /*
                  string s2 = null;
                  if(s!=null)
                    s2 = s.ToUpper();
                */
                string s3 = s ?? "NULL";
                /*
                  string s2;
                  if(s!=null)
                    s2 = s;
                  else
                    s2 = "NULL"
                */
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("DIVISION durch 0");
                Console.WriteLine(ex.Message);
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NullPointer!!!");
                Console.WriteLine(ex.Message);
                //ex.Data["Add1"] = "BLUBBB";
                throw;
                // throw new ArgumentException("DAS IST EINE NEUE EXCEPTION VOM TYP ARGUMENTEXCEPTION");
            }
            catch (Exception ex)
            {
                Console.WriteLine("FEHLER: " + ex.Message);
            }
        }
        static void Ternär()
        {
            // Excel: Wenn-Funktion
            // Wenn(A1=10;20;30) // BED; DANN; SONST
            //          Bedingung ? AUSDRUCK1 : AUSDRUCK2
            string s = null;
            string s2 = null;
            string s4 = s != null ? s : "NULL";
            /*
             string s4;
             if(s!=null)
                s4 = s
             else
                s4 = "NULL
            */
            // Console.WriteLine(s + " => " + s2);
            Console.WriteLine($"\"{s}\" => \"{s2}\"");

            int note = 3;
            Console.WriteLine((note <= 4 ? "BESTANDEN" : "DURCHGEFALLEN") + " ...");

            if (note <= 4)
            {
                Console.WriteLine("BESTANDEN");
            }
            else
            {
                Console.WriteLine("DURCHGEFALLEN");
            }

            Console.WriteLine(note <= 2 ? "GUT" : note <= 4 ? "OK" : note <= 6 ? "DURCHGEFALLEN" : "FEHLER");

            // "A" if x==10 else "B"
            // iif(x=10,"A","B")
        }

        static void Test02()
        {
            try
            {
                string s = "A1";
                int z = Convert.ToInt32(s);

            }
            catch (Exception ex)
            {
                Console.WriteLine("FEHLER BEI DER UMWANDLUNG ...");
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                Console.WriteLine("DAS IST FINALLY");
                Console.WriteLine("Der FINALLY-BLOCK wird immer ausgeführt");
            }
            Console.WriteLine("ENDE VON TEST02");
        }


        static void Main(string[] args)
        {
            try
            {
                Test02();
            }
            catch (Exception ex)
            {
                Console.WriteLine("FATALER FEHLER!!!!!");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Data["Add1"]);
            }
            Console.WriteLine("ENDE");
        }


    }
}
