using Newtonsoft.Json; // För JSON 
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;


public class PlayerData
{
    public string Name { get; set; }
    public int Balance { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
}

public class Leaderboard
{
    private List<PlayerData> players;

    // Konstruktor för klassen
    public Leaderboard()
    {
        players = new List<PlayerData>(); // Skapar en lista över spelare
        LoadData(); // Laddar data om spelare från filen när Leaderboard-objektet skapas
    }

    // Metod för att lägga till en ny spelare eller uppdatera en befintlig
    public void AddPlayer(PlayerData player)
    {
        // Letar efter en befintlig spelare med samma namn
        var existingPlayer = players.FirstOrDefault(p => p.Name == player.Name); // söka efter spelare. Om sådan hittas = returnera spelare eller returnera null

        if (existingPlayer != null)
        {
            // Om spelaren redan finns, uppdatera spelarens data
            existingPlayer.Balance += player.Balance;
            existingPlayer.Wins += player.Wins;
            existingPlayer.Losses += player.Losses;
        }
        else
        {
            // Annars, om spelaren inte finns, lägg till den i listan
            players.Add(player);
        }

        // Spara de uppdaterade datan till filen
        SaveData();
    }

    // Metod för att visa leaderboard
    public void ShowLeaderboard()
    {
        Clear(); // Rensa konsolen innan leaderboard visas
        var sortedPlayers = players.OrderByDescending(p => p.Balance).ToList(); // Sortera spelare efter balans i fallande ordning

        Console.WriteLine("Leaderboard:\n");
        foreach (var player in sortedPlayers)
        {
            // Visa information om varje spelare på skärmen
            Console.WriteLine($"{player.Name} - Balans: {player.Balance}, Vinster: {player.Wins}, Förluster: {player.Losses}\n");
        }
    }

    // Privat metod för att ladda data från filen
    private void LoadData()
    {
        if (File.Exists("leaderboard.json"))
        {
            // Läs JSON-data från filen och deserialisera den till en lista över spelare
            string json = File.ReadAllText("leaderboard.json");
            players = JsonConvert.DeserializeObject<List<PlayerData>>(json);
        }
    }

    // Privat metod för att spara data till filen
    private void SaveData()
    {
        // Serialisera listan över spelare till JSON-format och spara den i filen
        string json = JsonConvert.SerializeObject(players);
        File.WriteAllText("leaderboard.json", json);
    }
}
