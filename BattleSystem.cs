public class BattleSystem
{
    public void ExecuteBattle(Character character, Enemy enemy)
    {
        Console.WriteLine($"\n--- Pertarungan Dimulai: {enemy.Name} ---");

        while (enemy.Alive() && character.Health > 0)
        {
            Console.WriteLine("\nPilih tindakan:");
            Console.WriteLine("1. Serangan jarak dekat");
            Console.WriteLine("2. Serangan jarak jauh");
            Console.WriteLine("3. Healing Potion");

            string choice = Console.ReadLine();
            IAttackStrategy attackStrategy;

            switch (choice)
            {
                case "1":
                    if (enemy is Legendcoak legendcoak && legendcoak.UltimateActivated)
                    {
                        Console.WriteLine("Serangan jarak dekat akan selalu meleset saat musuh mengaktifkan ultimate!");
                        continue;
                    }
                    attackStrategy = new ShortAttack();
                    break;
                case "2":
                    attackStrategy = new LongRangeAttack();
                    break;
                case "3":
                    HealthPotion potion = new HealthPotion();
                    potion.Use(character);
                    continue;
                default:
                    Console.WriteLine("Pilihan tidak valid. Coba lagi.");
                    continue;
            }

            attackStrategy.Attack(character, enemy);
        }

        if (character.Health <= 0)
        {
            Console.WriteLine($"{character.Name} telah kalah dalam pertarungan!");
        }
        else if (!enemy.Alive())
        {
            Console.WriteLine($"{character.Name} mengalahkan {enemy.Name} dan mendapatkan uang dari musuh sebesar {enemy.Money}!");
            character.CurrencyManager.AddMoney(enemy.Money);
        }

        HealthPotion.ResetUsageCount();
    }
}
