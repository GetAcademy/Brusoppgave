namespace Brusoppgave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Brusautomat()
                .ØkSaldo(20)
                .ØkSaldo(5)
                .ReturnerSaldo()
                .AddDrink("Solo", 25, 6)
                .AddDrink("Cola", 35, 6)
                .AddDrink("Farris", 5, 23)
                .AddDrink("Vann", 1, 1)
                .AddDrink("Øl", 75, 3)
                .AddDrink("Monster", 30, 223323)
                .ViseUtvalg(true, true)
                .ViseUtvalg(true, false)
                .ViseUtvalg(false, true)
                .ViseUtvalg(false, false)
                .ØkSaldo(5)
                .BuyStuff("Vann")
                .BuyStuff("Vann")
                .ReturnerSaldo()
                .BuyStuff("Vann")
                ;
        }
    }
}