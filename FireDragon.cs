public class FireDragon : Enemy
{
    private Random random = new Random();

    public FireDragon()
    {
        Name = "Fire Dragon: Guardian of the Glorious Throne";
        Health = 300;
        Money = 100;
    }

    public override void TakeDamage(float damage, Character character)
    {
        if (damage == 0)
        {
            float retaliationDamage = 7; // Besar damage serangan balik
            character.Health -= retaliationDamage;
            Console.WriteLine($"{character.Name} menerima {retaliationDamage} damage dari serangan balik! Sisa HP: {character.Health}");
            return; // Tidak melanjutkan logika lain
        }

        Health -= damage;
        Console.WriteLine($"{Name} menerima {damage} damage! Sisa HP: {Health}");
        if (!Alive()) return;

        int baseDamage = 0;

        random = new Random();
        if(random.NextDouble() < 0.3)
        {
            character.Health -= character.Health * 0.1f;
            if(character.hasDebuff == false)
            {
                character.ApplyDebuff(new BurnDebuff(3, 3));
            }
            Console.WriteLine($"{Name} mengeluarkan jurus 'The Ancient Beast; Wisdom of the Old World'. Sisa HP: {character.Health}");
        }
        else
        {
            character.Health -= baseDamage;
            Console.WriteLine($"{Name} mengeluarkan cakarnya!'. Sisa HP: {character.Health}");
        }
    }
}