using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public class Leaderboard
{
    private List<PlayerData> players;

    public Leaderboard()
    {
        players = new List<PlayerData>();
        LoadData();
    }

    public void AddPlayer(PlayerData player)
    {
        var existingPlayer = players.FirstOrDefault(p => p.Name == player.Name);

        if (existingPlayer != null)
        {
            existingPlayer.Balance += player.Balance;
            existingPlayer.Wins += player.Wins;
            existingPlayer.Losses += player.Losses;
        }
        else
        {
            players.Add(player);
        }

        SaveData();
    }

    public void ShowLeaderboard()
    {
        Clear();
        var sortedPlayers = players.OrderByDescending(p => p.Balance).ToList();

        Console.WriteLine("Leaderboard:\n");
        foreach (var player in sortedPlayers)
        {
            Console.WriteLine($"{player.Name} - Balans: {player.Balance}, Vinster: {player.Wins}, Förluster: {player.Losses}\n");
        }
    }

    private void LoadData()
    {
        if (File.Exists("leaderboard.json"))
        {
            string json = File.ReadAllText("leaderboard.json");
            players = JsonConvert.DeserializeObject<List<PlayerData>>(json);
        }
    }

    private void SaveData()
    {
        string json = JsonConvert.SerializeObject(players);
        File.WriteAllText("leaderboard.json", json);
    }
}
