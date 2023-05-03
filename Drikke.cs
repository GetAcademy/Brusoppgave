namespace Brusoppgave
{
    public class Drikke
    {
        private string _navn;
        private int _antall;
        public int Pris { get; }
        public Drikke(string navn, int pris, int antall)
        {
            _navn = navn;
            _antall = antall;
            Pris = pris;
        }

        public bool MatchesNameAndIsAvailable(string navn)
        {
            return _navn == navn && _antall > 0;
        }

        public void Show(bool visPris = true, bool visLagerbeholdning = true)
        {
            Console.Write(_navn);
            if (visPris)
            {
                Console.Write($" - koster {Pris}kr");
            }

            if (visLagerbeholdning)
            {
                Console.Write($" - {_antall} på lager");

            }
            Console.WriteLine();
        }

        public void Buy()
        {
            _antall -= 1;
            Console.WriteLine("Du har kjøpt en " +_navn);
        }
    }
}
