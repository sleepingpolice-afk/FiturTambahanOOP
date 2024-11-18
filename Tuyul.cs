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
        if (Health > 0)
        {
            Console.WriteLine($"\n{Name} menerima {damage} damage! Sisa HP: {Health}.");
            Console.WriteLine($"{Name} terus berusaha menyerang untuk mencuri uangmu lalu digunakan untuk cari makan di Kutek");
        }
        else
        {
            Console.WriteLine($"\n{Name} jatuh ke tanah, tapi tenang saja, dia masih punya uang untuk membeli makan di Kutek :)");
        }
    }
}