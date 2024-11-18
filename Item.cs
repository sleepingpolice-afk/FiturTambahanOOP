public abstract class Item
{
    public string Name { get; set; }
<<<<<<< HEAD
}
=======
}

public class HealthPotion : Item
{
    public int HealthRestore { get; set; }

    public HealthPotion()
    {
        Name = "Health Potion";
        HealthRestore = 20;
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
>>>>>>> 5ccf614e5e43041a081f848414811781b3297e60
