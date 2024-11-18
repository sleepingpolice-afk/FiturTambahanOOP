public class Pocong : Enemy
{
    private Random random = new Random();

    public Pocong()
    {
        Name = "Pocong; Wraith in shrouded Bound";
        Health = 80;
        AttackPower = 10;
        Money = 50;
    }

    public override void TakeDamage(float damage, Character character)
    {
        Health -= damage;
        Console.WriteLine($"{Name} menerima {damage} damage! Sisa HP: {Health}");
        if (!Alive()) return;

        // Memiliki probabilitas 40% untuk menyerang dari belakang
        if (random.NextDouble() < 0.4)
        {
            Console.WriteLine($"{Name} menyerang dari belakang!");
            character.Health -= AttackPower;
            Console.WriteLine($"{character.Name} kehilangan {AttackPower} HP. Sisa HP: {character.Health}");
        }

        // Saat Health kurang dari 50%, memiliki 60% kemungkinan untuk heal 10%
        if (Health <= 40 && random.NextDouble() < 0.6)
        {
            int healAmount = (int)(0.1 * Health);
            Health += healAmount;
            Console.WriteLine($"{Name} memulihkan {healAmount} HP. Total HP sekarang: {Health}");
        }
    }
}
