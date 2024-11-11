public class ShortAttack : IAttackStrategy
//Melakukan serangan jarak jauh dN pendek
{
    public void Attack(Character character, Enemy enemy)
    {
        Console.WriteLine($"{character.Name} melakukan serangan jarak dekat!");
        enemy.TakeDamage(character.AttackPower);
    }
}

public class LongRangeAttack : IAttackStrategy
{
    public void Attack(Character character, Enemy enemy)
    {
        Console.WriteLine($"{character.Name} melakukan serangan jarak jauh!");
        enemy.TakeDamage(character.AttackPower + 5);
    }
}
