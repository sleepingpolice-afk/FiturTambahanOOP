using System;
using System.Collections.Generic;

public class GameOverMessage
{
    private static Random random = new Random();
    private Dictionary<string, int> leaderboard = new Dictionary<string, int>();

    private static List<string> defaultMessages = new List<string>
    {
        "Nikmati potongan rambut barumu.",
        "Sosok itu menatapmu dengan puas.",
        "..."
    };
    

    private static Dictionary<string, List<string>> specialMessages = new Dictionary<string, List<string>>
    {
        { "Legencoak", new List<string>
            {
                "Sayangnya, kau lebih takut pada kecoak dibanding ia padamu.",
                "Your futile resistance was no match for the legendary beast!",
                "Beware of the next encounter with the Flying Horror."
            }
        },
        { "Pocong; Wraith in shrouded Bound", new List<string>
            {
                "...",
                "Your fear was the Pocong’s greatest weapon.",
            }
        },
        {
            "Tuyul; Scurry Impish Little Trickster", new List<string>
            {
                "Ia akan menggunakan uangmu untuk jajan di Kutek."
            }
        }
    };

    public static string GetMessage(string enemyName)
    {
        
        if (specialMessages.ContainsKey(enemyName))
        {
            if (random.NextDouble() < 0.9)
            {
                var messages = specialMessages[enemyName];
                return messages[random.Next(messages.Count)];
            }
        }
        else
        {
            return defaultMessages[random.Next(defaultMessages.Count)];
        }
        return defaultMessages[random.Next(defaultMessages.Count)];
    }

    public void AddToLeaderboard(string name, int score)
    {
        leaderboard.Add(name, score);
        //sort leaderboard gmn how ges
        //var sortedByValue = leaderboard.OrderBy(entry => entry.Value).ToDictionary(entry => entry.Key, entry => entry.Value);
    }

    public void ShowLeaderboard()
    {
        Console.Clear();
        Console.WriteLine("Leaderboard");
        var sortedByValue = leaderboard.OrderByDescending(entry => entry.Value).ToDictionary(entry => entry.Key, entry => entry.Value);
        foreach (var entry in sortedByValue)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }
}
