using System;

public class Game
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Selamat datang di permainan pertarungan epik melawan Kecoak Legendaris!");

        Character character = Character.Instance;

        Enemy enemy = new Legendcoak();

        BattleSystem battleSystem = new BattleSystem();
        battleSystem.ExecuteBattle(character, enemy);

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
