namespace _01Model
{
    public class Lehrer : Person {
        public Lehrer(string vorname, string nachname) : base(vorname, nachname)
        {
        }

        public int LehrerId { get; set; }

        public override void SagWas()
        {
            System.Console.WriteLine($"Ich bin ein Lehrer namens {Nachname}");
        }

    }

}
