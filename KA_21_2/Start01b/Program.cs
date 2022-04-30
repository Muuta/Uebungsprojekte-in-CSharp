using System;

namespace Start01b
{
    internal class Program
    {
        static bool TryParse(string s, out int result)
        {
            try
            {
                result = int.Parse(s);
                return true;
            }
            catch
            {
                result = 0;
                return false;
            }
        }
        static void Test02()
        {
            string s = "100";
            //int.TryParse(s, out int r);
            bool ok = TryParse(s, out int r);
            if (ok)
                Console.WriteLine(r);
            else
                Console.WriteLine("FEHLER");
        }

        static void Test01()
        {
            try
            {
                string s = "100";
                // double d = 3.14;
                int zahl = int.Parse(s);
                int zahl2 = Convert.ToInt32(s);
                double d = double.Parse(s);
                Console.WriteLine($"zahl: {zahl}\nzahl2: {zahl2}");
            }
            catch
            {
                Console.WriteLine("FEHLER!!!!");
            }
        }

        static void Test03()
        {
            try
            {
                Console.WriteLine("Bitte geben Sie eine Ganzzahl ein!");
                string eingabe = Console.ReadLine();
                int zahl = int.Parse(eingabe);
                Console.WriteLine("Zahl: " + zahl);
            }
            catch(Exception ex)
            {
                Console.WriteLine("FEHLER: " + ex.Message);
                Console.WriteLine(new String('*',80));
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(DateTime.Now);
                Console.WriteLine(ex.StackTrace);
            }

        }
        static void Test04()
        {
            int i = 0;
            int j = 10 / i;
            Console.WriteLine(j);
        }


        static void Main(string[] args)
        {
            try
            {
                Test04();
                Test03();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
