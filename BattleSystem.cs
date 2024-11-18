<<<<<<< HEAD
public class BattleSystem
{
    public void StartBattle(Character character, Enemy enemy, IAttackStrategy attackStrategy)
    {
        Console.WriteLine($"Pertarungan dimulai melawan {enemy.Name}!");
        attackStrategy.Attack(character, enemy);
    }
}
=======
using System;

public class BattleSystem
{
    public void ExecuteBattle(Character character, Enemy enemy)
    {
        Console.WriteLine($"\n--- Pertarungan Dimulai: {enemy.Name} ---");

        while (enemy.Alive() && character.Health > 0)
        {
            Console.WriteLine("\nPilih jenis serangan:");
            Console.WriteLine("1. Serangan jarak dekat");
            Console.WriteLine("2. Serangan jarak jauh");

            string choice = Console.ReadLine();
            IAttackStrategy attackStrategy = null;

            switch (choice)
            {
                case "1":
                    attackStrategy = new ShortAttack();
                    break;
                case "2":
                    attackStrategy = new LongRangeAttack();
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid. Coba lagi.");
                    continue;
            }

            if (attackStrategy != null)
            {
                character.Attack(character, enemy);
            }
        }

        if (character.Health <= 0)
        {
            Console.WriteLine($"{character.Name} telah kalah dalam pertarungan!");
        }
        else if (!enemy.Alive())
        {
            Console.WriteLine($"{character.Name} mengalahkan {enemy.Name} dan mendapatkan uang dari musuh sebesar {enemy.Money}!");
            character.GainMoney(enemy.Money);
        }
    }
}
>>>>>>> 5ccf614e5e43041a081f848414811781b3297e60
