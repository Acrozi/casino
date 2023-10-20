// Vad ska vi göra?
// Roulette? (idk)
// Slot Machine? (Ganska lätt men kan utvecklas)
// Poker? (Svårt)

// Implementera min bet amount

// Hur fungerar Roulette?



global using System;
using System.Threading;
using System.Text;
namespace Casino;

class Program
{
    static void Main(string[] args)
    {
        // ForegroundColor = ConsoleColor.Yellow; // byter färg till gult
        Clear();
        OutputEncoding = Encoding.UTF8;  
        int bet;
        int attempts = 0;
        int money = 500;
        while (money != 0) { 
            WriteLine("\n-----------------------------------------     |⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯|");
            WriteLine($"<| 3-6-9-12 | 15-18-21-24 | 27-30-33-36 |>    |  Pengar: {money}     |");
            WriteLine($"<| 2-5-8-11 | 14-17-20-23 | 26-29-32-35 |>    |  Försök: {attempts}       |");
            WriteLine("<| 1-4-7-10 | 13-16-19-22 | 25-28-31-34 |>    |⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯|");
            WriteLine("-----------------------------------------");
            WriteLine("      | 1:a 12 | 2:a 12 | 3:a 12 |");
            WriteLine("1-18 | jämnt | Svart/Röd | ojämnt | 19-36 ");
            WriteLine("-----------------------------------------\n");
            WriteLine("a. Jämnt / b. Ojämnt / c. 1 till 18 / d. 19 till 36"); // Villkor
            WriteLine("e. Röd / f. Svart / g. Första 12:a / h. Andra 12:a / i. Tredje 12:a\n"); // Villkor
            Write("Välj hur du vill betta: ");
            string guess = ReadLine().ToLower(); // läsa av valet poch gör till små bokstäver
                switch (guess)
                {
                    case "a":
                        WriteLine("Du valde jämnt. Vänta 3s");
                        break;
                    case "b":
                        WriteLine("Du valde ojämnt. Vänta 3s");
                        break;
                    case "c":
                        WriteLine("Du valde 1 till 18. Vänta 3s");
                        break;
                    case "d":
                        WriteLine("Du valde 19 till 36. Vänta 3s");
                        break;
                    case "e":
                        WriteLine("Du valde rött. Vänta 3s");
                        break;
                    case "f":
                        WriteLine("Du valde svart. Vänta 3s");
                        break;
                    case "g":
                        WriteLine("Du valde första 12:a. Vänta 3s");
                        break;
                    case "h":
                        WriteLine("Du valde andra 12:a. Vänta 3s");
                        break;
                    case "i":
                        WriteLine("Du valde tredje 12:a. Vänta 3s");
                        break;
                    default:
                        
                        Clear();
                        WriteLine("Skriv in rätt val. Vända 3 sekunder innan du fortsätter:");
                        Thread.Sleep(3000); 
                        Clear();
                        continue;
                };
                Thread.Sleep(3000);  
                Clear();
                Write("Hur mycket vill du betta? (min: 10$): ");
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
                   bet =- money;
                 //  int roll = random.Next(0, 37);



                }
             attempts++;
            }
            


        }




    }


