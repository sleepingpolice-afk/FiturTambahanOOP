public class Game
{
    public static void Main(string[] args)
    {
        Character character = Character.Instance;
        character.AddMoney(20); // Tambahan uang saat mulai
        // Membuat instance karakter dan musuh
        Character character = Character.Instance;
        Enemy enemy = EnemyFactory.CreateEnemy(1); // Musuh pertama

        // Membuat BattleSystem dan memilih strategi serangan
        BattleSystem battleSystem = new BattleSystem();
        Console.WriteLine("Pilih jenis serangan: 1. Short Range, 2. Long Range");
        int choice = int.Parse(Console.ReadLine());

        IAttackStrategy attackStrategy = choice == 1 ? new ShortRangeAttack() : new LongRangeAttack();
        battleSystem.StartBattle(character, enemy, attackStrategy);

        // Memulai pertarungan
        battleSystem.StartBattle(character, enemy, attackStrategy);

        // Menggunakan item (HealthPotion)
        Item healthPotion = new HealthPotion();
        ItemDecorator decoratedPotion = new HealthPotionDecorator(healthPotion);
        decoratedPotion.Use(character);

        // Mengumpulkan XP dan naik level
        LevelUpSystem levelUpSystem = new LevelUpSystem();
        levelUpSystem.CheckLevelUp(character, 150); // XP yang diperoleh
    }
}