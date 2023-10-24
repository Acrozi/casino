using System;
using System.Threading;
using System.Text;

class CasinoGame
{
public class InputBlocker
{
    // Metoden BlockInputForSeconds blockerar input i ett visst antal sekunder.
    public void BlockInputForSeconds(int seconds)
    {
        Console.Clear(); // Rensar konsolen
        Console.WriteLine("Skriv in rätt val. Vänta " + seconds + " sekunder innan du fortsätter:"); // Skriver ut ett meddelande med den angivna tiden för blockering.

        bool blockInput = true; // indikerar blockering av inmatning.
        DateTime start = DateTime.Now; // Sparar aktuell tid för att spåra blockeringens tidslängd.

        // Under tiden som det inte har gått det angivna antalet sekunder.
        while ((DateTime.Now - start).TotalSeconds < seconds)
        {
            if (blockInput && Console.KeyAvailable) // Om inmatning är blockerad && det finns tillgängliga tangenter.
            {
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true); // Läser in och ignorerar tillgängliga tangenter (utan att visa dem).
                }
                blockInput = false; // Efter första inmatningsförsöket låser vi upp inmatningen.
            }
        }
    }
}

    
    private int money;
    public CasinoGame(int initialMoney)
    {
        money = initialMoney;
    }

    private string GetChoiceDescription(string choice)
    {
        return choice switch
        {
            "a" => "Första 12:a",
            "b" => "Andra 12:a",
            "c" => "Tredje 12:a",
            "d" => "1 till 18",
            "e" => "Jämnt",
            "f" => "Röd",
            "g" => "Svart",
            "h" => "Ojämnt",
            "i" => "19 till 36",
            _ => "Ogiltigt val"
        };
    }

    public void StartGame()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Random random = new Random();
        var r = new Random();
        Console.OutputEncoding = Encoding.UTF8;
        string[] color = { "Red", "Black" };
        int bet = 0;
        int attempts = 0;
        int wins = 0;
        int losses = 0;

        while (money != 0)
        {
            Console.WriteLine("\n                                                |⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯|");
            Console.WriteLine($" -----------------------------------------      |  Förluster: {losses}    |");
            Console.WriteLine($"  <| 3-6-9-12 | 15-18-21-24 | 27-30-33-36 |>    |  Vinster: {wins}      |");
            Console.WriteLine($"0 <| 2-5-8-11 | 14-17-20-23 | 26-29-32-35 |>    |  Försök: {attempts}       |");
            Console.WriteLine($"  <| 1-4-7-10 | 13-16-19-22 | 25-28-31-34 |>    |  Pengar: {money}$   |");
            Console.WriteLine(" -----------------------------------------      |⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯|");
            Console.WriteLine("       | 1:a 12 | 2:a 12 | 3:a 12 |");
            Console.WriteLine(" 1-18 | jämnt | Röd/Svart | ojämnt | 19-36 ");
            Console.WriteLine(" -----------------------------------------\n");

            Console.WriteLine("(a). Första 12:a | (b). Andra 12:a | (c). Tredje 12:a | (d). 1 till 18");
            Console.WriteLine("(e). Jämnt | (f). Röd | (g). Svart | (h). Ojämnt | (i). 19 till 36\n");

            Console.Write("Vad vill du gissa på?(skriv bokstav a-i): ");
            string choice = Console.ReadLine().ToLower().Trim();
            string choiceDescription = GetChoiceDescription(choice);
            if (choiceDescription == "Ogiltigt val") // || string.IsNullOrEmpty(choice)
            {
                InputBlocker inputBlocker = new InputBlocker();
                inputBlocker.BlockInputForSeconds(3);
                Thread.Sleep(3000);
                continue;
            }

            bool validInput = false;
            while (!validInput) // om !validInput göra koden nedan
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------   |⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯|");
                Console.WriteLine($"Hur mycket vill du betta? (min: 10$)          Balans: {money}$ ");
                Console.WriteLine("-----------------------------------------   |⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯|");
                Console.Write("Din bet: ");

                string input = Console.ReadLine();

                try
                {
                    bet = Convert.ToInt32(input);
                    if (bet > money || bet < 10)
                    {
                        Console.Clear();
                        Console.WriteLine("\n------------------------------------");
                        Console.WriteLine("Du har inte tillräckligt med pengar eller din bet är för låg");
                        Console.WriteLine("Tryck någon knapp för att försöka igen");
                        Console.WriteLine("------------------------------------");
                        Console.ReadKey();
                    }
                    else
                    {
                        validInput = true; // om true visa fel genom FormatException och vänta 1 sek
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Du måste skriva in siffror.");
                    Thread.Sleep(1000);
                }
            }


            if (bet > money || bet < 10)
            {
                Console.Clear();
                Console.WriteLine("\n------------------------------------");
                Console.WriteLine("Du har inte tillräckligt med pengar eller din bet är för låg");
                Console.WriteLine("Tryck något knapp för att börja om");
                Console.WriteLine("------------------------------------");
                Console.ReadKey();
                Console.Clear();
                continue;
            }
            else
            {
                money -= bet;
                int roll = random.Next(0, 37);// EU roulette 0 - 36 (37 för att 0 är räknas 1)
                string randomColor = color[r.Next(color.Length)];
                bool even = roll % 2 == 0;

                if ((choice == "a" && roll > 0 && roll < 13) || 
                    (choice == "b" && roll > 12 && roll < 25) || 
                    (choice == "c" && roll > 24 && roll < 37))
                {
                    Console.WriteLine("\nThe roulette rolled: " + randomColor + " " + roll);
                    Console.WriteLine("\nWINNER! $" + (bet * 2));
                    Console.WriteLine("\nPress enter to continue");
                    Console.WriteLine($"\nDu har gissat på: {GetChoiceDescription(choice)}");
                    money += (bet * 3);
                    wins++;
                    Console.ReadKey();
                }
                else if ((choice == "d" && roll > 1 && roll < 18) || (choice == "i" && roll > 19 && roll < 36))
                {
                    Console.WriteLine("\nThe roulette rolled: " + randomColor + " " + roll);
                    Console.WriteLine("\nWINNER! $" + (bet * 2));
                    Console.WriteLine("\nPress enter to continue");
                    Console.WriteLine($"\nDu har gissat på: {GetChoiceDescription(choice)}");
                    money += (bet * 3);
                    wins++;
                    Console.ReadKey();
                }
                else if ((choice == "e" && even == true) || (choice == "h" && even == false))
                {
                    Console.WriteLine("\nThe roulette rolled: " + randomColor + " " + roll);
                    Console.WriteLine("\nWINNER! $" + (bet * 2));
                    Console.WriteLine("\nPress enter to continue");
                    Console.WriteLine($"\nDu har gissat på: {GetChoiceDescription(choice)}");
                    money += (bet * 3);
                    wins++;
                    Console.ReadKey();
                }
                else if ((choice == "f" && randomColor == "Red") || (choice == "g" && randomColor == "Black"))
                {
                    Console.WriteLine("\nThe roulette rolled: " + randomColor + " " + roll);
                    Console.WriteLine("\nWINNER! $" + (bet * 2));
                    Console.WriteLine("\nPress enter to continue");
                    Console.WriteLine($"\nDu har gissat på: {GetChoiceDescription(choice)}");
                    money += (bet * 3);
                    wins++;
                    Console.ReadKey();
                }
                else
                {
                losses++;
                WriteLine($"\nYou lost ${bet}");
                WriteLine($"Det blev: {randomColor} {roll}");
                WriteLine("Press enter to continue. ");
                WriteLine($"\nDu har gissat på: {GetChoiceDescription(choice)}");
                ReadKey();
                Clear();
                }
               attempts++;
               if (money == 0) {
                WriteLine("Dina pengar tog slut. Starta om programmet.");

               }
             
            }
        }
    }
}