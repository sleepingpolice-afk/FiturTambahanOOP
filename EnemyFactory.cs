// Factory Pattern untuk membuat musuh berdasarkan level.
public abstract class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public int Money { get; set; } //uang musuh

    public abstract void TakeDamage(int damage);
}

public class Tuyul : Enemy
{
    private Random random = new Random();

    public Tuyul()
    {
        Name = "Tuyul";
        Health = 50;
        AttackPower = 5;
        Money = 30; // Uang yang dimiliki Tuyul
    }

    public override void TakeDamage(int damage, Character character)
    {
        Health -= damage;
        Console.WriteLine($"{Name} menerima {damage} damage! Sisa HP: {Health}");

        // Memiliki probabilitas 40% untuk mencuri uang character
        if (random.NextDouble() < 0.4)
        {
            int stolenAmount = 10;
            character.DeductMoney(stolenAmount);
            Console.WriteLine($"{Name} mencuri uangmu sebesar {stolenAmount}!");
        }

        // Menawarkan uang saat HP < 30%
        if (Health <= 15)
        {
            Console.WriteLine($"{Name} menawarkan uang sebesar {Money} untuk ganti nyawanya. Terima?");
            character.AddMoney(Money);
            Health = 0; // Tuyul menyerah
        }
    }
}

public class Pocong : Enemy
{
    private Random random = new Random();

    public Pocong()
    {
        Name = "Pocong";
        Health = 80;
        AttackPower = 10;
        Money = 50;
    }

    public override void TakeDamage(int damage, Character character)
    {
        Health -= damage;
        Console.WriteLine($"{Name} menerima {damage} damage! Sisa HP: {Health}");

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

ppublic class Legendcoak : Enemy
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

        // Memiliki 40% kemungkinan mengeluarkan Ultimate saat health < 50%
        if (Health <= 100 && !ultimateActivated && random.NextDouble() < 0.4)
        {
            Console.WriteLine($"{Name} mengaktifkan Ultimate: The Flying Monster!");
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
            Console.WriteLine($"{Name} mengeluarkan jurus 'Pale Lurker Beneath the Shadow of The Dawn'");
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


public class EnemyFactory
{
    public static Enemy CreateEnemy(int level)
    {
        if (level == 1)
        {
            return new Tuyul();
        }
        else if (level == 2)
        {
            return new Pocong();
        }
        else if (level == 3)
        {
            return new Legendcoak();
        }
        else
        {
            return new Tuyul();
        }
    }
}
