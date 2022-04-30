
namespace _01Model
{
    public abstract class Person : object //Basisklasse
    {
        //Sezte einen Personenzählermechanismus um... (statische Eigenschaft Personenzähler)
        public static int Personenzaehler { get; set; }
        public Person()
        {
            Personenzaehler++;
        }
        public Person(string vorname, string nachname) : this()  //Konstruktoren werden nicht vererben
        {
            Vorname = vorname;
            Nachname = nachname;
        }

        public string Vorname { get; set; } //Instanzeigenschaft
        public string Nachname { get; set; }

        public abstract void SagWas(); //Erben müssen die Methode implementieren - Verpflichtung
    }

}
