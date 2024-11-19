public abstract class Item
{
    public string Name { get; set; } = "Unknown";
    public abstract void Use(Character character);
}

public class HealthPotion : Item
{
    public int HealthRestore { get; set; }
    private static int usageCount = 0; 
    private const int MaxUsage = 5;

    public HealthPotion()
    {
        Name = "Health Potion";
        HealthRestore = 20;
    }

    public override void Use(Character character)
    {
        if (usageCount >= MaxUsage)
        {
            Console.WriteLine("Pemburu kembung! Tidak bisa menggunakan potion lebih dari 5 kali selama pertarungan.");
            return;
        }

        character.Health += HealthRestore;
        Console.WriteLine($"{character.Name} menggunakan {Name} dan memulihkan {HealthRestore} HP. Sisa HP: {character.Health}");
        usageCount++;
    }

    public static void ResetUsageCount()
    {
        usageCount = 0; 
    }
}

public abstract class ItemDecorator : Item
{
    protected Item item;

    public ItemDecorator(Item item)
    {
        this.item = item;
    }

    public virtual void Use(Character character)
    {
        Console.WriteLine($"Menggunakan {item.Name}");
    }
}

public class HealthPotionDecorator : ItemDecorator
{
    public HealthPotionDecorator(Item item) : base(item) { }

    public override void Use(Character character)
    {
        base.Use(character);
        character.Health += 20;
        Console.WriteLine($"{character.Name} mendapat tambahan 20 HP!");
    }
}

public class MoneyBag : Item
{
    public int Amount { get; set; }

    public MoneyBag(int amount)
    {
        Name = "Money Bag";
        Amount = amount;
    }

    public void TransferMoneyToCharacter(Character character)
    {
        character.GainMoney(Amount);
        Console.WriteLine($"{Name} memberikan uang sebesar {Amount} kepada {character.Name}.");
        Amount = 0; // Setelah dipindahkan, uang habis
    }
}
