public class BattleSystem
{
    public void ExecuteBattle(Character character, Enemy enemy, Item inventory)
    {
        Console.WriteLine($"\n--- Pertarungan Dimulai: {enemy.Name} ---");

        while (enemy.Alive() && character.Health > 0)
        {
            // Console.WriteLine("HP " + character.Name + ": " + character.Health);
            //Console.WriteLine("HP " + enemy.Name + ": " + enemy.Health);
            Console.WriteLine("\nPilih tindakan:");
            Console.WriteLine("1. Serangan jarak dekat");
            Console.WriteLine("2. Serangan jarak jauh");
            Console.WriteLine("3. Healing Potion");
            Console.WriteLine("4. Buka Tas");

            string choice = Console.ReadLine();
            IAttackStrategy attackStrategy;

            switch (choice)
            {
                case "1":
                    if (enemy is Legendcoak legendcoak && legendcoak.UltimateActivated)
                    {
                        Console.WriteLine("Serangan jarak dekat akan selalu meleset saat musuh mengaktifkan ultimate!");
                        legendcoak.TakeDamage(0, character); //saat meleset musuh menyerang balik
                        continue;
                    }
                    attackStrategy = new ShortAttack();
                    break;
                case "2":
                    attackStrategy = new LongRangeAttack();
                    break;
                case "3":
                    HealthPotion potion = new HealthPotion();
                    potion.UseItem(potion.Name, character);
                    if (enemy.Alive())
                    {
                    Console.WriteLine($"{enemy.Name} memanfaatkan momen saat kau lengah!");
                    enemy.TakeDamage(0, character);
                    }
                    continue;
                case "4":
                    Item.ShowInventory();
                    continue;
                default:
                    Console.WriteLine("Pilihan tidak valid. Coba lagi.");
                    continue;
            }

            bool attackMissed = !attackStrategy.Attack(character, enemy);
            if (attackMissed)
            {
                Console.WriteLine($"{enemy.Name} memanfaatkan kesempatan serangan meleset!");
                enemy.TakeDamage(0, character); // enemy menyerang balik
            }

            character.activeDebuff.ApplyDebuff(character);
        }

        if (character.Health <= 0)
        {
            Console.Write("Game Over: ");
            string message = GameOverMessage.GetMessage(enemy.Name);
            Console.WriteLine(message);
        }
        else if (!enemy.Alive())
        {
            Console.WriteLine($"{character.Name} mengalahkan {enemy.Name} dan mendapatkan uang dari musuh sebesar {enemy.Money}!");
            character.CurrencyManager.AddMoney(enemy.Money);
        }

        HealthPotion.ResetUsageCount();
    }
}