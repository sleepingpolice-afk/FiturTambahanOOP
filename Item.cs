// Decorator Pattern untuk menambahkan efek pada item.
public abstract class Item
{
    public string Name { get; set; }
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
