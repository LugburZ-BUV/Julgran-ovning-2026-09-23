using System.Diagnostics.SymbolStore;

namespace Julgran_ovning_2026_09_23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            // Antalet gånger vi kör loopen med console clear på slutet
            int blink = 10;

            // Skriver ut välkomstmeddelande om programmet
            PrintGreeting(blink);

            // Höjden på granen hämtas från användaren via GetJulgranHeight().
            int height = Julgran.GetJulgranHeight();

            // Rensar konsollen så den inte hoppar upp några rader när vi "blinkar"
            Console.Clear();
            // Loop för att blinka av och på
            for (int b = 1; b <= blink; b ++)
            {
                // Metod för julgranen, height får vi 
                Julgran.PrintJulgran(height, random);
                // Vi väntar 0,5 sekunder så vi hinner se granen
                Thread.Sleep(500);
                // Sen rensar vi konsollen och genererar en ny gran
                // med nya "ljus" när loopen börjar om
                Console.Clear();
            }
            // Vi skriver ut en sista julgran så konsollen inte lämnas tom
            Julgran.PrintJulgran(height, random);
            Console.ReadKey();
        }
        // Metod för välkomstmeddelandet
        public static void PrintGreeting(int blink)
        {
            string greeting = $"""
                ------------------Julgranen------------------
                Detta program kommer att skriva ut en julgran
                baserat på höjden ni anger.
                Den kommer sedan att blinka {blink} gånger
                innan programmet avslutas.
                ---------------------------------------------
                """;
            Console.WriteLine(greeting);
        }
    }
}
