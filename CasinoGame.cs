using System;
using System.Threading;
using System.Text;

class CasinoGame
{
public class InputBlocker {
    // Metoden BlockInputForSeconds blockerar input i ett visst antal sekunder.
public void BlockInputForSeconds(int seconds)
{
    Clear(); 
    WriteLine("Du har skrivit in fel val eller input är tom. \nVänta " + seconds + " sekunder innan du fortsätter");

    DateTime start = DateTime.Now; 

    while ((DateTime.Now - start).TotalSeconds < seconds){
    if (KeyAvailable)
    {
        var key = ReadKey(true);
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
        ForegroundColor = ConsoleColor.Yellow;
        Random random = new Random();
        var r = new Random();
        OutputEncoding = Encoding.UTF8;
        string[] color = { "Svart", "Röd" };
        int bet = 0;
        int attempts = 0;
        int wins = 0;
        int losses = 0;
        string username = "";;

        while (money != 0 ) // && username == ""
        {
            Clear();
            while (username == "") {
            WriteLine("Välkommen till Roulette");
            Write("Vänligen ange ditt namn för att gå vidare: ");
            username = ReadLine()
                                  .Trim();
            }
            Clear();
            WriteLine($"\n\n                                                >  Välkommen, {username}!  <");
            WriteLine(" -----------------------------------------      |⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯|");
            WriteLine($"  <| 3-6-9-12 | 15-18-21-24 | 27-30-33-36 |>    |  Förluster: {losses}       |");
            WriteLine($"0 <| 2-5-8-11 | 14-17-20-23 | 26-29-32-35 |>    |  Vinster: {wins}         |");
            WriteLine($"  <| 1-4-7-10 | 13-16-19-22 | 25-28-31-34 |>    |  Försök: {attempts}          |");
            WriteLine($" -----------------------------------------      |  Balans: {money}$   |");
            WriteLine(" -----------------------------------------      |⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯|");
            WriteLine("       | 1:a 12 | 2:a 12 | 3:a 12 |");
            WriteLine(" 1-18 | jämnt | Röd/Svart | ojämnt | 19-36 ");
            WriteLine(" -----------------------------------------\n");

            WriteLine("(a). Första 12:a | (b). Andra 12:a | (c). Tredje 12:a | (d). 1 till 18");
            WriteLine("(e). Jämnt | (f). Röd | (g). Svart | (h). Ojämnt | (i). 19 till 36\n");

            Write("Vad vill du gissa på?(skriv bokstav a-i): ");
            string choice = ReadLine()
                                   .ToLower()
                                   .Trim();
            string choiceDescription = GetChoiceDescription(choice);
            if (choiceDescription == "Ogiltigt val" || string.IsNullOrWhiteSpace(choice)) // eller = || string.IsNullOrEmpty(choice)
            {
                InputBlocker inputBlocker = new InputBlocker();
                inputBlocker.BlockInputForSeconds(3);
                Thread.Sleep(3000);
                
            }

            bool validInput = false;
            while (!validInput) // om !validInput göra koden nedan
            {
                Clear();
                WriteLine("-----------------------------------------   |⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯|");
                WriteLine($"Hur mycket vill du betta? (min: 10$)          Balans: {money}$ ");
                WriteLine("-----------------------------------------   |⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯|");
                Write("Din bet: ");

                string input = ReadLine(); // fixa

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
                        validInput = true; // om true visa fel genom FormatException och vänta 1 sek
                    }
                }
                catch (FormatException)
                {
                    WriteLine("Du måste skriva in siffror.");
                    Thread.Sleep(1000);
                }
            }


            if (bet > money || bet < 10)
            {
                Clear();
                WriteLine("\n------------------------------------");
                WriteLine("Du har inte tillräckligt med pengar eller din bet är för låg");
                WriteLine("Tryck något knapp för att börja om");
                WriteLine("------------------------------------");
                ReadKey();
                Clear();
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
                    Clear();
                    WriteLine("\nThe roulette rolled: " + randomColor + " " + roll);
                    WriteLine("\nWINNER! $" + (bet * 2));
                    WriteLine($"Ny balans {money}$");
                    WriteLine("\nPress enter to continue");
                    WriteLine($"\nDu har gissat på: {GetChoiceDescription(choice)}");
                    money += (bet * 3);
                    wins++;
                    ReadKey();
                }
                else if ((choice == "d" && roll > 1 && roll < 18) || (choice == "i" && roll > 19 && roll < 36))
                {
                    Clear();
                    WriteLine("\nThe roulette rolled: " + randomColor + " " + roll);
                    WriteLine("\nWINNER! $" + (bet * 2));
                    WriteLine($"Ny balans {money}$");
                    WriteLine("\nPress enter to continue");
                    WriteLine($"\nDu har gissat på: {GetChoiceDescription(choice)}");
                    money += (bet * 3);
                    wins++;
                    ReadKey();
                }
                else if ((choice == "e" && even == true) || (choice == "h" && even == false))
                {
                    Clear();
                    WriteLine("\nThe roulette rolled: " + randomColor + " " + roll);
                    WriteLine("\nWINNER! $" + (bet * 2));
                    WriteLine($"Ny balans {money}$");
                    WriteLine("\nPress enter to continue");
                    WriteLine($"\nDu har gissat på: {GetChoiceDescription(choice)}");
                    money += (bet * 3);
                    wins++;
                    ReadKey();
                }
                else if ((choice == "f" && randomColor == "Red") || (choice == "g" && randomColor == "Black"))
                {
                    Clear();
                    WriteLine("\nThe roulette rolled: " + randomColor + " " + roll);
                    WriteLine("\nWINNER! $" + (bet * 2));
                    WriteLine($"Ny balans {money}$");
                    WriteLine("\nPress enter to continue");
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
                WriteLine("\nTryck något för att fortsätta. ");
                ReadKey();
                Clear();
                }
               attempts++;
               if (money == 0) {
                WriteLine("Dina pengar tog slut. Starta om programmet.");
                 var playerData = new PlayerData { Name = username, Balance = money, Wins = wins, Losses = losses };
                 var leaderboard = new Leaderboard();
                 leaderboard.AddPlayer(playerData);
                 leaderboard.ShowLeaderboard();
               }
             
            }
        }
    }
}