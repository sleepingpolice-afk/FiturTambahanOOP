public class Legendcoak : Enemy
{
    private Random random = new Random();
    private bool ultimateActivated = false;
    private int democracyRounds = 0;

    public Legendcoak()
    {
        Name = "Kecoak Legendaris";
        Health = 200;
        AttackPower = 30;
        Money = 100;
    }

    public override void TakeDamage(int damage, Character character)
    {
        Health -= damage;
        Console.WriteLine($"{Name} menerima {damage} damage! Sisa HP: {Health}");
        if (!IsAlive()) return;

        // Memiliki 40% kemungkinan mengeluarkan Ultimate saat health < 50%
        if (Health <= 100 && !ultimateActivated && random.NextDouble() < 0.4)
        {
            Console.WriteLine($"{Name} mengaktifkan Ultimate: The Flying Horror!");
            AttackPower = (int)(AttackPower * 1.1);
            ultimateActivated = true;
            // Harusnya ditambah hanya bisa diserang menggunakan long range attack
        }

        // Serangan memiliki probabilitas
        double attackChoice = random.NextDouble();
        if (attackChoice < 0.4)
        {
            Console.WriteLine($"{Name} mengeluarkan jurus 'The Ancient Beast; Wisdom of the Old World'");
        }
        else if (attackChoice < 0.8)
        {
            Console.WriteLine($"{Name} mengeluarkan jurus 'Monster Lurks Beneath the Shadow of The Dawn'");
        }
        else
        {
            Console.WriteLine($"{Name} mengeluarkan jurus 'The Democracy', pemain akan kehilangan 5 HP setiap ronde selama 3 ronde.");
            democracyRounds = 3;
        }

        // Efek 'The Democracy'
        if (democracyRounds > 0)
        {
            character.Health -= 5;
            Console.WriteLine($"{character.Name} kehilangan 5 HP karena efek 'The Democracy'. Sisa HP: {character.Health}");
            democracyRounds--;
        }
    }
}
