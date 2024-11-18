public class Pocong : Enemy
{
    public Pocong()
    {
        Name = "Pocong";
        Health = 80;
        AttackPower = 10;
    }

    public override void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health > 0)
        {
            Console.WriteLine($"\n{Name} menerima {damage} damage! Sisa HP: {Health}.");
            Console.WriteLine($"{Name} mulai loncat-loncat seperti guling! Hati-hati, dia bisa jadi gulingmu saat tidur nanti!");
        }
        else
        {
            Console.WriteLine($"\n{Name} terjatuh dengan suara keras, dan tidak akan menjadi gulingmu nanti malam :)");
        }
    }
}