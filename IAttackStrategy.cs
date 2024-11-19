using System;


public interface IAttackStrategy
{
    bool Attack(Character character, Enemy enemy);
}


public class LongRangeAttack : IAttackStrategy
{
    private Random random = new Random();


    public bool Attack(Character character, Enemy enemy)
    {
        if (random.NextDouble() < 0.2) // 20% chance to miss
        {
            Console.WriteLine($"{character.Name}'s long-range attack missed!");
            return false;
        }


        // Calculate damage with critical hit chance
        float damage = character.AttackPower + 5; // Base damage for long range
        if (random.NextDouble() < 0.3) // 30% chance for critical hit
        {
            damage *= 2; // Double damage for critical hit
            Console.WriteLine("Critical Hit!");
        }


        Console.WriteLine($"{character.Name} melakukan serangan jarak jauh dengan {damage} damage!");
        enemy.TakeDamage(damage, character);
        return true;
    }
}


public class ShortAttack : IAttackStrategy
{
    private Random random = new Random();


    public bool Attack(Character character, Enemy enemy)
    {
        // Check if the attack is a miss
        if (random.NextDouble() < 0.05) // 5% chance to miss
        {
            Console.WriteLine($"{character.Name}'s short-range attack missed!");
            return false;
        }


        // Calculate damage with critical hit chance
        float damage = character.AttackPower; // Base damage for short range
        if (random.NextDouble() < 0.2) // 20% chance for critical hit
        {
            damage *= 1.5f; // 50% more damage for critical hit
            Console.WriteLine("Critical Hit!");
        }


        Console.WriteLine($"{character.Name} melakukan serangan jarak dekat dengan {damage} damage!");
        enemy.TakeDamage(damage, character);
        return true;
    }
}
