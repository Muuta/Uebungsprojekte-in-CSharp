using _01Model;
using System;


namespace _02Kursapp
{
    class Program
    {
        static void Main(string[] args)
        {
            Lehrer lehrer = new Lehrer("hans", "wimpelmoser");
            Schueler schuelerin = new Schueler("Bibi", "Blocksberg");

            Person[] personen = { lehrer, schuelerin };
            Console.WriteLine("Wir sind lauter Personen");
            foreach (var person in personen)
            {
                person.SagWas(); //polymorph
            }
            

            return;

            //Test.DemoNavigationseigenschaften();
            Menu instanz = new Menu();
            instanz.Start();

        }
    }
}
