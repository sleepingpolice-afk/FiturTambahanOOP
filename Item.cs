public class Item
{
    public string Name { get; set; } = "Unknown";
    //public abstract void Use(Character character);

    public static Dictionary<string, int> items = new Dictionary<string, int>();
    private const int MaxItemCount = 10; // Batas jumlah maksimum item yang dapat dimiliki

    // Alur dari penambahan item pada saat permainan akan diserahkan ke grup lain yang mendapatkan game ini
    // Method-method penambahan dan pengurangan item berikut akan digunakan untuk membatasi jumlah item
    
    public static void AddItem(string itemName, int quantity)
    {
        int currentCount = items.ContainsKey(itemName) ? items[itemName] : 0;

        if (currentCount + quantity > MaxItemCount)
        {
            Console.WriteLine($"Tidak bisa menambahkan {quantity} {itemName}. Jumlah item melebihi batas maksimum ({MaxItemCount}).");
        }

        if (items.ContainsKey(itemName))
        {
            items[itemName] += quantity;
        }
        else
        {
            items[itemName] = quantity;
        }

        Console.WriteLine($"{quantity} {itemName} ditambahkan ke inventori.");
    }

    public virtual void UseItem(string itemName, Character character)
    {
        if (items.ContainsKey(itemName) && items[itemName] > 0)
        {
            items[itemName]--;
            Console.WriteLine($"{itemName} digunakan. Sisa: {items[itemName]}");
        }
        else
        {
            Console.WriteLine($"Tidak ada {itemName} yang tersisa di inventori.");
        }
    }

    public static void ShowInventory()
    {
        Console.Clear();
        Console.WriteLine("Isi Inventori:");
        Console.WriteLine("HP "+Character.Instance.Name + ": " + Character.Instance.Health);
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
        Console.WriteLine("Tekan Enter untuk kembali ke pertarungan.");
        Console.ReadLine();
    }
}


// Item yang terdapat pada inventori
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

    public override void UseItem(string itemName, Character character)
    {
        if (usageCount >= MaxUsage)
        {
            Console.WriteLine("Pemburu kembung! Tidak bisa menggunakan potion lebih dari 5 kali selama pertarungan.");
            return;
        }

        if (items.ContainsKey(itemName) && items[itemName] > 0)
        {
            items[itemName]--;
        }
        else
        {
            Console.WriteLine($"Tidak ada {itemName} yang tersisa di inventori.");
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

    public override void UseItem(string itemName, Character character)
    {
        itemName = item.Name;
        Console.WriteLine($"Menggunakan {itemName}");
    }
}

public class HealthPotionDecorator : ItemDecorator
{
    public HealthPotionDecorator(Item item) : base(item) { }

    public override void UseItem(string itemName, Character character)
    {
        base.UseItem("HealthPotion", character);
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

    public override void UseItem(string itemName, Character character)
    {
        character.CurrencyManager.AddMoney(Amount);
        Console.WriteLine($"{Name} memberikan uang sebesar {Amount} kepada {character.Name}.");
        Amount = 0; // Setelah dipindahkan, uang habis
    }
}