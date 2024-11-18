public class KecoaTerbang : Enemy
{
    public KecoaTerbang()
    {
        Name = "Kecoa Terbang";
        Health = 200; // HP lebih besar karena ini level bos
        AttackPower = 25; // Damage lebih besar
    }
    public override void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} menerima {damage} damage! Sisa HP: {Health}");

        // Efek khusus saat kecoa terbang dalam masa kritis dan memperbesar attack power agar lebih menantang
        if (Health <= 50)
        {
            Console.WriteLine($"\n {Name} mulai mengamuk! Sayapnya bergetar liar, dan serangannya menjadi lebih ganas!");
            Console.WriteLine($" {Name}'s Attack Power meningkat menjadi {AttackPower + 10}! Bersiaplah menghadapi serangan maut!");
            AttackPower += 10; // Meningkatkan kekuatan serangan
        }
    }
}