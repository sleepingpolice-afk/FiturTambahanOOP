public class Tuyul : Enemy
{
    private Random random = new Random();

    public Tuyul()
    {
        Name = "Tuyul; Scurry Impish Little Trickster";
        Health = 50;
        Money = 30;
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

        int baseDamage = 8;
        character.Health -= baseDamage;
        Console.WriteLine($"{Name} mengeluarkan jurus 'You Can Catch This Hand!'. Sisa HP: {character.Health}");

        if (random.NextDouble() < 0.4)
        {
            int stolenAmount = random.Next(1, 101);
            if (character.CurrencyManager.DeductMoney(stolenAmount))
            {
                Console.WriteLine($"{Name} menggunakan jurus rahasia : 'Tangan Panjang, Badan Pendek'. Memanfaatkan momen untuk mencuri uangmu sebesar {stolenAmount}!");
            }
        }

        if (Health <= 15)
        {
            Console.WriteLine($"{Name} menawarkan uang sebesar {Money} untuk ganti nyawanya. Terima?");
            Console.WriteLine("1. Iya");
            Console.WriteLine("2. Tidak");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                character.CurrencyManager.AddMoney(Money);
                Console.WriteLine($"{Name} melarikan diri!");
                Health = 0;
            }
        }
    }
}