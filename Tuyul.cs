public class Tuyul : Enemy
{
    private Random random = new Random();

    public Tuyul()
    {
        Name = "Tuyul; Scurry Impish Little Trickster";
        Health = 50;
        AttackPower = 5;
        Money = 30;
    }

    public override void TakeDamage(float damage, Character character)
    {
        Health -= damage;
        Console.WriteLine($"{Name} menerima {damage} damage! Sisa HP: {Health}");
        if (!Alive()) return;

        if (random.NextDouble() < 0.4)
        {
            int stolenAmount = 10;
            if (character.CurrencyManager.DeductMoney(stolenAmount))
            {
                Console.WriteLine($"{Name} mencuri uangmu sebesar {stolenAmount}!");
            }
        }

        if (Health <= 15)
        {
            Console.WriteLine($"{Name} menawarkan uang sebesar {Money} untuk ganti nyawanya. Terima?");
            character.CurrencyManager.AddMoney(Money);
            Health = 0;
        }
    }
}