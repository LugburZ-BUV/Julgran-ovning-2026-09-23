using System;
using System.Collections.Generic;
using System.Text;

namespace Julgran_ovning_2026_09_23
{
    public class Julgran
    {
        // Metod för att validera användarens inmatning för granens höjd
        public static int GetJulgranHeight()
        {
            int height = 0;
            while (true)
            {
                try
                {
                    Console.Write("Ange höjden (antal rader) för din julgran: ");
                    height = int.Parse(Console.ReadLine());
                    break;
                }
                // Vid felaktig inmatning kör vi om loopen
                catch (FormatException)
                {
                    Console.WriteLine("\nFel inmatning!" +
                        "\nEndast siffror!\n");
                }
            }
            // Vi skickar tillbaka höjden
            return height;
        }

        // Metod för att skriva ut julgranen
        public static void PrintJulgran(int height, Random random)
        {
            // Bool för att se till att två "o" inte hamnar bredvid varandra
            // Vi börjar med true så att första symbolen alltid blir en *
            bool symbolWasO = true;
            // Loop för julgranen
            for (int row = 1; row <= height; row++)
            {
                // Antal mellanslag före symbolerna
                int spacers = height - row;
                // Antal symboler att skriva ut, som ett udda tal
                int amount = (row * 2) - 1;

                //while(amount > 9)
                //{
                //    spacers += 2;
                //    amount -= 4;
                //}

                // Indelar granen i sektioner så granen blir tjockare mot botten
                if (row > 4)
                {
                    // Vilken sektion vi är på som ska börja på nästa rad
                    int segment = (row - 1) / 4;
                    // Antalet mellanslag ökar efter varje ny sektion
                    spacers += segment * 2;
                    // Antalet symboler minskar vid ny sektion
                    amount -= segment * 4;

                }
                // Gör antalet mellanslag till en ända sträng
                string body = new string(' ', spacers);
                Console.Write(body);

                // Loop för att skriva ut symbolerna till granen
                for (int symbols = 0; symbols < amount; symbols++)
                {
                    // Om förra symbolen inte var random
                    if (symbolWasO == false)
                    {
                        // Chans mellan 1 och 9 att ersätta symbolen
                        if (random.Next(1, 9) == 1)
                        {
                            // Symbolen vi skriver i stället
                            Console.Write("o");
                            symbolWasO = true;
                        }
                        else
                        {   // Symbolen för granen
                            Console.Write("*");
                        }
                    }
                    else
                    {
                        // Symbolen för granen
                        Console.Write("*");
                        symbolWasO = false;
                    }
                }
                // Byter rad för nästa rad med symboler
                Console.WriteLine();
            }
        }
    }
}
