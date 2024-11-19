public class Legendcoak : Enemy
{
    private Random random = new Random();
    public bool UltimateActivated { get; private set; } = false;
    private int democracyRounds = 0;


    public Legendcoak()
    {
        Name = "Kecoak Legendaris";
        Health = 200;
        Money = 100;
    }


    public override void TakeDamage(float damage, Character character)
    {
        // Jika damage == 0, ini adalah serangan balik setelah missed
        if (damage == 0)
        {
            Console.WriteLine($"{Name} menyerang balik setelah serangan meleset!");
            float retaliationDamage = 15; // Besar damage serangan balik
            character.Health -= retaliationDamage;
            Console.WriteLine($"{character.Name} menerima {retaliationDamage} damage dari serangan balik! Sisa HP: {character.Health}");
            return; // Tidak melanjutkan logika lain
        }


        // Kurangi HP musuh
        Health -= damage;
        Console.WriteLine($"{Name} menerima {damage} damage! Sisa HP: {Health}");


        if (!Alive()) return;


        // Jika HP <= 50% dan ultimate belum aktif, aktifkan Ultimate
        if (Health <= 100 && !UltimateActivated && random.NextDouble() < 0.4)
        {
            Console.WriteLine($"{Name} mengaktifkan Ultimate: The Flying Horror! Hanya serangan jarak jauh yang dapat mengenai musuh.");
            // AttackPower = (int)(AttackPower * 2);
            UltimateActivated = true;
        }


        // Efek serangan tambahan
        double attackChoice = random.NextDouble();
        if (attackChoice < 0.4)
        {
            int baseDamage = 10;
            int damageDealt = UltimateActivated ? baseDamage * 2 : baseDamage;
            character.Health -= damageDealt;
            Console.WriteLine($"{Name} mengeluarkan jurus 'The Ancient Beast; Wisdom of the Old World'. Sisa HP: {character.Health}");
        }
        else if (attackChoice < 0.8)
        {
            int baseDamage = 15;
            int damageDealt = UltimateActivated ? baseDamage * 2 : baseDamage;
            character.Health -= damageDealt;
            Console.WriteLine($"{Name} mengeluarkan jurus 'Monster Lurks Beneath the Shadow of The Dawn'. Sisa HP: {character.Health}");
        }
        else
        {
            Console.WriteLine($"{Name} mengeluarkan jurus 'The Democracy', pemain akan kehilangan 5 HP setiap ronde selama 3 ronde.");
            democracyRounds = 3;
        }


        // Efek 'The Democracy' yang berlangsung setiap ronde
        if (democracyRounds > 0)
        {
            character.Health -= 5;
            Console.WriteLine($"{character.Name} kehilangan 5 HP karena efek 'The Democracy'. Sisa HP: {character.Health}");
            democracyRounds--;
        }
    }
}
