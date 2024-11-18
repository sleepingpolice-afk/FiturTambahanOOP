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

            IAttackStrategy? attackStrategy = null;
            string choice = Console.ReadLine();
            IAttackStrategy attackStrategy = new ShortAttack();

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
                default:
                    Console.WriteLine("Pilihan tidak valid. Coba lagi.");
                    continue;
            }

            if (attackStrategy != null)
            {
                attackStrategy.Attack(character, enemy);
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
