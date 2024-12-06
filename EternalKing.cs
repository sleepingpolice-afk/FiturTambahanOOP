using System.Threading;

public class EternalKing : Enemy
{
    private Random random = new Random();
    public int phase; // 1 for first phase, 2 for second phase

    public EternalKing()
    {
        Name = "Eternal King; The Pinnacle Demon";
        Health = 300;
        Money = 100;
        phase = 1; // Start in phase 1
    }

    public override void TakeDamage(float damage, Character character)
    {
        if (damage == 0)
        {
            float retaliationDamage = 7; // Retaliation damage
            character.Health -= retaliationDamage;
            Console.WriteLine($"{character.Name} menerima {retaliationDamage} damage dari serangan balik! Sisa HP: {character.Health}");
            return; // Do not proceed further
        }

        Health -= damage;
        Console.WriteLine($"{Name} menerima {damage} damage! Sisa HP: {Health}");
        
        if (!Alive()) return;

        int baseDamage = 0;

        // Transition between phases when health reaches a threshold
        if (phase == 1 && Health <= 150)
        {
            Console.WriteLine($"{Name} terasa semakin kuat! Fase kedua dimulai...");
            phase = 2; // Transition to phase 2
            StoryPhaseTransition();
        }

        random = new Random();

        if (phase == 1) // First phase attack
        {
            if (random.NextDouble() < 0.3)
            {
                character.Health -= character.Health * 0.1f;
                if (character.hasDebuff == false)
                {
                    character.ApplyDebuff(new BurnDebuff(3, 3));
                }
                Console.WriteLine($"{Name} mengeluarkan jurus 'The Ancient Beast; Wisdom of the Old World'. Sisa HP: {character.Health}");
            }
            else
            {
                character.Health -= baseDamage;
                Console.WriteLine($"{Name} mengeluarkan cakarnya! Sisa HP: {character.Health}");
            }
        }
        else if (phase == 2) // Second phase attack
        {
            // Make phase 2 stronger with additional damage or new attacks
            if (random.NextDouble() < 0.5) // Increased chance for special attack in phase 2
            {
                float additionalDamage = 20; // Stronger special attack
                character.Health -= additionalDamage;
                Console.WriteLine($"{Name} mengeluarkan 'Divine Wrath'! Sisa HP: {character.Health}");
            }
            else
            {
                character.Health -= baseDamage;
                Console.WriteLine($"{Name} menyerang dengan cakarnya yang lebih tajam! Sisa HP: {character.Health}");
            }
        }
    }

    // Function to display the story transition when phase 2 starts
    private void StoryPhaseTransition()
    {
        // Display the story transition when phase 2 begins
        Console.WriteLine("\n--- Fase 2: The Eternal King semakin kuat! ---");
        Thread.Sleep(1000);
        Console.WriteLine("Sambil berdiri dengan penuh amarah, sang Raja Kekal menunjukkan kekuatan sejatinya.");
        Thread.Sleep(1000);
        Console.WriteLine("Sekarang ia akan menghadapimu dengan kekuatan yang jauh lebih besar. Tidak ada jalan mundur...");
        Thread.Sleep(1000);
        Console.WriteLine("Bersiaplah untuk ujian yang lebih berat!");
        Thread.Sleep(1000);
    }
}
