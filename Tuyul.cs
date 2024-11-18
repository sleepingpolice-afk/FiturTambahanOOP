public class Tuyul : Enemy
{
    private Random random = new Random();

    public Tuyul()
    {
        Name = "Tuyul; Scurry Impish Little Trickster";
        Health = 50;
        AttackPower = 5;
        Money = 30; // Uang yang dimiliki Tuyul
    }
    

    public override void TakeDamage(int damage, Character character)
    {
        Health -= damage;
        Console.WriteLine($"{Name} menerima {damage} damage! Sisa HP: {Health}");
        if (!Alive()) return;

        // Memiliki probabilitas 40% untuk mencuri uang character
        if (random.NextDouble() < 0.4)
        {
            int stolenAmount = 10;
            character.SpendMoney(stolenAmount);
            Console.WriteLine($"{Name} mencuri uangmu sebesar {stolenAmount}!");
        }

        // Menawarkan uang saat HP < 30%
        if (Health <= 15)
        {
            Console.WriteLine($"{Name} menawarkan uang sebesar {Money} untuk ganti nyawanya. Terima?");
            character.GainMoney(Money);
            Health = 0; // Tuyul menyerah
        }
    }
}