// Factory Pattern untuk membuat musuh berdasarkan level.
public abstract class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }

    public abstract void TakeDamage(int damage);
}

public class Tuyul : Enemy
{
    public Tuyul()
    {
        Name = "Tuyul";
        Health = 50;
        AttackPower = 5;
    }

    public override void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} menerima {damage} damage! Sisa HP: {Health}");
    }
}

public class Pocong : Enemy
{
    public Pocong()
    {
        Name = "Pocong";
        Health = 80;
        AttackPower = 10;
    }

public class Legendcoak : Enemy
{
    public Legendcoak()
    {
        Name = "Kecoak Legendaris";
        Health = 200;
        AttackPower = 30;
    }
}

    public override void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} menerima {damage} damage! Sisa HP: {Health}");
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
