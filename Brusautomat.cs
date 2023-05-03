using System.Reflection.Emit;

namespace Brusoppgave
{
    public class Brusautomat
    {
        private readonly List<Drikke> _utvalg;
        private int _saldo { get; set; }

        public Brusautomat()
        {
            _saldo = 0;
            _utvalg = new List<Drikke>();
        }

        public Brusautomat ØkSaldo(int mynt)
        {
            _saldo += mynt;
            Console.WriteLine($"Du la på {mynt} - ny saldo er {_saldo}");
            return this;
        }
        public Brusautomat ReturnerSaldo()
        {
            Console.WriteLine("Du fikk tilbake " + _saldo);
            _saldo = 0;
            return this;
        }

        public Brusautomat AddDrink(string navn, int pris, int antall)
        {
            var drikke = new Drikke(navn, pris, antall);
            _utvalg.Add(drikke);
            return this;
        }

        public Brusautomat ViseUtvalg(bool visPris = true, bool visLagerbeholdning = true)
        {
            var inkl = visPris | visLagerbeholdning ? "inkl." : "";
            var pris = visPris ? "pris" : "";
            var beholdning = visLagerbeholdning ? "beholdning" : "";
            var kombinert = visPris && visLagerbeholdning 
                ? $"{pris} og {beholdning}" 
                : pris + beholdning;
            var header = $"Utvalg {inkl} {kombinert}";
            Console.WriteLine(header);
            foreach (var item in _utvalg)
            {
                Console.Write("  ");
                item.Show(visPris, visLagerbeholdning);
            }

            Console.WriteLine();
            return this;
        }

        public Brusautomat BuyStuff(string navn)
        {
            var drink = FindDrink(navn);

            if (drink == null)
            {
                Console.WriteLine("Har ikke drikken");
                return this;
            }

            var pris = drink.Pris;
            if (_saldo < pris)
            {
                Console.WriteLine($"Saldo er {_saldo} - og prisen er {pris} - ikke nok!");
                return this;
            }

            _saldo -= pris;
            drink.Buy();
            return this;
        }

        private Drikke? FindDrink(string navn)
        {
            foreach (var drink in _utvalg)
            {
                if (drink.MatchesNameAndIsAvailable(navn)) return drink;
            }
            return null;
        }
    }
}
