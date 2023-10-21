using System;
using System.Threading;
using System.Text;

class CasinoGame
{

    private int money;

    public CasinoGame(int initialMoney)
    {
        money = initialMoney;
    }

            private string GetChoiceDescription(string choice) // Lambda
            {
             return choice switch
             {
             "a" => "jämnt",
             "b" => "ojämnt",
             "c" => "1 till 18",
             "d" => "19 till 36",
             "e" => "rött",
             "f" => "svart",
             "g" => "första 12:a",
             "h" => "andra 12:a",
             "i" => "tredje 12:a",
             _ => "Ogiltigt val"    
        };
    }
    public void StartGame()
    {
        ForegroundColor = ConsoleColor.Yellow; // byter färg till gult
        Clear();
        Random random = new Random(); // starta new randomizer
        var r = new Random(); // används för string randomColor = color[r.Next(color.Length)]; random mellan 2 färger
        OutputEncoding = Encoding.UTF8;  
        string[] color = { "Red", "Black" };
        int bet;
        int attempts = 0;
        int wins = 0;
        int losses = 0;
        while (money != 0) {  // om man har 0 
            WriteLine("\n                                                |⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯|");
            WriteLine($" -----------------------------------------      |  Förluster: {losses}    |");
            WriteLine($"  <| 3-6-9-12 | 15-18-21-24 | 27-30-33-36 |>    |  Vinster: {wins}      |");
            WriteLine($"0 <| 2-5-8-11 | 14-17-20-23 | 26-29-32-35 |>    |  Försök: {attempts}       |");
            WriteLine($"  <| 1-4-7-10 | 13-16-19-22 | 25-28-31-34 |>    |  Pengar: {money}$   |");
            WriteLine(" -----------------------------------------      |⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯|");
            WriteLine("       | 1:a 12 | 2:a 12 | 3:a 12 |");
            WriteLine(" 1-18 | jämnt | Svart/Röd | ojämnt | 19-36 ");
            WriteLine(" -----------------------------------------\n");

            WriteLine("(a). Första 12:a | (b). Andra 12:a | (c). Tredje 12:a | (d). 1 till 18"); // Villkor
            WriteLine("(e). Jämnt | (f). Svart | (g). Röd | (h). Ojämnt | (i). 19 till 36\n"); // Villkor


            Write("Vad vill du gissa på?(skriv boktav a-i): ");
            string choice = ReadLine().ToLower(); // läsa av valet poch gör till små bokstäver *(val)
            string choiceDescription = GetChoiceDescription(choice); // funktion "GetChoiceDescription"


            if (choiceDescription == "Ogiltigt val")
            {
                Console.Clear();
                Console.WriteLine("Skriv in rätt val. Vänta 3 sekunder innan du fortsätter:");
                Thread.Sleep(3000);
                Console.Clear();
                continue;
            }
                //Thread.Sleep(3000);  // vänta 3 sek
                Clear();
                WriteLine("-----------------------------------------   |⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯|");
                WriteLine($"Hur mycket vill du betta? (min: 10$)        | Balans: {money} |");
                WriteLine("-----------------------------------------   |⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯|");
                Write("Din bet: ");
                bet = Convert.ToInt32(ReadLine());
                if (bet > money || bet < 10) {
                    Clear();
                    WriteLine("\n------------------------------------");
                    WriteLine("Du har inte tillräckligt med pengar eller din bet är för låg");
                    WriteLine("Tryck något knapp för att börja om");
                    WriteLine("------------------------------------");
                    ReadKey();
                    Clear();
                    continue;
                } else {
                   money -= bet;
                   int roll = random.Next(0, 37);
                   string randomColor = color[r.Next(color.Length)];
                   bool even = roll % 2 == 0; // beräknar resten när "roll" delas med 2. Jämför resten med 0 och om den är så så är det jämnt. Even blir = true och odd = false om talet är ojämn
                    if (((choice == "a") && (roll > 0 && roll < 13)) || ((choice == "b") && (roll > 12 && roll < 25)) || ((choice == "c") && (roll > 24 && roll < 37)))
                        {
                            WriteLine("\nThe roulette rolled: " + randomColor + " " + roll);
                            WriteLine("\nWINNER! $" + (bet * 2));
                            WriteLine("\nPress enter to continue");
                            WriteLine($"\nDu har gissat på: {GetChoiceDescription(choice)}");
                            money += (bet * 3);
                            wins++;
                            ReadKey();
                        } 
                else if ((choice == "d") && ((roll > 0) && (roll < 19)))
                {
                        WriteLine("\nThe roulette rolled: " + randomColor + " " + roll);
                        WriteLine("\nWINNER! $" + (bet * 2));
                        WriteLine("\nPress enter to continue");
                        WriteLine($"\nDu har gissat på: {GetChoiceDescription(choice)}");
                        money += (bet * 3);
                        wins++;
                        ReadKey();    
                }
                else if ((choice == "e") && ((even == true) ))
                {
                        WriteLine("\nThe roulette rolled: " + randomColor + " " + roll);
                        WriteLine("\nWINNER! $" + (bet * 2));
                        WriteLine("\nPress enter to continue");
                        WriteLine($"\nDu har gissat på: {GetChoiceDescription(choice)}");
                        money += (bet * 3);
                        wins++;
                        ReadKey();    
                }
                 else 
                        {
                        losses++;
                        WriteLine($"\nYou lost ${bet}");
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


// Vad ska vi göra?
// Roulette? (idk)
// Slot Machine? (Ganska lätt men kan utvecklas)
// Poker? (Svårt)

// Implementera min bet amount

// Hur fungerar Roulette?






