using System;
using System.Threading;

public class Game
{
    public static void Main(string[] args)
    {
        Character character = Character.Instance;
        
        int level = 1;
        Enemy enemy = EnemyFactory.CreateEnemy(level);

        Console.WriteLine($"Karakter: {character.Name} (HP: {character.Health}, Attack Power: {character.AttackPower})");
        Console.WriteLine($"Musuh: {enemy.Name} (HP: {enemy.Health})");

        BattleSystem battleSystem = new BattleSystem();
        battleSystem.ExecuteBattle(character, enemy);
        bool continuePlaying = true;

        while (continuePlaying == true)
        {
            character.LevelUp();

            Console.WriteLine("Apakah Anda ingin bertarung lagi atau mengakhiri permainan?");
            Console.WriteLine("1. Bertarung lagi dengan musuh level berikutnya.");
            Console.WriteLine("2. Keluar dari permainan.");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                level++;
                enemy = EnemyFactory.CreateEnemy(level);
                Console.WriteLine($"\nMusuh baru: {enemy.Name} muncul di level {level}!");
                battleSystem.ExecuteBattle(character, enemy);
            }
            else
            {
                Console.WriteLine("Terima kasih telah bermain!");
                continuePlaying = false;
            }
        }
    }
    
}