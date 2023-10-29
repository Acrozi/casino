using System.Text;

class CasinoGame
{
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
        ForegroundColor = ConsoleColor.Yellow;
        Random random = new Random();
        Random r = new Random();
        OutputEncoding = Encoding.UTF8;
        string[] color = { "Svart", "Röd" };
        int bet = 0;
        int attempts = 0;
        int wins = 0;
        int losses = 0;
        string username = "";

        while (money != 0)
        {
            while (username == "") {
                Clear();
                WriteLine("Välkommen till Roulette");
                Write("Vänligen ange ditt namn för att gå vidare: ");
                username = ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(username)) {
                WriteLine("Du måste ange ditt namn!");
                InputBlocker inputBlocker = new InputBlocker();
                inputBlocker.BlockInputForSeconds(3);
                continue;
            } 
           }
            Clear();
            WriteLine($"\n\n>  Välkommen, {username}!  <");
            WriteLine(" -----------------------------------------      |⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯|");
            WriteLine($"  <| 3-6-9-12 | 15-18-21-24 | 27-30-33-36 |>    | Förluster: {losses} |");
            WriteLine($"0 <| 2-5-8-11 | 14-17-20-23 | 26-29-32-35 |>    | Vinster: {wins}   |");
            WriteLine($"  <| 1-4-7-10 | 13-16-19-22 | 25-28-31-34 |>    | Försök: {attempts}    |");
            WriteLine($" -----------------------------------------      | Balans: {money}$|");
            WriteLine(" -----------------------------------------      |⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯|");
            WriteLine("       | 1:a 12 | 2:a 12 | 3:a 12 |");
            WriteLine(" 1-18 | jämnt | Röd/Svart | ojämnt | 19-36 ");
            WriteLine(" -----------------------------------------\n");
            WriteLine("(a). Första 12:a | (b). Andra 12:a | (c). Tredje 12:a | (d). 1 till 18");
            WriteLine("(e). Jämnt | (f). Röd | (g). Svart | (h). Ojämnt | (i). 19 till 36\n");

            Write("Vad vill du gissa på? (skriv bokstav a-i): ");
            string choice = ReadLine().ToLower().Trim();
            string choiceDescription = GetChoiceDescription(choice);

            if (choiceDescription == "Ogiltigt val" || string.IsNullOrWhiteSpace(choice))
            {
                InputBlocker inputBlocker = new InputBlocker();
                inputBlocker.BlockInputForSeconds(3);
                continue;
            }

            bool validInput = false;

            while (!validInput)
            {
                Clear();
                WriteLine("-----------------------------------------   |⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯|");
                WriteLine($"Hur mycket vill du betta? (min: 10$)          Balans: {money}$ ");
                WriteLine("-----------------------------------------   |⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯|");
                Write("Din bet: ");

                string input = ReadLine();

                try
                {
                    bet = Convert.ToInt32(input);

                    if (bet > money || bet < 10)
                    {
                        Clear();
                        WriteLine("\n------------------------------------");
                        WriteLine("Du har inte tillräckligt med pengar eller din bet är för låg");
                        WriteLine("Tryck någon knapp för att försöka igen");
                        WriteLine("------------------------------------");
                        ReadKey();
                    }
                    else
                    {
                        validInput = true;
                    }
                }
                catch (FormatException)
                {
                    WriteLine("Du måste skriva in siffror.");
                }
            }

            if (bet > money || bet < 10)
            {
                Clear();
                WriteLine("\n------------------------------------");
                WriteLine("Du har inte tillräckligt med pengar eller din bet är för låg");
                WriteLine("Tryck någon knapp för att börja om");
                WriteLine("------------------------------------");
                ReadKey();
                Clear();
                continue;
            }
            else
            {
                money -= bet;
                int roll = random.Next(0, 37);
                string randomColor = color[r.Next(color.Length)];
                bool even = roll % 2 == 0;

                if ((choice == "a" && roll > 0 && roll < 13) ||
                    (choice == "b" && roll > 12 && roll < 25) ||
                    (choice == "c" && roll > 24 && roll < 37))
                {
                    Clear();
                    WriteLine("\nRoulette rullade klart: " + randomColor + " " + roll);
                    WriteLine("VINNARE! $" + (bet * 2));
                    WriteLine($"Ny balans {money}$");
                    WriteLine("\nTryck någon knapp för att gå vidare");
                    WriteLine($"\nDu har gissat på: {GetChoiceDescription(choice)}");
                    money += (bet * 3);
                    wins++;
                    ReadKey();
                }
                else if ((choice == "d" && roll > 1 && roll < 18) || (choice == "i" && roll > 19 && roll < 36))
                {
                    Clear();
                    WriteLine("\nRoulette rullade klart: " + randomColor + " " + roll);
                    WriteLine("VINNARE! $" + (bet * 2));
                    WriteLine($"Ny balans {money}$");
                    WriteLine("\nTryck någon knapp för att gå vidare");
                    WriteLine($"\nDu har gissat på: {GetChoiceDescription(choice)}");
                    money += (bet * 3);
                    wins++;
                    ReadKey();
                }
                else if ((choice == "e" && even) || (choice == "h" && !even))
                {
                    Clear();
                    WriteLine("\nRoulette rullade klart: " + randomColor + " " + roll);
                    WriteLine("VINNARE! $" + (bet * 2));
                    WriteLine($"Ny balans {money}$");
                    WriteLine("\nTryck någon knapp för att gå vidare");
                    WriteLine($"\nDu har gissat på: {GetChoiceDescription(choice)}");
                    money += (bet * 3);
                    wins++;
                    ReadKey();
                }
                else if ((choice == "f" && randomColor == "Röd") || (choice == "g" && randomColor == "Svart"))
                {
                    Clear();
                    WriteLine("\nRoulette rullade klart: " + randomColor + " " + roll);
                    WriteLine("VINNARE! $" + (bet * 2));
                    WriteLine($"Ny balans {money}$");
                    WriteLine("\nTryck någon knapp för att gå vidare");
                    WriteLine($"\nDu har gissat på: {GetChoiceDescription(choice)}");
                    money += (bet * 3);
                    wins++;
                    ReadKey();
                }
                else
                {
                    Clear();
                    losses++;
                    WriteLine($"\n\nDu förlorade: {bet}$");
                    WriteLine($"Det blev: {randomColor} {roll}");
                    WriteLine($"Du gissade på: {GetChoiceDescription(choice)}");
                    WriteLine($"Ny balans {money}$");
                    WriteLine("\nTryck någon knapp för att gå vidare");
                    ReadKey();
                    Clear();
                }

                attempts++;
                if (money == 0)
                {
                    WriteLine("Dina pengar tog slut. Starta om programmet.");
                    var playerData = new PlayerData { Name = username, Balance = money, Wins = wins, Losses = losses };
                    var leaderboard = new Leaderboard();
                    leaderboard.AddPlayer(playerData); // används klassen PlayerData.cs för att spara eller uppdatera info.
                    leaderboard.ShowLeaderboard();
                }
            }
        }
    }

    public class InputBlocker
    {
        public void BlockInputForSeconds(int seconds)
        {
            Clear();
            WriteLine("Du har skrivit in fel val eller input är tom. \nVänta " + seconds + " sekunder innan du fortsätter");

            DateTime start = DateTime.Now;

            while ((DateTime.Now - start).TotalSeconds < seconds) // om inte sant avbryter
            {
                if (KeyAvailable)
                {
                    var key = ReadKey(true);
                }
            }
        }
    }
    
}
