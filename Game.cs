using System;

public class Game
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Selamat datang di permainan pertarungan epik melawan Kecoak Legendaris!");

        // Instantiate the main character
        Character character = Character.Instance;
        
        // Customize the character name if desired
        character.Name = "Pemain Terbaik";

        // Instantiate the legendary enemy, Legendcoak
        Enemy enemy = new Legendcoak();

        // Initialize the Battle System and start the battle
        BattleSystem battleSystem = new BattleSystem();
        battleSystem.ExecuteBattle(character, enemy);

        // Display outcome of the game
        if (character.Health > 0 && !enemy.Alive())
        {
            Console.WriteLine("\nSelamat! Kamu berhasil mengalahkan Kecoak Legendaris!");
        }
        else
        {
            Console.WriteLine("\nKamu kalah dalam pertarungan melawan Kecoak Legendaris.");
        }
    }
}
