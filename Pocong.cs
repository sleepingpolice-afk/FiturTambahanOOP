public class Pocong : Enemy
{
    private Random random = new Random();

    public Pocong()
    {
        Name = "Pocong; Wraith in shrouded Bound";
        Health = 80;
        Money = 50;
    }

    public override void TakeDamage(float damage, Character character)
    {
        if (damage == 0)
        {
            float retaliationDamage = 7; // Besar damage serangan balik
            character.Health -= retaliationDamage;
            Console.WriteLine($"{character.Name} menerima {retaliationDamage} damage! Sisa HP: {character.Health}");
            return; // Tidak melanjutkan logika lain
        }

        Health -= damage;
        Console.WriteLine($"{Name} menerima {damage} damage! Sisa HP: {Health}");
        if (!Alive()) return;

        // Memiliki probabilitas 40% untuk menyerang dari belakang
        if (random.NextDouble() < 0.4)
        {
            int baseDamage = 10;
            Console.WriteLine($"{Name} menggunakan jurus 'Beyond The Grave'. Menyerang dari belakang!");
            character.Health -= baseDamage;
            Console.WriteLine($"{character.Name} kehilangan {baseDamage} HP. Sisa HP: {character.Health}");
        }
        else{
            int baseDamage = 8;
            character.Health -= baseDamage;
            Console.WriteLine($"{Name} mengeluarkan jurus 'Ketimpuk Guling'. Sisa HP: {character.Health}");
        }

        // Saat Health kurang dari 50%, memiliki 60% kemungkinan untuk heal 10%
        if (Health <= 40 && random.NextDouble() < 0.6)
        {
            int healAmount = (int)(0.4 * Health);
            Health += healAmount;
            Console.WriteLine($"{Name} memulihkan {healAmount} HP. Total HP sekarang: {Health}");
        }
    }
}