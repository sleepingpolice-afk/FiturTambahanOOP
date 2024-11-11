// Singleton Pattern untuk memastikan hanya ada satu karakter utama.
public class Character
{
    private static Character instance;
    public string Name { get; set; }
    public int Health { get; set; }
    public int Level { get; set; }
    public int AttackPower { get; set; }

    private Character()
    {
        // Default values
        Name = "Pemburu Harta Karun";
        Health = 100;
        Level = 1;
        AttackPower = 10;
    }

    public static Character Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Character();
            }
            return instance;
        }
    }

    public void LevelUp()
    {
        Level++;
        AttackPower += 5; // Meningkatkan kekuatan serangan
        Health += 20; // Meningkatkan HP
        Console.WriteLine($"{Name} naik level menjadi {Level}. HP: {Health}, Attack Power: {AttackPower}");
    }

    public void Attack(Enemy enemy)
    {
        Console.WriteLine($"{Name} menyerang {enemy.Name} dengan kekuatan {AttackPower}!");
        enemy.TakeDamage(AttackPower);
    }
}
