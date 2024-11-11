public class Game
{
    public static void Main(string[] args)
    {
        // Membuat instance karakter dan musuh
        Character character = Character.Instance;
        Enemy enemy = EnemyFactory.CreateEnemy(1); // Musuh pertama

        // Membuat BattleSystem dan memilih strategi serangan
        BattleSystem battleSystem = new BattleSystem();
        IAttackStrategy attackStrategy = new NormalAttack();

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
